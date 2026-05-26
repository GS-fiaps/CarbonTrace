using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Repositories;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.Application.Services.Implementations;

/// <summary>
/// Orquestra os casos de uso de imagem satelital.
/// </summary>
public sealed class ImagemSatelitalService(IImagemSatelitalRepository imagemRepository) : IImagemSatelitalService
{
    /// <inheritdoc />
    public IReadOnlyList<ImagemSatelitalResponse> GetAll()
    {
        return imagemRepository.GetAll()
            .Select(ImagemSatelitalResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public ImagemSatelitalResponse? GetById(Guid id)
    {
        var imagem = imagemRepository.GetById(id);
        return imagem is null ? null : ImagemSatelitalResponse.FromDomain(imagem);
    }

    /// <inheritdoc />
    public IReadOnlyList<ImagemSatelitalResponse> GetByRegiao(Guid idRegiao)
    {
        return imagemRepository.GetByRegiao(idRegiao)
            .Select(ImagemSatelitalResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public ImagemSatelitalResponse Create(ImagemSatelitalRequest request)
    {
        var imagem = request.ToDomain();
        imagemRepository.Add(imagem);
        return ImagemSatelitalResponse.FromDomain(imagem);
    }

    /// <inheritdoc />
    public ImagemSatelitalResponse? Update(Guid id, ImagemSatelitalRequest request)
    {
        var imagem = imagemRepository.GetById(id);
        if (imagem is null)
            return null;
        imagem.Update(request.DataCaptura, request.ResolucaoMetros, request.UrlImagem);
        imagemRepository.Update(imagem);
        return ImagemSatelitalResponse.FromDomain(imagem);
    }

    /// <inheritdoc />
    public bool Delete(Guid id)
    {
        return imagemRepository.Delete(id);
    }
}