# 🌿 CarbonTrace — Monitoramento de Desmatamento via Satélite

> **Global Solution 2026/1 — FIAP**
> Disciplina: Advanced Business Development with .NET
> 2º Ano — Análise e Desenvolvimento de Sistemas — Turma 2TDSPG

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
TB_ESTADO ──────────── TB_REGIAO
    │                      │
    └── TB_ORGAO_AMBIENTAL  ├── TB_IMAGEM_SATELITAL ── TB_ANALISE ── TB_ALERTA
                           │         │                                    │
                           │    TB_SATELITE                    TB_ALERTA_ORGAO
                           │                                        │
                           ├── TB_OCORRENCIA ── TB_USUARIO ─────────┘
                           └── TB_RELATORIO
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

### Relacionamentos implementados

- `CT_ESTADO` **1:N** `CT_REGIAO`
- `CT_ESTADO` **1:N** `CT_ORGAO_AMBIENTAL`
- `CT_SATELITE` **1:N** `CT_IMAGEM_SATELITAL`
- `CT_REGIAO` **1:N** `CT_IMAGEM_SATELITAL`
- `CT_REGIAO` **1:N** `CT_OCORRENCIA`
- `CT_IMAGEM_SATELITAL` **1:N** `CT_ANALISE`
- `CT_ANALISE` **1:N** `CT_ALERTA`
- `CT_ALERTA` **N:N** `CT_ORGAO_AMBIENTAL` (via `CT_ALERTA_ORGAO`)
- `CT_USUARIO` **1:N** `CT_OCORRENCIA`
- `CT_USUARIO` **1:N** `CT_RELATORIO`

---

## ⚙️ Tecnologias Utilizadas

| Tecnologia | Versão | Uso |
|---|---|---|
| .NET | 10.0 | Framework principal |
| ASP.NET Core | 10.0 | Web API |
| Entity Framework Core | 10.0 | ORM |
| Oracle EF Core | 10.23 | Provider Oracle |
| Oracle Database | FIAP Cloud | Banco de dados |
| Swashbuckle | 10.1 | Swagger/OpenAPI |
| Clean Architecture | — | Padrão arquitetural |

---

## 🚀 Como Executar

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [EF Core Tools](https://docs.microsoft.com/ef/core/cli/dotnet)
- Acesso ao Oracle FIAP

### 1. Clone o repositório

```bash
git clone <URL_DO_REPOSITORIO>
cd CarbonTrace
```

### 2. Configure a connection string

No arquivo `CarbonTrace.API/appsettings.json`, configure suas credenciais Oracle:

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

## 🧪 Exemplos de Teste

### Ordem recomendada para cadastro

Siga esta ordem para evitar erros de FK:

```
1. Estado → 2. Satelite → 3. Usuario → 4. Regiao → 5. OrgaoAmbiental
→ 6. ImagemSatelital → 7. Analise → 8. Alerta → 9. Ocorrencia
→ 10. Relatorio → 11. AlertaOrgao
```

### POST /api/Estado

```json
{
  "nome": "São Paulo",
  "sigla": "SP"
}
```

### POST /api/Satelite

```json
{
  "nome": "Landsat 8",
  "agencia": "NASA",
  "altitudeKm": 705.0,
  "anoLancamento": 2013
}
```

### POST /api/Usuario

```json
{
  "nome": "Carlos Silva",
  "email": "carlos.silva@carbontrace.com",
  "senha": "senha123",
  "tipoUsuario": "ADMIN"
}
```

### POST /api/Regiao

```json
{
  "nome": "Amazônia Central",
  "latitude": -3.465305,
  "longitude": -62.215881,
  "areaKm2": 15420.50,
  "idEstado": "ID_DO_ESTADO_CRIADO"
}
```

### POST /api/OrgaoAmbiental

```json
{
  "nome": "IBAMA Regional Amazonas",
  "tipo": "FEDERAL",
  "emailContato": "ibama.am@ibama.gov.br",
  "idEstado": "ID_DO_ESTADO_CRIADO"
}
```

### POST /api/ImagemSatelital

```json
{
  "dataCaptura": "2024-01-05T00:00:00",
  "resolucaoMetros": 30.0,
  "urlImagem": "https://satelite.carbontrace.com/img/2024/01/regiao1.tif",
  "idRegiao": "ID_DA_REGIAO_CRIADA",
  "idSatelite": "ID_DO_SATELITE_CRIADO"
}
```

### POST /api/Analise

```json
{
  "dataAnalise": "2024-01-06T00:00:00",
  "areaDesmatadaKm2": 125.50,
  "percentualVariacao": 2.30,
  "statusAlerta": "NORMAL",
  "idImagem": "ID_DA_IMAGEM_CRIADA"
}
```

### POST /api/Alerta

```json
{
  "nivelCriticidade": "ALTO",
  "descricao": "Área crítica de desmatamento identificada no sul do Amazonas.",
  "idAnalise": "ID_DA_ANALISE_CRIADA"
}
```

### POST /api/Ocorrencia

```json
{
  "dataOcorrencia": "2024-01-20T00:00:00",
  "descricao": "Queimada identificada próxima à reserva indígena.",
  "areaEstimadaKm2": 45.80,
  "idRegiao": "ID_DA_REGIAO_CRIADA",
  "idUsuario": "ID_DO_USUARIO_CRIADO"
}
```

### POST /api/Relatorio

```json
{
  "titulo": "Relatório de Desmatamento - Janeiro 2024",
  "periodoInicio": "2024-01-01T00:00:00",
  "periodoFim": "2024-01-31T00:00:00",
  "idUsuario": "ID_DO_USUARIO_CRIADO"
}
```

### POST /api/AlertaOrgao

```json
{
  "idAlerta": "ID_DO_ALERTA_CRIADO",
  "idOrgao": "ID_DO_ORGAO_CRIADO",
  "statusNotificacao": "PENDENTE"
}
```

---

## 📁 Estrutura do Projeto

```
CarbonTrace/
├── CarbonTrace.API/
│   ├── Controllers/
│   │   ├── AlertaController.cs
│   │   ├── AlertaOrgaoController.cs
│   │   ├── AnaliseController.cs
│   │   ├── EstadoController.cs
│   │   ├── ImagemSatelitalController.cs
│   │   ├── OcorrenciaController.cs
│   │   ├── OrgaoAmbientalController.cs
│   │   ├── RegiaoController.cs
│   │   ├── RelatorioController.cs
│   │   ├── SateliteController.cs
│   │   └── UsuarioController.cs
│   ├── Extensions/
│   │   ├── CarbonTraceServiceCollectionExtensions.cs
│   │   └── SwaggerServiceCollectionExtensions.cs
│   ├── appsettings.json
│   └── Program.cs
│
├── CarbonTrace.Application/
│   ├── DTOs/
│   │   ├── AlertaRequest.cs / AlertaResponse.cs
│   │   ├── AlertaOrgaoRequest.cs / AlertaOrgaoResponse.cs
│   │   ├── AnaliseRequest.cs / AnaliseResponse.cs
│   │   ├── EstadoRequest.cs / EstadoResponse.cs
│   │   ├── ImagemSatelitalRequest.cs / ImagemSatelitalResponse.cs
│   │   ├── OcorrenciaRequest.cs / OcorrenciaResponse.cs
│   │   ├── OrgaoAmbientalRequest.cs / OrgaoAmbientalResponse.cs
│   │   ├── RegiaoRequest.cs / RegiaoResponse.cs
│   │   ├── RelatorioRequest.cs / RelatorioResponse.cs
│   │   ├── SateliteRequest.cs / SateliteResponse.cs
│   │   └── UsuarioRequest.cs / UsuarioResponse.cs
│   ├── Repositories/
│   │   └── (interfaces de repositório)
│   └── Services/
│       ├── Implementations/
│       └── Interfaces/
│
├── CarbonTrace.Domain/
│   ├── Common/
│   │   └── BaseEntity.cs
│   ├── Entities/
│   │   ├── Alerta.cs
│   │   ├── AlertaOrgao.cs
│   │   ├── Analise.cs
│   │   ├── Estado.cs
│   │   ├── ImagemSatelital.cs
│   │   ├── Ocorrencia.cs
│   │   ├── OrgaoAmbiental.cs
│   │   ├── Regiao.cs
│   │   ├── Relatorio.cs
│   │   ├── Satelite.cs
│   │   └── Usuario.cs
│   └── Enums/
│       ├── NivelCriticidade.cs
│       ├── StatusAlerta.cs
│       ├── StatusNotificacao.cs
│       ├── TipoOrgao.cs
│       └── TipoUsuario.cs
│
└── CarbonTrace.Infrastructure/
    └── Persistence/
        ├── Configurations/
        │   └── (configurações EF Core por entidade)
        ├── Repositories/
        │   ├── Repository.cs (base)
        │   └── (implementações por entidade)
        ├── Migrations/
        ├── CarbonTraceContext.cs
        └── CarbonTraceContextFactory.cs
```

---

## 🔗 Links

| Recurso | Link |
|---|---|
| Repositório GitHub | 🔜 Adicionar link |
| Swagger UI | `http://localhost:5222` |
| Documentação API | `http://localhost:5222/swagger/v1/swagger.json` |
| Vídeo Demonstração | 🔜 Em breve |
| Vídeo Pitch | 🔜 Em breve |

---

> Desenvolvido com 💚 pela equipe CarbonTrace — FIAP 2026
