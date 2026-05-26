using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de resposta para satélite.
/// </summary>
public record SateliteResponse(Guid Id, string Nome, string Agencia, double AltitudeKm, int AnoLancamento)
{
    /// <summary>
    /// Mapeia <see cref="Satelite"/> para DTO.
    /// </summary>
    public static SateliteResponse FromDomain(Satelite satelite) =>
        new(satelite.Id, satelite.Nome, satelite.Agencia, satelite.AltitudeKm, satelite.AnoLancamento);
}