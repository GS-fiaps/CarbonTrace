using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.Repositories;

/// <summary>
/// Contrato de persistência para a entidade <see cref="Usuario"/>.
/// </summary>
public interface IUsuarioRepository : IRepository<Usuario>
{
    Usuario? GetByEmail(string email);
    bool ExistsByEmail(string email);
}