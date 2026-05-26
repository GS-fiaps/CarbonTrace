using CarbonTrace.Domain.Entities;
namespace CarbonTrace.Application.Repositories;

/// <summary>
/// Contrato de persistência para a entidade <see cref="Estado"/>.
/// </summary>
public interface IEstadoRepository : IRepository<Estado>
{
    Estado? GetBySigla(string sigla);
}