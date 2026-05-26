using CarbonTrace.Application.DTOs;

namespace CarbonTrace.Application.Services.Interfaces;

/// <summary>
/// Casos de uso de satélite.
/// </summary>
public interface ISateliteService
{
    IReadOnlyList<SateliteResponse> GetAll();
    SateliteResponse? GetById(Guid id);
    SateliteResponse Create(SateliteRequest request);
    bool Delete(Guid id);
}