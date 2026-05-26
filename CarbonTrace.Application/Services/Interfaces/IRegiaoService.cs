using CarbonTrace.Application.DTOs;

namespace CarbonTrace.Application.Services.Interfaces;

/// <summary>
/// Casos de uso de região.
/// </summary>
public interface IRegiaoService
{
    IReadOnlyList<RegiaoResponse> GetAll();
    RegiaoResponse? GetById(Guid id);
    IReadOnlyList<RegiaoResponse> GetByEstado(Guid idEstado);
    RegiaoResponse Create(RegiaoRequest request);
    bool Delete(Guid id);
}