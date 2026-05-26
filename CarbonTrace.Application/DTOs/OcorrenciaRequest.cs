using System.ComponentModel.DataAnnotations;
using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de requisição para criação de ocorrência.
/// </summary>
public record OcorrenciaRequest(
    [param: Required(ErrorMessage = "A data da ocorrência é obrigatória")]
    DateTime DataOcorrencia,

    [param: Required(ErrorMessage = "A descrição é obrigatória")]
    [param: StringLength(500, MinimumLength = 10, ErrorMessage = "A descrição deve ter entre 10 e 500 caracteres")]
    string Descricao,

    [param: Required(ErrorMessage = "A área estimada é obrigatória")]
    [param: Range(0.01, double.MaxValue, ErrorMessage = "A área estimada deve ser maior que zero")]
    double AreaEstimadaKm2,

    [param: Required(ErrorMessage = "A região é obrigatória")]
    Guid IdRegiao,

    [param: Required(ErrorMessage = "O usuário é obrigatório")]
    Guid IdUsuario
)
{
    /// <summary>
    /// Constrói a entidade <see cref="Ocorrencia"/>.
    /// </summary>
    public Ocorrencia ToDomain() => new(DataOcorrencia, Descricao.Trim(), AreaEstimadaKm2, IdRegiao, IdUsuario);
}