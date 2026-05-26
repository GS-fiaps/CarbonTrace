using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de resposta para estado.
/// </summary>
public record EstadoResponse(Guid Id, string Nome, string Sigla)
{
    /// <summary>
    /// Mapeia <see cref="Estado"/> para DTO.
    /// </summary>
    public static EstadoResponse FromDomain(Estado estado) =>
        new(estado.Id, estado.Nome, estado.Sigla);
}