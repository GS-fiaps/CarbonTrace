using CarbonTrace.Application.DTOs;

namespace CarbonTrace.Application.Services.Interfaces;

/// <summary>
/// Casos de uso de imagem satelital.
/// </summary>
public interface IImagemSatelitalService
{
    IReadOnlyList<ImagemSatelitalResponse> GetAll();
    ImagemSatelitalResponse? GetById(Guid id);
    IReadOnlyList<ImagemSatelitalResponse> GetByRegiao(Guid idRegiao);
    ImagemSatelitalResponse Create(ImagemSatelitalRequest request);
    bool Delete(Guid id);
}