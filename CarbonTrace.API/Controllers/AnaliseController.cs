using Microsoft.AspNetCore.Mvc;
using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.API.Controllers;

/// <summary>
/// Gerenciamento das análises de desmatamento do CarbonTrace.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class AnaliseController(IAnaliseService analiseService) : ControllerBase
{
    /// <summary>
    /// Lista todas as análises.
    /// </summary>
    /// <response code="200">Lista retornada.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<AnaliseResponse>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(analiseService.GetAll());
    }

    /// <summary>
    /// Obtém uma análise pelo Id.
    /// </summary>
    /// <param name="id">Identificador da análise.</param>
    /// <response code="200">Encontrada.</response>
    /// <response code="404">Não encontrada.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(AnaliseResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var analise = analiseService.GetById(id);
        if (analise is null)
            return NotFound();
        return Ok(analise);
    }

    /// <summary>
    /// Lista análises por imagem satelital.
    /// </summary>
    /// <param name="imagemId">Id da imagem satelital.</param>
    /// <response code="200">Lista (pode ser vazia).</response>
    [HttpGet("by-imagem/{imagemId:guid}")]
    [ProducesResponseType(typeof(IReadOnlyList<AnaliseResponse>), StatusCodes.Status200OK)]
    public IActionResult GetByImagem(Guid imagemId)
    {
        return Ok(analiseService.GetByImagem(imagemId));
    }

    /// <summary>
    /// Cria uma nova análise.
    /// </summary>
    /// <param name="request">Dados da análise.</param>
    /// <response code="201">Análise criada.</response>
    /// <response code="400">Validação inválida.</response>
    [HttpPost]
    [ProducesResponseType(typeof(AnaliseResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] AnaliseRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var analise = analiseService.Create(request);
            return Ok(analise);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Atualiza uma análise pelo Id.
    /// </summary>
    /// <param name="id">Identificador da análise.</param>
    /// <param name="request">Dados atualizados.</param>
    /// <response code="200">Atualizada.</response>
    /// <response code="400">Validação inválida.</response>
    /// <response code="404">Não encontrada.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(AnaliseResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(Guid id, [FromBody] AnaliseRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var analise = analiseService.Update(id, request);
            if (analise is null)
                return NotFound();
            return Ok(analise);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    /// <summary>
    /// Remove uma análise pelo Id.
    /// </summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="204">Removida.</response>
    /// <response code="404">Não encontrada.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        return analiseService.Delete(id) ? NoContent() : NotFound();
    }
}