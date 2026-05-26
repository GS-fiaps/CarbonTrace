using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.Repositories;

/// <summary>
/// Contrato de persistência para a entidade <see cref="Ocorrencia"/>.
/// </summary>
public interface IOcorrenciaRepository : IRepository<Ocorrencia>
{
    IReadOnlyList<Ocorrencia> GetByRegiao(Guid idRegiao);
    IReadOnlyList<Ocorrencia> GetByUsuario(Guid idUsuario);
}