using CarbonTrace.Application.DTOs;

namespace CarbonTrace.Application.Services.Interfaces;

/// <summary>
/// Casos de uso de notificação alerta-órgão.
/// </summary>
public interface IAlertaOrgaoService
{
    IReadOnlyList<AlertaOrgaoResponse> GetAll();
    AlertaOrgaoResponse? GetById(Guid id);
    IReadOnlyList<AlertaOrgaoResponse> GetByAlerta(Guid idAlerta);
    IReadOnlyList<AlertaOrgaoResponse> GetByOrgao(Guid idOrgao);
    AlertaOrgaoResponse Create(AlertaOrgaoRequest request);
    bool Delete(Guid id);
}