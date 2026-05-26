using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Application.DTOs;

/// <summary>
/// DTO de resposta para imagem satelital.
/// </summary>
public record ImagemSatelitalResponse(Guid Id, DateTime DataCaptura, double ResolucaoMetros, string UrlImagem, Guid IdRegiao, Guid IdSatelite)
{
    /// <summary>
    /// Mapeia <see cref="ImagemSatelital"/> para DTO.
    /// </summary>
    public static ImagemSatelitalResponse FromDomain(ImagemSatelital imagem) =>
        new(imagem.Id, imagem.DataCaptura, imagem.ResolucaoMetros, imagem.UrlImagem, imagem.IdRegiao, imagem.IdSatelite);
}