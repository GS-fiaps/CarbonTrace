using CarbonTrace.Application.Repositories;
using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Infrastructure.Persistence.Repositories;

public sealed class OcorrenciaRepository(CarbonTraceContext context)
    : Repository<Ocorrencia>(context), IOcorrenciaRepository
{
    /// <inheritdoc />
    public IReadOnlyList<Ocorrencia> GetByRegiao(Guid idRegiao)
    {
        return Context.Ocorrencias
            .Where(o => o.IdRegiao == idRegiao)
            .OrderBy(o => o.CreatedAt)
            .ToList();
    }

    /// <inheritdoc />
    public IReadOnlyList<Ocorrencia> GetByUsuario(Guid idUsuario)
    {
        return Context.Ocorrencias
            .Where(o => o.IdUsuario == idUsuario)
            .OrderBy(o => o.CreatedAt)
            .ToList();
    }
}