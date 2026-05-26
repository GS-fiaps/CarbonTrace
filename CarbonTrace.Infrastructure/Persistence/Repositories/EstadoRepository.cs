using CarbonTrace.Application.Repositories;
using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Infrastructure.Persistence.Repositories;

/// <summary>
/// Implementação EF CORE de <see cref="IEstadoRepository"/>
/// </summary>
/// <param name="context"></param>
public class EstadoRepository(CarbonTraceContext context) : Repository<Estado>(context), IEstadoRepository
{
    /// <inheritdoc />
    public Estado? GetBySigla(string sigla)
    {
        return Context.Estados
            .FirstOrDefault(e => e.Sigla == sigla);
    }
}