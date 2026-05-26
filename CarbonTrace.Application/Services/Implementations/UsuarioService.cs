using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Repositories;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.Application.Services.Implementations;

/// <summary>
/// Orquestra os casos de uso de usuário.
/// </summary>
public sealed class UsuarioService(IUsuarioRepository usuarioRepository) : IUsuarioService
{
    /// <inheritdoc />
    public IReadOnlyList<UsuarioResponse> GetAll()
    {
        return usuarioRepository.GetAll()
            .Select(UsuarioResponse.FromDomain)
            .ToList();
    }

    /// <inheritdoc />
    public UsuarioResponse? GetById(Guid id)
    {
        var usuario = usuarioRepository.GetById(id);
        return usuario is null ? null : UsuarioResponse.FromDomain(usuario);
    }

    /// <inheritdoc />
    public UsuarioResponse Create(UsuarioRequest request)
    {
        var usuario = request.ToDomain();
        usuarioRepository.Add(usuario);
        return UsuarioResponse.FromDomain(usuario);
    }

    /// <inheritdoc />
    public UsuarioResponse? Update(Guid id, UsuarioRequest request)
    {
        var usuario = usuarioRepository.GetById(id);
        if (usuario is null)
            return null;
        usuario.Update(request.Nome, request.Email, request.Senha, request.TipoUsuario);
        usuarioRepository.Update(usuario);
        return UsuarioResponse.FromDomain(usuario);
    }

    /// <inheritdoc />
    public bool Delete(Guid id)
    {
        return usuarioRepository.Delete(id);
    }
}