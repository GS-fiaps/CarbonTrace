using System.ComponentModel.DataAnnotations;
using CarbonTrace.Domain.Entities;
using CarbonTrace.Domain.Enum;

namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de requisição para criação de análise.
/// </summary>
public record AnaliseRequest(
    [param: Required(ErrorMessage = "A data de análise é obrigatória")]
    DateTime DataAnalise,

    [param: Required(ErrorMessage = "A área desmatada é obrigatória")]
    [param: Range(0, double.MaxValue, ErrorMessage = "A área desmatada não pode ser negativa")]
    double AreaDesmatadaKm2,

    [param: Required(ErrorMessage = "O percentual de variação é obrigatório")]
    double PercentualVariacao,

    [param: Required(ErrorMessage = "O status do alerta é obrigatório")]
    StatusAlertaEnum StatusAlerta,

    [param: Required(ErrorMessage = "A imagem satelital é obrigatória")]
    Guid IdImagem
)
{
    /// <summary>
    /// Constrói a entidade <see cref="Analise"/>.
    /// </summary>
    public Analise ToDomain() => new(DataAnalise, AreaDesmatadaKm2, PercentualVariacao, StatusAlerta, IdImagem);
}