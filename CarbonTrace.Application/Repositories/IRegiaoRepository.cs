using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.Repositories;

/// <summary>
/// Contrato de persistência para a entidade <see cref="Regiao"/>.
/// </summary>
public interface IRegiaoRepository : IRepository<Regiao>
{
    IReadOnlyList<Regiao> GetByEstado(Guid idEstado);
}