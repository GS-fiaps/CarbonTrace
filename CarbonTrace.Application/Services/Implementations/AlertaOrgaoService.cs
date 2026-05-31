using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Repositories;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.Application.Services.Implementations;

/// <summary>
/// Orquestra os casos de uso de notificação alerta-órgão.
/// </summary>
public sealed class AlertaOrgaoService(IAlertaOrgaoRepository alertaOrgaoRepository, 
    IAlertaRepository alertaRepository, IOrgaoAmbientalRepository orgaoAmbientalRepository) : IAlertaOrgaoService
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
        if (!alertaRepository.ExistsById(request.IdAlerta))
            throw new InvalidOperationException("Alerta não encontrado.");

        if (!orgaoAmbientalRepository.ExistsById(request.IdOrgao))
            throw new InvalidOperationException("Órgão ambiental não encontrado.");

        var duplicata = alertaOrgaoRepository.GetByAlerta(request.IdAlerta)
            .Any(ao => ao.IdOrgao == request.IdOrgao);
        if (duplicata)
            throw new InvalidOperationException("Este órgão já foi notificado para este alerta.");

        var alertaOrgao = request.ToDomain();
        alertaOrgaoRepository.Add(alertaOrgao);
        return AlertaOrgaoResponse.FromDomain(alertaOrgao);
    }
    
    
    /// <inheritdoc />
    public AlertaOrgaoResponse? Update(Guid id, AlertaOrgaoRequest request)
    {
        var alertaOrgao = alertaOrgaoRepository.GetById(id);
        if (alertaOrgao is null)
            return null;

        if (!alertaRepository.ExistsById(request.IdAlerta))
            throw new InvalidOperationException("Alerta não encontrado.");

        if (!orgaoAmbientalRepository.ExistsById(request.IdOrgao))
            throw new InvalidOperationException("Órgão ambiental não encontrado.");

        alertaOrgao.Update(request.StatusNotificacao);
        alertaOrgaoRepository.Update(alertaOrgao);
        return AlertaOrgaoResponse.FromDomain(alertaOrgao);
    }

    /// <inheritdoc />
    public bool Delete(Guid id)
    {
        return alertaOrgaoRepository.Delete(id);
    }
}