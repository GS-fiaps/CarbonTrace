using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.Repositories;

/// <summary>
/// Contrato de persistência para a entidade <see cref="Relatorio"/>.
/// </summary>
public interface IRelatorioRepository : IRepository<Relatorio>
{
    IReadOnlyList<Relatorio> GetByUsuario(Guid idUsuario);
}