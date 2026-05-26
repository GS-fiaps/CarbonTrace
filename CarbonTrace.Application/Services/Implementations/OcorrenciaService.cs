using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Repositories;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.Application.Services.Implementations;

/// <summary>
/// Orquestra os casos de uso de ocorrência.
/// </summary>
public sealed class OcorrenciaService(IOcorrenciaRepository ocorrenciaRepository) : IOcorrenciaService
{
    /// <inheritdoc />
    public IReadOnlyList<OcorrenciaResponse> GetAll()
    {
        return ocorrenciaRepository.GetAll()
            .Select(OcorrenciaResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public OcorrenciaResponse? GetById(Guid id)
    {
        var ocorrencia = ocorrenciaRepository.GetById(id);
        return ocorrencia is null ? null : OcorrenciaResponse.FromDomain(ocorrencia);
    }

    /// <inheritdoc />
    public IReadOnlyList<OcorrenciaResponse> GetByRegiao(Guid idRegiao)
    {
        return ocorrenciaRepository.GetByRegiao(idRegiao)
            .Select(OcorrenciaResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public IReadOnlyList<OcorrenciaResponse> GetByUsuario(Guid idUsuario)
    {
        return ocorrenciaRepository.GetByUsuario(idUsuario)
            .Select(OcorrenciaResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public OcorrenciaResponse Create(OcorrenciaRequest request)
    {
        var ocorrencia = request.ToDomain();
        ocorrenciaRepository.Add(ocorrencia);
        return OcorrenciaResponse.FromDomain(ocorrencia);
    }

    /// <inheritdoc />
    public OcorrenciaResponse? Update(Guid id, OcorrenciaRequest request)
    {
        var ocorrencia = ocorrenciaRepository.GetById(id);
        if (ocorrencia is null)
            return null;
        ocorrencia.Update(request.DataOcorrencia, request.Descricao, request.AreaEstimadaKm2);
        ocorrenciaRepository.Update(ocorrencia);
        return OcorrenciaResponse.FromDomain(ocorrencia);
    }

    /// <inheritdoc />
    public bool Delete(Guid id)
    {
        return ocorrenciaRepository.Delete(id);
    }
}