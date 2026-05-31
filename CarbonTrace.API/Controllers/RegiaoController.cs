using Microsoft.AspNetCore.Mvc;
using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.API.Controllers;

/// <summary>
/// Gerenciamento das regiões monitoradas pelo CarbonTrace.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class RegiaoController(IRegiaoService regiaoService) : ControllerBase
{
    /// <summary>
    /// Lista todas as regiões.
    /// </summary>
    /// <response code="200">Lista retornada.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<RegiaoResponse>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(regiaoService.GetAll());
    }

    /// <summary>
    /// Obtém uma região pelo Id.
    /// </summary>
    /// <param name="id">Identificador da região.</param>
    /// <response code="200">Encontrada.</response>
    /// <response code="404">Não encontrada.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(RegiaoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var regiao = regiaoService.GetById(id);
        if (regiao is null)
            return NotFound();
        return Ok(regiao);
    }

    /// <summary>
    /// Lista regiões por estado.
    /// </summary>
    /// <param name="estadoId">Id do estado.</param>
    /// <response code="200">Lista (pode ser vazia).</response>
    [HttpGet("by-estado/{estadoId:guid}")]
    [ProducesResponseType(typeof(IReadOnlyList<RegiaoResponse>), StatusCodes.Status200OK)]
    public IActionResult GetByEstado(Guid estadoId)
    {
        return Ok(regiaoService.GetByEstado(estadoId));
    }

    /// <summary>
    /// Cria uma nova região.
    /// </summary>
    /// <param name="request">Dados da região.</param>
    /// <response code="201">Região criada.</response>
    /// <response code="400">Validação inválida.</response>
    [HttpPost]
    [ProducesResponseType(typeof(RegiaoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] RegiaoRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var regiao = regiaoService.Create(request);
            return Ok(regiao);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Atualiza uma região pelo Id.
    /// </summary>
    /// <param name="id">Identificador da região.</param>
    /// <param name="request">Dados atualizados.</param>
    /// <response code="200">Atualizada.</response>
    /// <response code="400">Validação inválida.</response>
    /// <response code="404">Não encontrada.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(RegiaoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(Guid id, [FromBody] RegiaoRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var regiao = regiaoService.Update(id, request);
            if (regiao is null)
                return NotFound();
            return Ok(regiao);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    /// <summary>
    /// Remove uma região pelo Id.
    /// </summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="204">Removida.</response>
    /// <response code="404">Não encontrada.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        return regiaoService.Delete(id) ? NoContent() : NotFound();
    }
}