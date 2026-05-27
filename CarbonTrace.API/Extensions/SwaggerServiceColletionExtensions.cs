using System.Reflection;
using Microsoft.OpenApi;

namespace CarbonTrace.API.Extensions;

public static class SwaggerServiceColletionExtensions
{
    public static IServiceCollection AddCarbonTraceSwagger(
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
                              ?? "API para monitoramento de desmatamento via satélite."
            });

            var order = new List<string>
            {
                "Estado",
                "Satelite",
                "Usuario",
                "Regiao",
                "OrgaoAmbiental",
                "ImagemSatelital",
                "Analise",
                "Alerta",
                "Ocorrencia",
                "Relatorio",
                "AlertaOrgao"
            };

            options.TagActionsBy(api =>
            {
                var tag = api.GroupName ?? api.ActionDescriptor.RouteValues["controller"] ?? "Other";
                return [tag];
            });

            options.OrderActionsBy(api =>
            {
                var controller = api.ActionDescriptor.RouteValues["controller"] ?? "";
                var index = order.IndexOf(controller);
                return index == -1
                    ? $"{order.Count}_{controller}"
                    : $"{index:D2}_{controller}";
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