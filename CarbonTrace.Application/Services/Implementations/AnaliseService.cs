using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Repositories;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.Application.Services.Implementations;

/// <summary>
/// Orquestra os casos de uso de análise.
/// </summary>
public sealed class AnaliseService(IAnaliseRepository analiseRepository) : IAnaliseService
{
    /// <inheritdoc />
    public IReadOnlyList<AnaliseResponse> GetAll()
    {
        return analiseRepository.GetAll()
            .Select(AnaliseResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public AnaliseResponse? GetById(Guid id)
    {
        var analise = analiseRepository.GetById(id);
        return analise is null ? null : AnaliseResponse.FromDomain(analise);
    }

    /// <inheritdoc />
    public IReadOnlyList<AnaliseResponse> GetByImagem(Guid idImagem)
    {
        return analiseRepository.GetByImagem(idImagem)
            .Select(AnaliseResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public AnaliseResponse Create(AnaliseRequest request)
    {
        var analise = request.ToDomain();
        analiseRepository.Add(analise);
        return AnaliseResponse.FromDomain(analise);
    }

    /// <inheritdoc />
    public bool Delete(Guid id)
    {
        return analiseRepository.Delete(id);
    }
}