using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CarbonTrace.API.Controllers;

/// <summary>
/// Gerenciamento dos estados brasileiros monitorados pelo CarbonTrace.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class EstadoController(IEstadoService estadoService) : ControllerBase
{
    /// <summary>
    /// Lista todos os estados.
    /// </summary>
    /// <response code="200">Lista retornada.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<EstadoResponse>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(estadoService.GetAll());
    }

    /// <summary>
    /// Obtém um estado pelo Id.
    /// </summary>
    /// <param name="id">Identificador do estado.</param>
    /// <response code="200">Encontrado.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(EstadoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var estado = estadoService.GetById(id);
        if (estado is null)
            return NotFound();
        return Ok(estado);
    }

    /// <summary>
    /// Cria um novo estado.
    /// </summary>
    /// <param name="request">Nome e sigla do estado.</param>
    /// <response code="201">Estado criado.</response>
    /// <response code="400">Validação inválida.</response>
    [HttpPost]
    [ProducesResponseType(typeof(EstadoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] EstadoRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var estado = estadoService.Create(request);
        return Ok(estado);
    }
    
    
    /// <summary>
    /// Atualiza um estado pelo Id.
    /// </summary>
    /// <param name="id">Identificador do estado.</param>
    /// <param name="request">Dados atualizados.</param>
    /// <response code="200">Atualizado.</response>
    /// <response code="400">Validação inválida.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(EstadoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(Guid id, [FromBody] EstadoRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var estado = estadoService.Update(id, request);
        if (estado is null)
            return NotFound();
        return Ok(estado);
    }
    
    /// <summary>
    /// Remove um estado pelo Id.
    /// </summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="204">Removido.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        return estadoService.Delete(id) ? NoContent() : NotFound();
    }
}