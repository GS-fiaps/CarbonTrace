using CarbonTrace.Application.DTOs;

namespace CarbonTrace.Application.Services.Interfaces;

/// <summary>
/// Casos de uso de órgão ambiental.
/// </summary>
public interface IOrgaoAmbientalService
{
    IReadOnlyList<OrgaoAmbientalResponse> GetAll();
    OrgaoAmbientalResponse? GetById(Guid id);
    IReadOnlyList<OrgaoAmbientalResponse> GetByEstado(Guid idEstado);
    OrgaoAmbientalResponse Create(OrgaoAmbientalRequest request);
    OrgaoAmbientalResponse? Update(Guid id, OrgaoAmbientalRequest request);
    bool Delete(Guid id);
}