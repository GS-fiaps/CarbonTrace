using CarbonTrace.Application.Repositories;
using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Infrastructure.Persistence.Repositories;

public sealed class RelatorioRepository(CarbonTraceContext context)
    : Repository<Relatorio>(context), IRelatorioRepository
{
    /// <inheritdoc />
    public IReadOnlyList<Relatorio> GetByUsuario(Guid idUsuario)
    {
        return Context.Relatorios
            .Where(r => r.IdUsuario == idUsuario)
            .OrderBy(r => r.CreatedAt)
            .ToList();
    }
}