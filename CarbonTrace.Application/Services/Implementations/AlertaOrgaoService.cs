using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Repositories;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.Application.Services.Implementations;

/// <summary>
/// Orquestra os casos de uso de notificação alerta-órgão.
/// </summary>
public sealed class AlertaOrgaoService(IAlertaOrgaoRepository alertaOrgaoRepository) : IAlertaOrgaoService
{
    /// <inheritdoc />
    public IReadOnlyList<AlertaOrgaoResponse> GetAll()
    {
        return alertaOrgaoRepository.GetAll()
            .Select(AlertaOrgaoResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public AlertaOrgaoResponse? GetById(Guid id)
    {
        var alertaOrgao = alertaOrgaoRepository.GetById(id);
        return alertaOrgao is null ? null : AlertaOrgaoResponse.FromDomain(alertaOrgao);
    }

    /// <inheritdoc />
    public IReadOnlyList<AlertaOrgaoResponse> GetByAlerta(Guid idAlerta)
    {
        return alertaOrgaoRepository.GetByAlerta(idAlerta)
            .Select(AlertaOrgaoResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public IReadOnlyList<AlertaOrgaoResponse> GetByOrgao(Guid idOrgao)
    {
        return alertaOrgaoRepository.GetByOrgao(idOrgao)
            .Select(AlertaOrgaoResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public AlertaOrgaoResponse Create(AlertaOrgaoRequest request)
    {
        var alertaOrgao = request.ToDomain();
        alertaOrgaoRepository.Add(alertaOrgao);
        return AlertaOrgaoResponse.FromDomain(alertaOrgao);
    }

    /// <inheritdoc />
    public bool Delete(Guid id)
    {
        return alertaOrgaoRepository.Delete(id);
    }
}