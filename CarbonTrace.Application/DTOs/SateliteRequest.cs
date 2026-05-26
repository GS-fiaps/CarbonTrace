using System.ComponentModel.DataAnnotations;
using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de requisição para criação de satélite.
/// </summary>
public record SateliteRequest(
    [param: Required(ErrorMessage = "O nome é obrigatório")]
    [param: StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
    string Nome,

    [param: Required(ErrorMessage = "A agência é obrigatória")]
    [param: StringLength(100, MinimumLength = 2, ErrorMessage = "A agência deve ter entre 2 e 100 caracteres")]
    string Agencia,

    [param: Required(ErrorMessage = "A altitude é obrigatória")]
    [param: Range(1, double.MaxValue, ErrorMessage = "A altitude deve ser maior que zero")]
    double AltitudeKm,

    [param: Required(ErrorMessage = "O ano de lançamento é obrigatório")]
    [param: Range(1950, 2100, ErrorMessage = "O ano de lançamento deve estar entre 1950 e 2100")]
    int AnoLancamento
)
{
    /// <summary>
    /// Constrói a entidade <see cref="Satelite"/>.
    /// </summary>
    public Satelite ToDomain() => new(Nome.Trim(), Agencia.Trim(), AltitudeKm, AnoLancamento);
}