# 🌿 CarbonTrace — Monitoramento de Desmatamento via Satélite

> **Global Solution 2026/1 — FIAP**
> Disciplina: Advanced Business Development with .NET | DevOps Tools & Cloud Computing
> 2º Ano — Análise e Desenvolvimento de Sistemas — Turma 2TDSPG

---

## 📑 Sumário

- [👥 Integrantes](#-integrantes)
- [📽️ Vídeos](#️-vídeos)
- [📋 Sobre o Projeto](#-sobre-o-projeto)
- [🔷 .NET — Advanced Business Development](#-net--advanced-business-development)
  - [🏗️ Arquitetura](#️-arquitetura)
  - [🗄️ Banco de Dados e Relacionamentos](#️-banco-de-dados-e-relacionamentos)
  - [⚙️ Tecnologias .NET](#️-tecnologias-net)
  - [📌 Enums](#-enums)
  - [🧪 Exemplos de Teste](#-exemplos-de-teste)
  - [🚀 How To — Executar Localmente (.NET)](#-how-to--executar-localmente-net)
- [🐳 DevOps — Docker & Azure](#-devops--docker--azure)
  - [🏛️ Arquitetura Macro](#️-arquitetura-macro)
  - [⚙️ Tecnologias DevOps](#️-tecnologias-devops)
  - [🐳 How To — Executar com Docker](#-how-to--executar-com-docker)
  - [☁️ How To — Deploy na Azure](#️-how-to--deploy-na-azure)
- [📁 Estrutura do Projeto](#-estrutura-do-projeto)
- [🔗 Links](#-links)

---

## 👥 Integrantes

| Nome | RM | Turma |
|---|---|---|
| Gabriel Neris Losano | RM564093 | 2TDSPG |
| João Vitor Biribilli Ravelli | RM565594 | 2TDSPG |
| Pedro de Matos Previtali | RM564184 | 2TDSPG |
| Pietro Paranhos Wilhelm | RM561378 | 2TDSPG |
| Felipe Monte de Sousa | RM562019 | 2TDSPG |

---

## 📽️ Vídeos

| Tipo | Link |
|---|---|
| Demonstração (máx. 8 min) | 🔜 Em breve |
| Video Pitch (máx. 3 min) | 🔜 Em breve |

---

## 📋 Sobre o Projeto

O **CarbonTrace** é uma API REST desenvolvida em .NET para monitoramento de desmatamento via satélite. A plataforma utiliza dados de imagens satelitais para detectar automaticamente áreas desmatadas, comparando imagens ao longo do tempo e emitindo alertas para órgãos ambientais responsáveis.

### 🎯 Problema Abordado

O Brasil abriga cerca de 60% da Floresta Amazônica, porém enfrenta altos índices de desmatamento ilegal. A falta de monitoramento em tempo real dificulta a ação dos órgãos ambientais, permitindo que grandes áreas sejam devastadas antes de qualquer intervenção.

### 💡 Solução

O CarbonTrace conecta a exploração espacial — através de satélites como Landsat, Sentinel e CBERS — a um problema crítico na Terra, transformando dados orbitais brutos em inteligência ambiental aplicada.

### 🌍 ODS Atendidos

- **ODS 13** — Ação contra a mudança global do clima
- **ODS 15** — Vida terrestre
- **ODS 11** — Cidades e comunidades sustentáveis

---

# 🔷 .NET — Advanced Business Development

---

## 🏗️ Arquitetura

O projeto segue os princípios do **Clean Architecture**, dividido em 4 camadas:

```
CarbonTrace/
├── CarbonTrace.API/              # Controllers, Extensions, Program.cs
├── CarbonTrace.Application/      # DTOs, Repositories (interfaces), Services
├── CarbonTrace.Domain/           # Entities, Enums, Common
└── CarbonTrace.Infrastructure/   # DbContext, Configurations, Repositories (impl), Migrations
```

### Fluxo de Dados

```
Controller → Service → Repository → DbContext → Oracle Database
```

### Por que Clean Architecture?

- **Separação de responsabilidades** — cada camada tem uma responsabilidade clara
- **Testabilidade** — as interfaces permitem mockar dependências
- **Manutenibilidade** — mudanças em uma camada não afetam as outras
- **Independência de framework** — a lógica de negócio não depende do EF Core ou ASP.NET

---

## 🗄️ Banco de Dados e Relacionamentos

### Modelo Relacional

```
CT_ESTADO ──────────── CT_REGIAO
    │                      │
    └── CT_ORGAO_AMBIENTAL  ├── CT_IMAGEM_SATELITAL ── CT_ANALISE ── CT_ALERTA
                           │         │                                    │
                           │    CT_SATELITE                    CT_ALERTA_ORGAO
                           │                                        │
                           ├── CT_OCORRENCIA ── CT_USUARIO ─────────┘
                           └── CT_RELATORIO
```

### Tabelas

| Tabela | Descrição |
|---|---|
| CT_ESTADO | Estados brasileiros monitorados |
| CT_SATELITE | Satélites que capturam as imagens |
| CT_USUARIO | Usuários do sistema (ADMIN, ANALISTA, FISCAL) |
| CT_REGIAO | Regiões monitoradas dentro dos estados |
| CT_ORGAO_AMBIENTAL | Órgãos ambientais que recebem alertas |
| CT_IMAGEM_SATELITAL | Imagens capturadas pelos satélites |
| CT_ANALISE | Análises de desmatamento por imagem |
| CT_ALERTA | Alertas gerados pelas análises |
| CT_OCORRENCIA | Ocorrências reportadas em campo |
| CT_RELATORIO | Relatórios gerenciais gerados |
| CT_ALERTA_ORGAO | Relação N:N entre alertas e órgãos |

### Relacionamentos Implementados

| Relação | Tipo | Comportamento |
|---|---|---|
| CT_ESTADO → CT_REGIAO | 1:N | Cascade Delete |
| CT_ESTADO → CT_ORGAO_AMBIENTAL | 1:N | Cascade Delete |
| CT_SATELITE → CT_IMAGEM_SATELITAL | 1:N | Cascade Delete |
| CT_REGIAO → CT_IMAGEM_SATELITAL | 1:N | Cascade Delete |
| CT_REGIAO → CT_OCORRENCIA | 1:N | Cascade Delete |
| CT_IMAGEM_SATELITAL → CT_ANALISE | 1:N | Cascade Delete |
| CT_ANALISE → CT_ALERTA | 1:N | Cascade Delete |
| CT_ALERTA → CT_ALERTA_ORGAO | N:N | Cascade Delete |
| CT_USUARIO → CT_OCORRENCIA | 1:N | Cascade Delete |
| CT_USUARIO → CT_RELATORIO | 1:N | Cascade Delete |

---

## ⚙️ Tecnologias .NET

| Tecnologia | Versão | Uso |
|---|---|---|
| .NET | 10.0 | Framework principal |
| ASP.NET Core | 10.0 | Web API |
| Entity Framework Core | 10.0 | ORM (Code First) |
| Oracle EF Core | 10.23 | Provider Oracle |
| Oracle Database | FIAP Cloud | Banco de dados |
| Swashbuckle | 10.1 | Swagger/OpenAPI |

---

## 📌 Enums

| Enum | Valores |
|---|---|
| TipoUsuario | `ADMIN` `ANALISTA` `FISCAL` |
| TipoOrgao | `FEDERAL` `ESTADUAL` `MUNICIPAL` `ONG` |
| StatusAlerta | `NORMAL` `ATENCAO` `CRITICO` `EMERGENCIA` |
| NivelCriticidade | `BAIXO` `MEDIO` `ALTO` `CRITICO` |
| StatusNotificacao | `PENDENTE` `ENVIADO` `CONFIRMADO` `FALHA` |

---

## 🧪 Exemplos de Teste

### Ordem recomendada para cadastro

```
1. Estado → 2. Satelite → 3. Usuario → 4. Regiao → 5. OrgaoAmbiental
→ 6. ImagemSatelital → 7. Analise → 8. Alerta → 9. Ocorrencia
→ 10. Relatorio → 11. AlertaOrgao
```

### POST /api/estado

```json
{
  "nome": "São Paulo",
  "sigla": "SP"
}
```

### POST /api/satelite

```json
{
  "nome": "Landsat 8",
  "agencia": "NASA",
  "altitudeKm": 705.0,
  "anoLancamento": 2013
}
```

### POST /api/usuario

```json
{
  "nome": "Carlos Silva",
  "email": "carlos.silva@carbontrace.com",
  "senha": "senha123",
  "tipoUsuario": "ADMIN"
}
```

### POST /api/regiao

```json
{
  "nome": "Amazônia Central",
  "latitude": -3.465305,
  "longitude": -62.215881,
  "areaKm2": 15420.50,
  "idEstado": "ID_DO_ESTADO_CRIADO"
}
```

### POST /api/orgaoambiental

```json
{
  "nome": "IBAMA Regional Amazonas",
  "tipo": "FEDERAL",
  "emailContato": "ibama.am@ibama.gov.br",
  "idEstado": "ID_DO_ESTADO_CRIADO"
}
```

### POST /api/imagemsatelital

```json
{
  "dataCaptura": "2024-01-05T00:00:00",
  "resolucaoMetros": 30.0,
  "urlImagem": "https://satelite.carbontrace.com/img/2024/01/regiao1.tif",
  "idRegiao": "ID_DA_REGIAO_CRIADA",
  "idSatelite": "ID_DO_SATELITE_CRIADO"
}
```

### POST /api/analise

```json
{
  "dataAnalise": "2024-01-06T00:00:00",
  "areaDesmatadaKm2": 125.50,
  "percentualVariacao": 2.30,
  "statusAlerta": "NORMAL",
  "idImagem": "ID_DA_IMAGEM_CRIADA"
}
```

### POST /api/alerta

```json
{
  "nivelCriticidade": "ALTO",
  "descricao": "Área crítica de desmatamento identificada no sul do Amazonas.",
  "idAnalise": "ID_DA_ANALISE_CRIADA"
}
```

### POST /api/ocorrencia

```json
{
  "dataOcorrencia": "2024-01-20T00:00:00",
  "descricao": "Queimada identificada próxima à reserva indígena.",
  "areaEstimadaKm2": 45.80,
  "idRegiao": "ID_DA_REGIAO_CRIADA",
  "idUsuario": "ID_DO_USUARIO_CRIADO"
}
```

### POST /api/relatorio

```json
{
  "titulo": "Relatório de Desmatamento - Janeiro 2024",
  "periodoInicio": "2024-01-01T00:00:00",
  "periodoFim": "2024-01-31T00:00:00",
  "idUsuario": "ID_DO_USUARIO_CRIADO"
}
```

### POST /api/alertaorgao

```json
{
  "idAlerta": "ID_DO_ALERTA_CRIADO",
  "idOrgao": "ID_DO_ORGAO_CRIADO",
  "statusNotificacao": "PENDENTE"
}
```

---

## 🚀 How To — Executar Localmente (.NET)

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [EF Core Tools](https://docs.microsoft.com/ef/core/cli/dotnet)
- Acesso ao Oracle FIAP

### 1. Clone o repositório

```bash
git clone https://github.com/GS-fiaps/CarbonTrace.git
cd CarbonTrace
```

### 2. Configure a connection string

No arquivo `CarbonTrace.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "CarbonTraceOracle": "Data Source=oracle.fiap.com.br:1521/orcl;User ID=SEU_RM;Password=SUA_SENHA;"
  }
}
```

### 3. Aplique as Migrations

```bash
dotnet ef database update --project CarbonTrace.Infrastructure --startup-project CarbonTrace.API
```

### 4. Execute a aplicação

```bash
dotnet run --project CarbonTrace.API
```

### 5. Acesse o Swagger

```
http://localhost:5222
```

---

# 🐳 DevOps — Docker & Azure

---

## 🏛️ Arquitetura Macro

```
┌─────────────────────────────────────────────┐
│              Azure VM (Ubuntu 22.04)        │
│       Standard_B4ls_v2 — africasouthnorth   │
│                                             │
│  ┌──────────────────┐  ┌─────────────────┐  │
│  │  carbontrace-api │  │  oracle-db      │  │
│  │  rm561378        │  │  rm561378       │  │
│  │                  │  │                 │  │
│  │  .NET 10         │  │  Oracle XE 21c  │  │
│  │  porta 8080      │  │  porta 1521     │  │
│  │  appuser         │  │  volume nomeado │  │
│  └────────┬─────────┘  └────────┬────────┘  │
│           │   carbontrace_net   │           │
│           └─────────────────────┘           │
└─────────────────────────────────────────────┘
         ↑                    ↑
    Docker Hub           gvenzl/oracle-xe
  pietrowilhelm/            :21-slim
  carbontrace-api
```

---

## ⚙️ Tecnologias DevOps

| Tecnologia | Versão | Uso |
|---|---|---|
| Docker | — | Conteinerização |
| Docker Compose | — | Orquestração local |
| Oracle XE | 21c slim | Banco em container |
| Azure VM | Standard_B4ls_v2 | Infraestrutura em nuvem |
| Ubuntu | 22.04 | Sistema operacional da VM |
| Docker Hub | — | Registry de imagens |

---

## 🐳 How To — Executar com Docker

### Pré-requisitos

- [Docker Desktop](https://www.docker.com/products/docker-desktop)

### 1. Clone o repositório

```bash
git clone https://github.com/GS-fiaps/CarbonTrace.git
cd CarbonTrace
```

### 2. Build das imagens

```bash
# Build v1
docker build -t carbontrace-api:v1 .

# Build v2
docker build -t carbontrace-api:v2 .

# Build v3
docker build -t carbontrace-api:v3 .

# Verificar usuário não root
docker run --rm --entrypoint whoami carbontrace-api:v1
# Deve retornar: appuser
```

### 3. Subir os containers

```bash
docker compose up --build -d
```

### 4. Verificar status

```bash
# Status dos containers
docker compose ps

# Logs do Oracle (aguardar DATABASE IS READY TO USE!)
docker logs oracle-db-rm561378 -f

# Logs da API (aguardar Now listening on: http://[::]:8080)
docker logs carbontrace-api-rm561378 -f
```

### 5. Verificar tabelas criadas automaticamente

```bash
docker exec -it oracle-db-rm561378 sqlplus carbontrace/carbontrace123@XEPDB1
```

```sql
SELECT table_name FROM user_tables;
```

### 6. Acesse o Swagger

```
http://localhost:8080
```

### 7. Derrubar os containers

```bash
docker compose down
```

---

## ☁️ How To — Deploy na Azure

### Pré-requisitos

- [Azure CLI](https://docs.microsoft.com/cli/azure/install-azure-cli)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- Conta no [Docker Hub](https://hub.docker.com)

### 1. Build e Push para o Docker Hub

```bash
# Login no Docker Hub
docker login

# Build das imagens
docker build -t carbontrace-api:v1 .
docker build -t carbontrace-api:v2 .
docker build -t carbontrace-api:v3 .

# Tag e Push
docker tag carbontrace-api:v1 pietrowilhelm/carbontrace-api:v1
docker tag carbontrace-api:v2 pietrowilhelm/carbontrace-api:v2
docker tag carbontrace-api:v3 pietrowilhelm/carbontrace-api:v3
docker tag carbontrace-api:v3 pietrowilhelm/carbontrace-api:latest

docker push pietrowilhelm/carbontrace-api:v1
docker push pietrowilhelm/carbontrace-api:v2
docker push pietrowilhelm/carbontrace-api:v3
docker push pietrowilhelm/carbontrace-api:latest
```

### 2. Provisionar a VM no Azure

```bash
# Login no Azure
az login

# Executar o script de provisionamento
chmod +x azure-cli.sh
./azure-cli.sh
```

O script executa automaticamente:
- Criação do Resource Group `rg-carbontrace-gs`
- Criação da VM `vm-carbontrace-rm561378` (Standard_B4ls_v2, Ubuntu 22.04, africasouthnorth)
- Abertura das portas 22, 8080 e 1521
- Instalação do Docker
- Deploy dos containers via Docker Compose

### 3. Conectar na VM

```bash
ssh carbontrace@IP_PUBLICO_DA_VM
# Senha: Fiap@20262026
```

### 4. Verificar containers na VM

```bash
cd /home/carbontrace/carbontrace

# Status
docker compose ps

# Logs
docker logs oracle-db-rm561378 --tail 50
docker logs carbontrace-api-rm561378 --tail 50
```

### 5. Evidências obrigatórias

```bash
# Usuário e diretórios da API
docker exec carbontrace-api-rm561378 whoami
docker exec carbontrace-api-rm561378 ls -l
docker exec carbontrace-api-rm561378 pwd

# Usuário e diretórios do Oracle
docker exec oracle-db-rm561378 whoami
docker exec oracle-db-rm561378 ls -l

# Volume nomeado
docker volume ls
```

### 6. SELECT no Oracle para evidenciar persistência

```bash
docker exec -it oracle-db-rm561378 sqlplus carbontrace/carbontrace123@XEPDB1
```

```sql
SELECT table_name FROM user_tables;
SELECT * FROM CT_ESTADO;
SELECT * FROM CT_REGIAO;
```

### 7. CRUD externo via IP público

```bash
# GET
curl http://IP_PUBLICO:8080/api/estado

# POST
curl -X POST http://IP_PUBLICO:8080/api/estado \
  -H "Content-Type: application/json" \
  -d '{"nome": "São Paulo", "sigla": "SP"}'

# PUT
curl -X PUT http://IP_PUBLICO:8080/api/estado/ID_AQUI \
  -H "Content-Type: application/json" \
  -d '{"nome": "São Paulo Atualizado", "sigla": "SP"}'

# DELETE
curl -X DELETE http://IP_PUBLICO:8080/api/estado/ID_AQUI
```

### 8. Acesse o Swagger via IP público

```
http://IP_PUBLICO:8080
```

---

## 📁 Estrutura do Projeto

```
CarbonTrace/
├── Dockerfile
├── docker-compose.yml
├── azure-cli.sh
├── README.md
├── CarbonTrace.API/
│   ├── Controllers/
│   ├── Extensions/
│   ├── appsettings.json
│   └── Program.cs
├── CarbonTrace.Application/
│   ├── DTOs/
│   ├── Repositories/
│   └── Services/
│       ├── Implementations/
│       └── Interfaces/
├── CarbonTrace.Domain/
│   ├── Common/
│   │   └── BaseEntity.cs
│   ├── Entities/
│   └── Enums/
└── CarbonTrace.Infrastructure/
    └── Persistence/
        ├── Configurations/
        ├── Repositories/
        ├── Migrations/
        └── CarbonTraceContext.cs
```

---

## 🔗 Links

| Recurso | Link |
|---|---|
| Repositório GitHub | 🔜 Adicionar link |
| Docker Hub | [pietrowilhelm/carbontrace-api](https://hub.docker.com/r/pietrowilhelm/carbontrace-api) |
| Swagger Local (.NET) | `http://localhost:5222` |
| Swagger Local (Docker) | `http://localhost:8080` |
| Swagger Azure | `http://<IP_PUBLICO_VM>:8080` |
| Vídeo Demonstração | 🔜 Em breve |
| Vídeo Pitch | 🔜 Em breve |

---

> Desenvolvido com 💚 pela equipe CarbonTrace — FIAP 2026
