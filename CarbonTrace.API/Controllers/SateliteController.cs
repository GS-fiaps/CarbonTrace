using Microsoft.AspNetCore.Mvc;
using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.API.Controllers;

/// <summary>
/// Gerenciamento dos satélites utilizados no monitoramento.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class SateliteController(ISateliteService sateliteService) : ControllerBase
{
    /// <summary>
    /// Lista todos os satélites.
    /// </summary>
    /// <response code="200">Lista retornada.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<SateliteResponse>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(sateliteService.GetAll());
    }

    /// <summary>
    /// Obtém um satélite pelo Id.
    /// </summary>
    /// <param name="id">Identificador do satélite.</param>
    /// <response code="200">Encontrado.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(SateliteResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var satelite = sateliteService.GetById(id);
        if (satelite is null)
            return NotFound();
        return Ok(satelite);
    }

    /// <summary>
    /// Cria um novo satélite.
    /// </summary>
    /// <param name="request">Dados do satélite.</param>
    /// <response code="201">Satélite criado.</response>
    /// <response code="400">Validação inválida.</response>
    [HttpPost]
    [ProducesResponseType(typeof(SateliteResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] SateliteRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var satelite = sateliteService.Create(request);
        return Ok(satelite);
    }

    /// <summary>
    /// Atualiza um satélite pelo Id.
    /// </summary>
    /// <param name="id">Identificador do satélite.</param>
    /// <param name="request">Dados atualizados.</param>
    /// <response code="200">Atualizado.</response>
    /// <response code="400">Validação inválida.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(SateliteResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(Guid id, [FromBody] SateliteRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var satelite = sateliteService.Update(id, request);
        if (satelite is null)
            return NotFound();
        return Ok(satelite);
    }
    
    /// <summary>
    /// Remove um satélite pelo Id.
    /// </summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="204">Removido.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        return sateliteService.Delete(id) ? NoContent() : NotFound();
    }
}