using CarbonTrace.Application.Repositories;
using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Infrastructure.Persistence.Repositories;

public sealed class AlertaRepository(CarbonTraceContext context)
    : Repository<Alerta>(context), IAlertaRepository
{
    /// <inheritdoc />
    public IReadOnlyList<Alerta> GetByAnalise(Guid idAnalise)
    {
        return Context.Alertas
            .Where(a => a.IdAnalise == idAnalise)
            .OrderBy(a => a.CreatedAt)
            .ToList();
    }
}