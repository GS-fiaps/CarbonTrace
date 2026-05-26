using System.Reflection;
using Microsoft.OpenApi;

namespace CarbonTrace.Extensions;

/// <summary>
/// Configuração do Swagger/OpenAPI com interface Swagger UI via Swashbuckle.
/// </summary>
public static class SwaggerServiceColletionExtensions
{
    /// <summary>
    /// Adiciona geração de documento OpenAPI e metadados para o Swagger UI.
    /// </summary>
    /// <param name="services">Coleção de serviços.</param>
    /// <param name="configuration">Configuração da aplicação.</param>
    /// <returns>A mesma instância para encadeamento.</returns>
    public static IServiceCollection addCarbonTraceSwagger(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = configuration.GetSection("Swagger:Title").Value ?? "CarbonTrace API",
                Version = configuration.GetSection("Swagger:Version").Value ?? "v1",
                Description = configuration.GetSection("Swagger:Description").Value
                              ?? "API para acompanhamento e análise de emissões de carbono, além dá detecção automatica de áreas desmatadas comparando imagens satelitais ao longo do tempo.",
            });

            var xml = Path.Combine(
                AppContext.BaseDirectory,
                $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"
            );

            if (File.Exists(xml))
                options.IncludeXmlComments(xml, includeControllerXmlComments: true);
        });
        return services;
    }
}