using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.Repositories;

/// <summary>
/// Contrato de persistência para a entidade <see cref="ImagemSatelital"/>.
/// </summary>
public interface IImagemSatelitalRepository : IRepository<ImagemSatelital>
{
    IReadOnlyList<ImagemSatelital> GetByRegiao(Guid idRegiao);
    IReadOnlyList<ImagemSatelital> GetBySatelite(Guid idSatelite);
}