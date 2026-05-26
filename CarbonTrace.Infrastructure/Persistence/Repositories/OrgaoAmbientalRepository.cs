using CarbonTrace.Application.Repositories;
using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Infrastructure.Persistence.Repositories;

/// <summary>
/// Implementação EF CORE de <see cref="IOrgaoAmbientalRepository"/>
/// </summary>
/// <param name="context"></param>
public class OrgaoAmbientalRepository(CarbonTraceContext context) : Repository<OrgaoAmbiental>(context), IOrgaoAmbientalRepository
{
    /// <inheritdoc />
    public IReadOnlyList<OrgaoAmbiental> GetByEstado(Guid idEstado)
    {
        return Context.OrgaosAmbientais
            .Where(o => o.IdEstado == idEstado)
            .OrderBy(o => o.CreatedAt)
            .ToList();
    }
}