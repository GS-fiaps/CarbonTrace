using CarbonTrace.Application.Repositories;
using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Infrastructure.Persistence.Repositories;

/// <summary>
/// Implementação EF CORE de <see cref="ISateliteRepository"/>
/// </summary>
/// <param name="context"></param>
public class SateliteRepository(CarbonTraceContext context) : Repository<Satelite>(context), ISateliteRepository
{
    /// <inheritdoc />
    public IReadOnlyList<Satelite> GetByAgencia(string agencia)
    {
        return Context.Satelites
            .Where(s => s.Agencia == agencia)
            .OrderBy(s => s.CreatedAt)
            .ToList();
    }
}