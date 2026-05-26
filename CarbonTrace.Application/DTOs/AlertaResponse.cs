using CarbonTrace.Domain.Entities;
using CarbonTrace.Domain.Enum;

namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de resposta para alerta.
/// </summary>
public record AlertaResponse(Guid Id, DateTime DataEmissao, NivelCriticidadeEnum NivelCriticidade, string Descricao, Guid IdAnalise)
{
    /// <summary>
    /// Mapeia <see cref="Alerta"/> para DTO.
    /// </summary>
    public static AlertaResponse FromDomain(Alerta alerta) =>
        new(alerta.Id, alerta.DataEmissao, alerta.NivelCriticidade, alerta.Descricao, alerta.IdAnalise);
}