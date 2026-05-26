using CarbonTrace.Application.DTOs;

namespace CarbonTrace.Application.Services.Interfaces;

/// <summary>
/// Casos de uso de relatório.
/// </summary>
public interface IRelatorioService
{
    IReadOnlyList<RelatorioResponse> GetAll();
    RelatorioResponse? GetById(Guid id);
    IReadOnlyList<RelatorioResponse> GetByUsuario(Guid idUsuario);
    RelatorioResponse Create(RelatorioRequest request);
    bool Delete(Guid id);
}