using CarbonTrace.Application.Repositories;
using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Infrastructure.Persistence.Repositories;

/// <summary>
/// Implementação EF CORE de <see cref="IUsuarioRepository"/>
/// </summary>
public class UsuarioRepository(CarbonTraceContext context) : Repository<Usuario>(context), IUsuarioRepository
{
    /// <inheritdoc />
    public Usuario? GetByEmail(string email)
    {
        return Context.Usuarios
            .FirstOrDefault(u => u.Email == email);
    }

    /// <inheritdoc />
    public bool ExistsByEmail(string email)
    {
        return Context.Usuarios
            .FirstOrDefault(u => u.Email.ToLower() == email.ToLower()) is not null;
    }
}