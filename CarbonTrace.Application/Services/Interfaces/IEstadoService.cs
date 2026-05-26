using CarbonTrace.Application.DTOs;

namespace CarbonTrace.Application.Services.Interfaces;

/// <summary>
/// Casos de uso de estado.
/// </summary>
public interface IEstadoService
{
    IReadOnlyList<EstadoResponse> GetAll();
    EstadoResponse? GetById(Guid id);
    EstadoResponse Create(EstadoRequest request);
    EstadoResponse? Update(Guid id, EstadoRequest request);
    
    bool Delete(Guid id);
}