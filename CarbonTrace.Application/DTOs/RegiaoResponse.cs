using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de resposta para região.
/// </summary>
public record RegiaoResponse(Guid Id, string Nome, double Latitude, double Longitude, double AreaKm2, Guid IdEstado)
{
    /// <summary>
    /// Mapeia <see cref="Regiao"/> para DTO.
    /// </summary>
    public static RegiaoResponse FromDomain(Regiao regiao) =>
        new(regiao.Id, regiao.Nome, regiao.Latitude, regiao.Longitude, regiao.AreaKm2, regiao.IdEstado);
}