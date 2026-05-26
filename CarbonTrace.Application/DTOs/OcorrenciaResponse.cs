using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de resposta para ocorrência.
/// </summary>
public record OcorrenciaResponse(Guid Id, DateTime DataOcorrencia, string Descricao, double AreaEstimadaKm2, Guid IdRegiao, Guid IdUsuario)
{
    /// <summary>
    /// Mapeia <see cref="Ocorrencia"/> para DTO.
    /// </summary>
    public static OcorrenciaResponse FromDomain(Ocorrencia ocorrencia) =>
        new(ocorrencia.Id, ocorrencia.DataOcorrencia, ocorrencia.Descricao, ocorrencia.AreaEstimadaKm2, ocorrencia.IdRegiao, ocorrencia.IdUsuario);
}