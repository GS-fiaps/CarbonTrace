using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.Repositories;

/// <summary>
/// Contrato de persistência para a entidade <see cref="OrgaoAmbiental"/>.
/// </summary>
public interface IOrgaoAmbientalRepository : IRepository<OrgaoAmbiental>
{
    IReadOnlyList<OrgaoAmbiental> GetByEstado(Guid idEstado);
}