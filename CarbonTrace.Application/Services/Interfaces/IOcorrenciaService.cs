using CarbonTrace.Application.DTOs;

namespace CarbonTrace.Application.Services.Interfaces;

/// <summary>
/// Casos de uso de ocorrência.
/// </summary>
public interface IOcorrenciaService
{
    IReadOnlyList<OcorrenciaResponse> GetAll();
    OcorrenciaResponse? GetById(Guid id);
    IReadOnlyList<OcorrenciaResponse> GetByRegiao(Guid idRegiao);
    IReadOnlyList<OcorrenciaResponse> GetByUsuario(Guid idUsuario);
    OcorrenciaResponse Create(OcorrenciaRequest request);
    bool Delete(Guid id);
}