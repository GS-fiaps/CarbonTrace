using CarbonTrace.Application.Repositories;
using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Infrastructure.Persistence.Repositories;

public sealed class AlertaOrgaoRepository(CarbonTraceContext context)
    : Repository<AlertaOrgao>(context), IAlertaOrgaoRepository
{
    /// <inheritdoc />
    public IReadOnlyList<AlertaOrgao> GetByAlerta(Guid idAlerta)
    {
        return Context.AlertasOrgaos
            .Where(ao => ao.IdAlerta == idAlerta)
            .OrderBy(ao => ao.CreatedAt)
            .ToList();
    }

    /// <inheritdoc />
    public IReadOnlyList<AlertaOrgao> GetByOrgao(Guid idOrgao)
    {
        return Context.AlertasOrgaos
            .Where(ao => ao.IdOrgao == idOrgao)
            .OrderBy(ao => ao.CreatedAt)
            .ToList();
    }
}