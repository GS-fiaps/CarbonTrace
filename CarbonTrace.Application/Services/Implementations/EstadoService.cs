using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Repositories;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.Application.Services.Implementations;

/// <summary>
/// Orquestra os casos de uso de estado.
/// </summary>
public sealed class EstadoService(IEstadoRepository estadoRepository) : IEstadoService
{
    /// <inheritdoc />
    public IReadOnlyList<EstadoResponse> GetAll()
    {
        return estadoRepository.GetAll()
            .Select(EstadoResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public EstadoResponse? GetById(Guid id)
    {
        var estado = estadoRepository.GetById(id);
        return estado is null ? null : EstadoResponse.FromDomain(estado);
    }

    /// <inheritdoc />
    public EstadoResponse Create(EstadoRequest request)
    {
        var estado = request.ToDomain();
        estadoRepository.Add(estado);
        return EstadoResponse.FromDomain(estado);
    }

    /// <inheritdoc />
    public bool Delete(Guid id)
    {
        return estadoRepository.Delete(id);
    }
}