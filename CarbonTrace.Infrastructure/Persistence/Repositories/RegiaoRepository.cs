using CarbonTrace.Application.Repositories;
using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Infrastructure.Persistence.Repositories;

public sealed class RegiaoRepository(CarbonTraceContext context)
    : Repository<Regiao>(context), IRegiaoRepository
{
    /// <inheritdoc />
    public IReadOnlyList<Regiao> GetByEstado(Guid idEstado)
    {
        return Context.Regioes
            .Where(r => r.IdEstado == idEstado)
            .OrderBy(r => r.CreatedAt)
            .ToList();
    }
}