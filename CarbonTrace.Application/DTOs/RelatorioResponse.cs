using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de resposta para relatório.
/// </summary>
public record RelatorioResponse(Guid Id, string Titulo, DateTime DataGeracao, DateTime PeriodoInicio, DateTime PeriodoFim, Guid IdUsuario)
{
    /// <summary>
    /// Mapeia <see cref="Relatorio"/> para DTO.
    /// </summary>
    public static RelatorioResponse FromDomain(Relatorio relatorio) =>
        new(relatorio.Id, relatorio.Titulo, relatorio.DataGeracao, relatorio.PeriodoInicio, relatorio.PeriodoFim, relatorio.IdUsuario);
}