using CarbonTrace.Domain.Entities;
using CarbonTrace.Domain.Enum;

namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de resposta para análise.
/// </summary>
public record AnaliseResponse(Guid Id, DateTime DataAnalise, double AreaDesmatadaKm2, double PercentualVariacao, StatusAlertaEnum StatusAlerta, Guid IdImagem)
{
    /// <summary>
    /// Mapeia <see cref="Analise"/> para DTO.
    /// </summary>
    public static AnaliseResponse FromDomain(Analise analise) =>
        new(analise.Id, analise.DataAnalise, analise.AreaDesmatadaKm2, analise.PercentualVariacao, analise.StatusAlerta, analise.IdImagem);
}