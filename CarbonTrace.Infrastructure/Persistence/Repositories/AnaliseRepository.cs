using CarbonTrace.Application.Repositories;
using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Infrastructure.Persistence.Repositories;

public sealed class AnaliseRepository(CarbonTraceContext context)
    : Repository<Analise>(context), IAnaliseRepository
{
    /// <inheritdoc />
    public IReadOnlyList<Analise> GetByImagem(Guid idImagem)
    {
        return Context.Analises
            .Where(a => a.IdImagem == idImagem)
            .OrderBy(a => a.CreatedAt)
            .ToList();
    }
}