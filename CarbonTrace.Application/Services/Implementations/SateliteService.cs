using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Repositories;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.Application.Services.Implementations;

/// <summary>
/// Orquestra os casos de uso de satélite.
/// </summary>
public sealed class SateliteService(ISateliteRepository sateliteRepository) : ISateliteService
{
    /// <inheritdoc />
    public IReadOnlyList<SateliteResponse> GetAll()
    {
        return sateliteRepository.GetAll()
            .Select(SateliteResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public SateliteResponse? GetById(Guid id)
    {
        var satelite = sateliteRepository.GetById(id);
        return satelite is null ? null : SateliteResponse.FromDomain(satelite);
    }

    /// <inheritdoc />
    public SateliteResponse Create(SateliteRequest request)
    {
        var satelite = request.ToDomain();
        sateliteRepository.Add(satelite);
        return SateliteResponse.FromDomain(satelite);
    }

    /// <inheritdoc />
    public SateliteResponse? Update(Guid id, SateliteRequest request)
    {
        var satelite = sateliteRepository.GetById(id);
        if (satelite is null)
            return null;
        satelite.Update(request.Nome, request.Agencia, request.AltitudeKm, request.AnoLancamento);
        sateliteRepository.Update(satelite);
        return SateliteResponse.FromDomain(satelite);
    }

    /// <inheritdoc />
    public bool Delete(Guid id)
    {
        return sateliteRepository.Delete(id);
    }
}