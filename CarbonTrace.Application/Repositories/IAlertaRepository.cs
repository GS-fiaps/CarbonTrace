using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.Repositories;

/// <summary>
/// Contrato de persistência para a entidade <see cref="Alerta"/>.
/// </summary>
public interface IAlertaRepository : IRepository<Alerta>
{
    IReadOnlyList<Alerta> GetByAnalise(Guid idAnalise);
}