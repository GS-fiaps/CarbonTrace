using CarbonTrace.Application.DTOs;

namespace CarbonTrace.Application.Services.Interfaces;

/// <summary>
/// Casos de uso de análise.
/// </summary>
public interface IAnaliseService
{
    IReadOnlyList<AnaliseResponse> GetAll();
    AnaliseResponse? GetById(Guid id);
    IReadOnlyList<AnaliseResponse> GetByImagem(Guid idImagem);
    AnaliseResponse Create(AnaliseRequest request);
    AnaliseResponse? Update(Guid id, AnaliseRequest request);
    bool Delete(Guid id);
}