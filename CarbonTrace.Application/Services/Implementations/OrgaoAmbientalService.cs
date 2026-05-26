using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Repositories;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.Application.Services.Implementations;

/// <summary>
/// Orquestra os casos de uso de órgão ambiental.
/// </summary>
public sealed class OrgaoAmbientalService(IOrgaoAmbientalRepository orgaoRepository) : IOrgaoAmbientalService
{
    /// <inheritdoc />
    public IReadOnlyList<OrgaoAmbientalResponse> GetAll()
    {
        return orgaoRepository.GetAll()
            .Select(OrgaoAmbientalResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public OrgaoAmbientalResponse? GetById(Guid id)
    {
        var orgao = orgaoRepository.GetById(id);
        return orgao is null ? null : OrgaoAmbientalResponse.FromDomain(orgao);
    }

    /// <inheritdoc />
    public IReadOnlyList<OrgaoAmbientalResponse> GetByEstado(Guid idEstado)
    {
        return orgaoRepository.GetByEstado(idEstado)
            .Select(OrgaoAmbientalResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public OrgaoAmbientalResponse Create(OrgaoAmbientalRequest request)
    {
        var orgao = request.ToDomain();
        orgaoRepository.Add(orgao);
        return OrgaoAmbientalResponse.FromDomain(orgao);
    }

    /// <inheritdoc />
    public bool Delete(Guid id)
    {
        return orgaoRepository.Delete(id);
    }
}