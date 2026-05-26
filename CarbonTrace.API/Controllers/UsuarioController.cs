using Microsoft.AspNetCore.Mvc;
using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.API.Controllers;

/// <summary>
/// Gerenciamento dos usuários do sistema CarbonTrace.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class UsuarioController(IUsuarioService usuarioService) : ControllerBase
{
    /// <summary>
    /// Lista todos os usuários.
    /// </summary>
    /// <response code="200">Lista retornada.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<UsuarioResponse>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(usuarioService.GetAll());
    }

    /// <summary>
    /// Obtém um usuário pelo Id.
    /// </summary>
    /// <param name="id">Identificador do usuário.</param>
    /// <response code="200">Encontrado.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var usuario = usuarioService.GetById(id);
        if (usuario is null)
            return NotFound();
        return Ok(usuario);
    }

    /// <summary>
    /// Cria um novo usuário.
    /// </summary>
    /// <param name="request">Dados do usuário.</param>
    /// <response code="201">Usuário criado.</response>
    /// <response code="400">Validação inválida.</response>
    [HttpPost]
    [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] UsuarioRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var usuario = usuarioService.Create(request);
        return Ok(usuario);
    }

    /// <summary>
    /// Atualiza um usuário pelo Id.
    /// </summary>
    /// <param name="id">Identificador do usuário.</param>
    /// <param name="request">Dados atualizados.</param>
    /// <response code="200">Atualizado.</response>
    /// <response code="400">Validação inválida.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(Guid id, [FromBody] UsuarioRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var usuario = usuarioService.Update(id, request);
        if (usuario is null)
            return NotFound();
        return Ok(usuario);
    }
    
    /// <summary>
    /// Remove um usuário pelo Id.
    /// </summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="204">Removido.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        return usuarioService.Delete(id) ? NoContent() : NotFound();
    }
}