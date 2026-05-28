# Stage 1 — Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /build

COPY CarbonTrace.sln .
COPY CarbonTrace.API/CarbonTrace.API.csproj CarbonTrace.API/
COPY CarbonTrace.Application/CarbonTrace.Application.csproj CarbonTrace.Application/
COPY CarbonTrace.Domain/CarbonTrace.Domain.csproj CarbonTrace.Domain/
COPY CarbonTrace.Infrastructure/CarbonTrace.Infrastructure.csproj CarbonTrace.Infrastructure/

RUN dotnet restore

COPY . .
RUN dotnet publish CarbonTrace.API/CarbonTrace.API.csproj -c Release -o /app/publish

# Stage 2 — Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0

# Labels de documentação da imagem
LABEL maintainer="Pietro Paranhos Wilhelm <rm561378@fiap.com.br>"
LABEL org.opencontainers.image.title="CarbonTrace API"
LABEL org.opencontainers.image.description="API REST para monitoramento de desmatamento via satélite"
LABEL org.opencontainers.image.version="1.0.0"
LABEL org.opencontainers.image.authors="Gabriel Neris Losano, João Vitor Biribilli Ravelli, Pedro de Matos Previtali, Pietro Paranhos Wilhelm, Felipe Monte de Sousa"
LABEL org.opencontainers.image.source="https://github.com/SEU_GRUPO/CarbonTrace"
LABEL fiap.rm="rm561378"
LABEL fiap.turma="2TDSPG"
LABEL fiap.disciplina="DevOps Tools & Cloud Computing"

# Usuário não privilegiado
RUN groupadd --system appgroup && useradd --system --gid appgroup appuser

# Diretório de trabalho
WORKDIR /app

COPY --from=build /app/publish .

RUN chown -R appuser:appgroup /app
USER appuser

# Porta exposta
EXPOSE 8080

ENTRYPOINT ["dotnet", "CarbonTrace.API.dll"]