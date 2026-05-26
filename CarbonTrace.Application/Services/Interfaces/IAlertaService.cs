using CarbonTrace.Application.DTOs;

namespace CarbonTrace.Application.Services.Interfaces;

/// <summary>
/// Casos de uso de alerta.
/// </summary>
public interface IAlertaService
{
    IReadOnlyList<AlertaResponse> GetAll();
    AlertaResponse? GetById(Guid id);
    IReadOnlyList<AlertaResponse> GetByAnalise(Guid idAnalise);
    AlertaResponse Create(AlertaRequest request);
    bool Delete(Guid id);
}