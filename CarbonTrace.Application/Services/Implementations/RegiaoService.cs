using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Repositories;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.Application.Services.Implementations;

/// <summary>
/// Orquestra os casos de uso de região.
/// </summary>
public sealed class RegiaoService(IRegiaoRepository regiaoRepository, IEstadoRepository estadoRepository) : IRegiaoService
{
    /// <inheritdoc />
    public IReadOnlyList<RegiaoResponse> GetAll()
    {
        return regiaoRepository.GetAll()
            .Select(RegiaoResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public RegiaoResponse? GetById(Guid id)
    {
        var regiao = regiaoRepository.GetById(id);
        return regiao is null ? null : RegiaoResponse.FromDomain(regiao);
    }

    /// <inheritdoc />
    public IReadOnlyList<RegiaoResponse> GetByEstado(Guid idEstado)
    {
        return regiaoRepository.GetByEstado(idEstado)
            .Select(RegiaoResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public RegiaoResponse Create(RegiaoRequest request)
    {
        if (!estadoRepository.ExistsById(request.IdEstado))
            throw new InvalidOperationException("Estado não encontrado.");

        var regiao = request.ToDomain();
        regiaoRepository.Add(regiao);
        return RegiaoResponse.FromDomain(regiao);
    }
    
    /// <inheritdoc />
    public RegiaoResponse? Update(Guid id, RegiaoRequest request)
    {
        var regiao = regiaoRepository.GetById(id);
        if (regiao is null)
            return null;

        if (!estadoRepository.ExistsById(request.IdEstado))
            throw new InvalidOperationException("Estado não encontrado.");

        regiao.Update(request.Nome, request.Latitude, request.Longitude, request.AreaKm2);
        regiaoRepository.Update(regiao);
        return RegiaoResponse.FromDomain(regiao);
    }

    /// <inheritdoc />
    public bool Delete(Guid id)
    {
        return regiaoRepository.Delete(id);
    }
}