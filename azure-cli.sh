#!/bin/bash
# =============================================================
# azure-cli.sh – Provisionamento da infraestrutura Azure
# Global Solution 2026/1 – CarbonTrace
# Disciplina: DevOps Tools & Cloud Computing — FIAP 2TDSPG
#
# Integrantes:
#   Gabriel Neris Losano         – RM564093
#   João Vitor Biribilli Ravelli – RM565594
#   Pedro de Matos Previtali     – RM564184
#   Pietro Paranhos Wilhelm      – RM561378
#   Felipe Monte de Sousa        – RM562019
#
# Pré-requisitos:
#   - Azure CLI instalado e logado (az login)
#   - Permissão para criar recursos na assinatura
#
# Uso:
#   chmod +x azure-cli.sh
#   ./azure-cli.sh
# =============================================================

set -e  # Interrompe em caso de erro

# ---------------------------------------------------------------
# Variáveis
# ---------------------------------------------------------------
RESOURCE_GROUP="rg-carbontrace-gs"
LOCATION="southafricanorth"
VM_NAME="vm-carbontrace-rm561378"
VM_SIZE="Standard_B4ls_v2"
VM_IMAGE="Ubuntu2204"
ADMIN_USER="carbontrace"
ADMIN_PASSWORD="Fiap@20262026"
DOCKERHUB_USER="pietrowilhelm"
APP_IMAGE="carbontrace-api"
IMAGE_TAG="v3"

echo "=============================================="
echo " Provisionando infraestrutura CarbonTrace"
echo " Global Solution 2026/1 – FIAP 2TDSPG"
echo "=============================================="

# ---------------------------------------------------------------
# 1. Resource Group
# ---------------------------------------------------------------
echo "[1/6] Criando Resource Group: $RESOURCE_GROUP ($LOCATION)..."
az group create \
  --name "$RESOURCE_GROUP" \
  --location "$LOCATION"

# ---------------------------------------------------------------
# 2. Máquina Virtual Ubuntu 22.04
# ---------------------------------------------------------------
echo "[2/6] Criando VM: $VM_NAME ($VM_SIZE)..."
az vm create \
  --resource-group "$RESOURCE_GROUP" \
  --name "$VM_NAME" \
  --size "$VM_SIZE" \
  --image "$VM_IMAGE" \
  --admin-username "$ADMIN_USER" \
  --admin-password "$ADMIN_PASSWORD" \
  --authentication-type password \
  --public-ip-sku Standard \
  --output table

# ---------------------------------------------------------------
# 3. Abertura de portas (NSG)
#    22   – SSH
#    8080 – CarbonTrace API
#    1521 – Oracle XE
# ---------------------------------------------------------------
echo "[3/6] Abrindo portas 22, 8080 e 1521..."
az vm open-port --resource-group "$RESOURCE_GROUP" --name "$VM_NAME" --port 22   --priority 100
az vm open-port --resource-group "$RESOURCE_GROUP" --name "$VM_NAME" --port 8080 --priority 110
az vm open-port --resource-group "$RESOURCE_GROUP" --name "$VM_NAME" --port 1521 --priority 120

# ---------------------------------------------------------------
# 4. Instalação do Docker na VM via run-command
# ---------------------------------------------------------------
echo "[4/6] Instalando Docker na VM..."
az vm run-command invoke \
  --resource-group "$RESOURCE_GROUP" \
  --name "$VM_NAME" \
  --command-id RunShellScript \
  --scripts "
    apt-get update -y
    apt-get install -y ca-certificates curl gnupg lsb-release git nano
    install -m 0755 -d /etc/apt/keyrings
    curl -fsSL https://download.docker.com/linux/ubuntu/gpg | gpg --dearmor -o /etc/apt/keyrings/docker.gpg
    chmod a+r /etc/apt/keyrings/docker.gpg
    echo \"deb [arch=\$(dpkg --print-architecture) signed-by=/etc/apt/keyrings/docker.gpg] https://download.docker.com/linux/ubuntu \$(lsb_release -cs) stable\" \
      | tee /etc/apt/sources.list.d/docker.list > /dev/null
    apt-get update -y
    apt-get install -y docker-ce docker-ce-cli containerd.io docker-buildx-plugin docker-compose-plugin
    systemctl enable docker
    systemctl start docker
    usermod -aG docker $ADMIN_USER
  "

# ---------------------------------------------------------------
# 5. Criar docker-compose.yml na VM e subir containers
# ---------------------------------------------------------------
echo "[5/6] Criando docker-compose.yml na VM e iniciando containers..."
az vm run-command invoke \
  --resource-group "$RESOURCE_GROUP" \
  --name "$VM_NAME" \
  --command-id RunShellScript \
  --scripts "
    mkdir -p /home/$ADMIN_USER/carbontrace
    cat > /home/$ADMIN_USER/carbontrace/docker-compose.yml << 'COMPOSE'
services:
  oracle-db:
    image: gvenzl/oracle-xe:21-slim
    container_name: oracle-db-rm561378
    environment:
      ORACLE_PASSWORD: \"OracleRoot123\"
      APP_USER: \"carbontrace\"
      APP_USER_PASSWORD: \"carbontrace123\"
    ports:
      - \"1521:1521\"
    volumes:
      - oracle_data:/opt/oracle/oradata
    networks:
      - carbontrace_net
    healthcheck:
      test: [\"CMD\", \"healthcheck.sh\"]
      interval: 30s
      timeout: 20s
      retries: 10
      start_period: 120s
    restart: unless-stopped
  carbontrace-api:
    image: $DOCKERHUB_USER/$APP_IMAGE:$IMAGE_TAG
    container_name: carbontrace-api-rm561378
    ports:
      - \"8080:8080\"
    environment:
      - ConnectionStrings__CarbonTraceOracle=Data Source=oracle-db:1521/XEPDB1;User ID=carbontrace;Password=carbontrace123;
      - ASPNETCORE_ENVIRONMENT=Development
      - ASPNETCORE_URLS=http://+:8080
    depends_on:
      oracle-db:
        condition: service_healthy
    networks:
      - carbontrace_net
    restart: on-failure
volumes:
  oracle_data:
    name: oracle_data_carbontrace
networks:
  carbontrace_net:
    name: carbontrace_net
COMPOSE
    chown $ADMIN_USER:$ADMIN_USER /home/$ADMIN_USER/carbontrace/docker-compose.yml
    cd /home/$ADMIN_USER/carbontrace
    docker compose up -d
  "

# ---------------------------------------------------------------
# 6. Exibir IP público da VM
# ---------------------------------------------------------------
echo "[6/6] Obtendo IP público da VM..."
PUBLIC_IP=$(az vm show \
  --resource-group "$RESOURCE_GROUP" \
  --name "$VM_NAME" \
  --show-details \
  --query publicIps \
  --output tsv)

echo ""
echo "=============================================="
echo " Provisionamento concluído!"
echo " IP Público da VM : $PUBLIC_IP"
echo " Swagger (API)    : http://$PUBLIC_IP:8080"
echo " Oracle           : $PUBLIC_IP:1521"
echo " SSH              : ssh $ADMIN_USER@$PUBLIC_IP"
echo " Senha SSH        : $ADMIN_PASSWORD"
echo "=============================================="
echo ""
echo " Próximos passos:"
echo " 1. Aguarde ~3 minutos para o Oracle XE inicializar"
echo " 2. Acesse o Swagger: http://$PUBLIC_IP:8080"
echo " 3. Teste o CRUD via Swagger UI"
echo " 4. SELECT no Oracle: docker exec -it oracle-db-rm561378 sqlplus carbontrace/carbontrace123@XEPDB1"
echo "=============================================="