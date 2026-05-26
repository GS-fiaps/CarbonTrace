using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Repositories;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.Application.Services.Implementations;

/// <summary>
/// Orquestra os casos de uso de relatório.
/// </summary>
public sealed class RelatorioService(IRelatorioRepository relatorioRepository) : IRelatorioService
{
    /// <inheritdoc />
    public IReadOnlyList<RelatorioResponse> GetAll()
    {
        return relatorioRepository.GetAll()
            .Select(RelatorioResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public RelatorioResponse? GetById(Guid id)
    {
        var relatorio = relatorioRepository.GetById(id);
        return relatorio is null ? null : RelatorioResponse.FromDomain(relatorio);
    }

    /// <inheritdoc />
    public IReadOnlyList<RelatorioResponse> GetByUsuario(Guid idUsuario)
    {
        return relatorioRepository.GetByUsuario(idUsuario)
            .Select(RelatorioResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public RelatorioResponse Create(RelatorioRequest request)
    {
        var relatorio = request.ToDomain();
        relatorioRepository.Add(relatorio);
        return RelatorioResponse.FromDomain(relatorio);
    }

    /// <inheritdoc />
    public bool Delete(Guid id)
    {
        return relatorioRepository.Delete(id);
    }
}