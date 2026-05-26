using System.ComponentModel.DataAnnotations;
using CarbonTrace.Domain.Entities;
using CarbonTrace.Domain.Enum;

namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de requisição para criação de alerta.
/// </summary>
public record AlertaRequest(
    [param: Required(ErrorMessage = "O nível de criticidade é obrigatório")]
    NivelCriticidadeEnum NivelCriticidade,

    [param: Required(ErrorMessage = "A descrição é obrigatória")]
    [param: StringLength(500, MinimumLength = 10, ErrorMessage = "A descrição deve ter entre 10 e 500 caracteres")]
    string Descricao,

    [param: Required(ErrorMessage = "A análise é obrigatória")]
    Guid IdAnalise
)
{
    /// <summary>
    /// Constrói a entidade <see cref="Alerta"/>.
    /// </summary>
    public Alerta ToDomain() => new(DateTime.UtcNow, NivelCriticidade, Descricao.Trim(), IdAnalise);
}