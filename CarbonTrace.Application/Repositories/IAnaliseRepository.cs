using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.Repositories;

/// <summary>
/// Contrato de persistência para a entidade <see cref="Analise"/>.
/// </summary>
public interface IAnaliseRepository : IRepository<Analise>
{
    IReadOnlyList<Analise> GetByImagem(Guid idImagem);
}