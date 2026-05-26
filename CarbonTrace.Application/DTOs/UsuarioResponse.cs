using CarbonTrace.Domain.Entities;
using CarbonTrace.Domain.Enum;


namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de resposta para usuário.
/// </summary>
public record UsuarioResponse(Guid Id, string Nome, string Email, TipoUsuarioEnum TipoUsuario, DateTime DataCadastro)
{
    /// <summary>
    /// Mapeia <see cref="Usuario"/> para DTO.
    /// </summary>
    public static UsuarioResponse FromDomain(Usuario usuario) =>
        new(usuario.Id, usuario.Nome, usuario.Email, usuario.TipoUsuario, usuario.DataCadastro);
}