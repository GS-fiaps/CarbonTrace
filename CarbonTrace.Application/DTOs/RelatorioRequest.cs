using System.ComponentModel.DataAnnotations;
using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de requisição para criação de relatório.
/// </summary>
public record RelatorioRequest(
    [param: Required(ErrorMessage = "O título é obrigatório")]
    [param: StringLength(300, MinimumLength = 3, ErrorMessage = "O título deve ter entre 3 e 300 caracteres")]
    string Titulo,

    [param: Required(ErrorMessage = "A data de início do período é obrigatória")]
    DateTime PeriodoInicio,

    [param: Required(ErrorMessage = "A data de fim do período é obrigatória")]
    DateTime PeriodoFim,

    [param: Required(ErrorMessage = "O usuário é obrigatório")]
    Guid IdUsuario
)
{
    /// <summary>
    /// Constrói a entidade <see cref="Relatorio"/>.
    /// </summary>
    public Relatorio ToDomain() => new(Titulo.Trim(), PeriodoInicio, PeriodoFim, IdUsuario);
}