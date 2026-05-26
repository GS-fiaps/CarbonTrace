using System.ComponentModel.DataAnnotations;
using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de requisição para criação de região.
/// </summary>
public record RegiaoRequest(
    [param: Required(ErrorMessage = "O nome é obrigatório")]
    [param: StringLength(150, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 150 caracteres")]
    string Nome,

    [param: Required(ErrorMessage = "A latitude é obrigatória")]
    [param: Range(-90, 90, ErrorMessage = "A latitude deve estar entre -90 e 90")]
    double Latitude,

    [param: Required(ErrorMessage = "A longitude é obrigatória")]
    [param: Range(-180, 180, ErrorMessage = "A longitude deve estar entre -180 e 180")]
    double Longitude,

    [param: Required(ErrorMessage = "A área é obrigatória")]
    [param: Range(0.01, double.MaxValue, ErrorMessage = "A área deve ser maior que zero")]
    double AreaKm2,

    [param: Required(ErrorMessage = "O estado é obrigatório")]
    Guid IdEstado
)
{
    /// <summary>
    /// Constrói a entidade <see cref="Regiao"/>.
    /// </summary>
    public Regiao ToDomain() => new(Nome.Trim(), Latitude, Longitude, AreaKm2, IdEstado);
}