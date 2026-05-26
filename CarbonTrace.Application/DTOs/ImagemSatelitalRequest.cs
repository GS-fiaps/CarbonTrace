using System.ComponentModel.DataAnnotations;
using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de requisição para criação de imagem satelital.
/// </summary>
public record ImagemSatelitalRequest(
    [param: Required(ErrorMessage = "A data de captura é obrigatória")]
    DateTime DataCaptura,

    [param: Required(ErrorMessage = "A resolução é obrigatória")]
    [param: Range(0.01, double.MaxValue, ErrorMessage = "A resolução deve ser maior que zero")]
    double ResolucaoMetros,

    [param: Required(ErrorMessage = "A URL da imagem é obrigatória")]
    [param: StringLength(500, ErrorMessage = "A URL deve ter no máximo 500 caracteres")]
    string UrlImagem,

    [param: Required(ErrorMessage = "A região é obrigatória")]
    Guid IdRegiao,

    [param: Required(ErrorMessage = "O satélite é obrigatório")]
    Guid IdSatelite
)
{
    /// <summary>
    /// Constrói a entidade <see cref="ImagemSatelital"/>.
    /// </summary>
    public ImagemSatelital ToDomain() => new(DataCaptura, ResolucaoMetros, UrlImagem.Trim(), IdRegiao, IdSatelite);
}