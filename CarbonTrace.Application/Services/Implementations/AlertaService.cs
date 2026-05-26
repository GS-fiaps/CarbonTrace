using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Repositories;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.Application.Services.Implementations;

/// <summary>
/// Orquestra os casos de uso de alerta.
/// </summary>
public sealed class AlertaService(IAlertaRepository alertaRepository) : IAlertaService
{
    /// <inheritdoc />
    public IReadOnlyList<AlertaResponse> GetAll()
    {
        return alertaRepository.GetAll()
            .Select(AlertaResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public AlertaResponse? GetById(Guid id)
    {
        var alerta = alertaRepository.GetById(id);
        return alerta is null ? null : AlertaResponse.FromDomain(alerta);
    }

    /// <inheritdoc />
    public IReadOnlyList<AlertaResponse> GetByAnalise(Guid idAnalise)
    {
        return alertaRepository.GetByAnalise(idAnalise)
            .Select(AlertaResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public AlertaResponse Create(AlertaRequest request)
    {
        var alerta = request.ToDomain();
        alertaRepository.Add(alerta);
        return AlertaResponse.FromDomain(alerta);
    }

    /// <inheritdoc />
    public bool Delete(Guid id)
    {
        return alertaRepository.Delete(id);
    }
}