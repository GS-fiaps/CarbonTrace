using CarbonTrace.Application.DTOs;

namespace CarbonTrace.Application.Services.Interfaces;

/// <summary>
/// Casos de uso de usuário.
/// </summary>
public interface IUsuarioService
{
    IReadOnlyList<UsuarioResponse> GetAll();
    UsuarioResponse? GetById(Guid id);
    UsuarioResponse Create(UsuarioRequest request);
    UsuarioResponse? Update(Guid id, UsuarioRequest request);
    bool Delete(Guid id);
}