using System.ComponentModel.DataAnnotations;
using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de requisição para criação de estado.
/// </summary>
public record EstadoRequest(
    [param: Required(ErrorMessage = "O nome é obrigatório")]
    [param: StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
    string Nome,

    [param: Required(ErrorMessage = "A sigla é obrigatória")]
    [param: StringLength(2, MinimumLength = 2, ErrorMessage = "A sigla deve ter exatamente 2 caracteres")]
    string Sigla
)
{
    /// <summary>
    /// Constrói a entidade <see cref="Estado"/>.
    /// </summary>
    public Estado ToDomain() => new(Nome.Trim(), Sigla.Trim().ToUpperInvariant());
}