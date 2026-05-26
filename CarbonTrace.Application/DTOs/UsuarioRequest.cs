using System.ComponentModel.DataAnnotations;
using CarbonTrace.Domain.Entities;
using CarbonTrace.Domain.Enum;

namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de requisição para criação de usuário.
/// </summary>
public record UsuarioRequest(
    [param: Required(ErrorMessage = "O nome é obrigatório")]
    [param: StringLength(150, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 150 caracteres")]
    string Nome,

    [param: Required(ErrorMessage = "O e-mail é obrigatório")]
    [param: EmailAddress(ErrorMessage = "O e-mail informado é inválido")]
    [param: StringLength(200, ErrorMessage = "O e-mail deve ter no máximo 200 caracteres")]
    string Email,

    [param: Required(ErrorMessage = "A senha é obrigatória")]
    [param: StringLength(255, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 255 caracteres")]
    string Senha,

    [param: Required(ErrorMessage = "O tipo de usuário é obrigatório")]
    TipoUsuarioEnum TipoUsuario
)
{
    /// <summary>
    /// Constrói a entidade <see cref="Usuario"/>.
    /// </summary>
    public Usuario ToDomain() => new(Nome.Trim(), Email.Trim().ToLowerInvariant(), Senha, TipoUsuario);
}