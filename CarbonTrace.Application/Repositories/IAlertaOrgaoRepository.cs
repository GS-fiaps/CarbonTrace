using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.Repositories;

/// <summary>
/// Contrato de persistência para a entidade <see cref="AlertaOrgao"/>.
/// </summary>
public interface IAlertaOrgaoRepository : IRepository<AlertaOrgao>
{
    IReadOnlyList<AlertaOrgao> GetByAlerta(Guid idAlerta);
    IReadOnlyList<AlertaOrgao> GetByOrgao(Guid idOrgao);
}