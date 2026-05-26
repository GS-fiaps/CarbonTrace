using System.ComponentModel.DataAnnotations;
using CarbonTrace.Domain.Entities;
using CarbonTrace.Domain.Enum;

namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de requisição para criação de órgão ambiental.
/// </summary>
public record OrgaoAmbientalRequest(
    [param: Required(ErrorMessage = "O nome é obrigatório")]
    [param: StringLength(200, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 200 caracteres")]
    string Nome,

    [param: Required(ErrorMessage = "O tipo é obrigatório")]
    TipoOrgaoEnum Tipo,

    [param: Required(ErrorMessage = "O e-mail de contato é obrigatório")]
    [param: EmailAddress(ErrorMessage = "O e-mail informado é inválido")]
    [param: StringLength(200, ErrorMessage = "O e-mail deve ter no máximo 200 caracteres")]
    string EmailContato,

    [param: Required(ErrorMessage = "O estado é obrigatório")]
    Guid IdEstado
)
{
    /// <summary>
    /// Constrói a entidade <see cref="OrgaoAmbiental"/>.
    /// </summary>
    public OrgaoAmbiental ToDomain() => new(Nome.Trim(), Tipo, EmailContato.Trim().ToLowerInvariant(), IdEstado);
}