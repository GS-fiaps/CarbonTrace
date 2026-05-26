using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.Repositories;

/// <summary>
/// Contrato de persistência para a entidade <see cref="Satelite"/>.
/// </summary>
public interface ISateliteRepository : IRepository<Satelite>
{
    IReadOnlyList<Satelite> GetByAgencia(string agencia);
}