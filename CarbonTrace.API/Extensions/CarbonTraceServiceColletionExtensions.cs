using CarbonTrace.Application.Repositories;
using CarbonTrace.Application.Services.Implementations;
using CarbonTrace.Application.Services.Interfaces;
using CarbonTrace.Infrastructure;
using CarbonTrace.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarbonTrace.API.Extensions;

/// <summary>
/// Extensões para registrar persistência e repositórios do CarbonTrace na injeção de dependências.
/// </summary>
public static class CarbonTraceServiceCollectionExtensions
{
    /// <summary>
    /// Registra o <see cref="CarbonTraceContext"/> com Oracle.
    /// </summary>
    /// <param name="services">Coleção de serviços.</param>
    /// <param name="configuration">Configuração da aplicação.</param>
    /// <returns>A mesma instância para encadeamento.</returns>
    public static IServiceCollection AddCarbonTraceDbContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CarbonTraceOracle")
            ?? configuration.GetConnectionString("OracleConnection")
            ?? throw new InvalidOperationException(
                "Connection string 'CarbonTraceOracle' (ou 'OracleConnection') não encontrada. Configure em appsettings.json ou no ambiente.");

        services.AddDbContext<CarbonTraceContext>(options =>
            options.UseOracle(connectionString));

        return services;
    }

    /// <summary>
    /// Registra todos os repositórios como <c>Scoped</c>.
    /// </summary>
    /// <param name="services">Coleção de serviços.</param>
    /// <returns>A mesma instância para encadeamento.</returns>
    public static IServiceCollection AddCarbonTraceRepositories(
        this IServiceCollection services)
    {
        services.AddScoped<IEstadoRepository, EstadoRepository>();
        services.AddScoped<ISateliteRepository, SateliteRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IRegiaoRepository, RegiaoRepository>();
        services.AddScoped<IOrgaoAmbientalRepository, OrgaoAmbientalRepository>();
        services.AddScoped<IImagemSatelitalRepository, ImagemSatelitalRepository>();
        services.AddScoped<IAnaliseRepository, AnaliseRepository>();
        services.AddScoped<IAlertaRepository, AlertaRepository>();
        services.AddScoped<IOcorrenciaRepository, OcorrenciaRepository>();
        services.AddScoped<IRelatorioRepository, RelatorioRepository>();
        services.AddScoped<IAlertaOrgaoRepository, AlertaOrgaoRepository>();

        return services;
    }

    /// <summary>
    /// Registra todos os serviços de aplicação como <c>Scoped</c>.
    /// </summary>
    /// <param name="services">Coleção de serviços.</param>
    /// <returns>A mesma instância para encadeamento.</returns>
    public static IServiceCollection AddCarbonTraceApplicationServices(
        this IServiceCollection services)
    {
        services.AddScoped<IEstadoService, EstadoService>();
        services.AddScoped<ISateliteService, SateliteService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IRegiaoService, RegiaoService>();
        services.AddScoped<IOrgaoAmbientalService, OrgaoAmbientalService>();
        services.AddScoped<IImagemSatelitalService, ImagemSatelitalService>();
        services.AddScoped<IAnaliseService, AnaliseService>();
        services.AddScoped<IAlertaService, AlertaService>();
        services.AddScoped<IOcorrenciaService, OcorrenciaService>();
        services.AddScoped<IRelatorioService, RelatorioService>();
        services.AddScoped<IAlertaOrgaoService, AlertaOrgaoService>();

        return services;
    }
}