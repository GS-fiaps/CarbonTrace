using Microsoft.AspNetCore.Mvc;
using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.API.Controllers;

/// <summary>
/// Gerenciamento dos alertas de desmatamento emitidos pelo CarbonTrace.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class AlertaController(IAlertaService alertaService) : ControllerBase
{
    /// <summary>
    /// Lista todos os alertas.
    /// </summary>
    /// <response code="200">Lista retornada.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<AlertaResponse>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(alertaService.GetAll());
    }

    /// <summary>
    /// Obtém um alerta pelo Id.
    /// </summary>
    /// <param name="id">Identificador do alerta.</param>
    /// <response code="200">Encontrado.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(AlertaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var alerta = alertaService.GetById(id);
        if (alerta is null)
            return NotFound();
        return Ok(alerta);
    }

    /// <summary>
    /// Lista alertas por análise.
    /// </summary>
    /// <param name="analiseId">Id da análise.</param>
    /// <response code="200">Lista (pode ser vazia).</response>
    [HttpGet("by-analise/{analiseId:guid}")]
    [ProducesResponseType(typeof(IReadOnlyList<AlertaResponse>), StatusCodes.Status200OK)]
    public IActionResult GetByAnalise(Guid analiseId)
    {
        return Ok(alertaService.GetByAnalise(analiseId));
    }

    /// <summary>
    /// Cria um novo alerta.
    /// </summary>
    /// <param name="request">Dados do alerta.</param>
    /// <response code="201">Alerta criado.</response>
    /// <response code="400">Validação inválida.</response>
    [HttpPost]
    [ProducesResponseType(typeof(AlertaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] AlertaRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var alerta = alertaService.Create(request);
        return Ok(alerta);
    }

    /// <summary>
    /// Atualiza um alerta pelo Id.
    /// </summary>
    /// <param name="id">Identificador do alerta.</param>
    /// <param name="request">Dados atualizados.</param>
    /// <response code="200">Atualizado.</response>
    /// <response code="400">Validação inválida.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(AlertaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(Guid id, [FromBody] AlertaRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var alerta = alertaService.Update(id, request);
        if (alerta is null)
            return NotFound();
        return Ok(alerta);
    }
    
    /// <summary>
    /// Remove um alerta pelo Id.
    /// </summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="204">Removido.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        return alertaService.Delete(id) ? NoContent() : NotFound();
    }
}