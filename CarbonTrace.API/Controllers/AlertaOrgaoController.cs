using Microsoft.AspNetCore.Mvc;
using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.API.Controllers;

/// <summary>
/// Gerenciamento das notificações de alertas para órgãos ambientais.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class AlertaOrgaoController(IAlertaOrgaoService alertaOrgaoService) : ControllerBase
{
    /// <summary>
    /// Lista todas as notificações.
    /// </summary>
    /// <response code="200">Lista retornada.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<AlertaOrgaoResponse>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(alertaOrgaoService.GetAll());
    }

    /// <summary>
    /// Obtém uma notificação pelo Id.
    /// </summary>
    /// <param name="id">Identificador da notificação.</param>
    /// <response code="200">Encontrada.</response>
    /// <response code="404">Não encontrada.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(AlertaOrgaoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var alertaOrgao = alertaOrgaoService.GetById(id);
        if (alertaOrgao is null)
            return NotFound();
        return Ok(alertaOrgao);
    }

    /// <summary>
    /// Lista notificações por alerta.
    /// </summary>
    /// <param name="alertaId">Id do alerta.</param>
    /// <response code="200">Lista (pode ser vazia).</response>
    [HttpGet("by-alerta/{alertaId:guid}")]
    [ProducesResponseType(typeof(IReadOnlyList<AlertaOrgaoResponse>), StatusCodes.Status200OK)]
    public IActionResult GetByAlerta(Guid alertaId)
    {
        return Ok(alertaOrgaoService.GetByAlerta(alertaId));
    }

    /// <summary>
    /// Lista notificações por órgão ambiental.
    /// </summary>
    /// <param name="orgaoId">Id do órgão ambiental.</param>
    /// <response code="200">Lista (pode ser vazia).</response>
    [HttpGet("by-orgao/{orgaoId:guid}")]
    [ProducesResponseType(typeof(IReadOnlyList<AlertaOrgaoResponse>), StatusCodes.Status200OK)]
    public IActionResult GetByOrgao(Guid orgaoId)
    {
        return Ok(alertaOrgaoService.GetByOrgao(orgaoId));
    }

    /// <summary>
    /// Cria uma nova notificação de alerta para um órgão.
    /// </summary>
    /// <param name="request">Dados da notificação.</param>
    /// <response code="201">Notificação criada.</response>
    /// <response code="400">Validação inválida.</response>
    [HttpPost]
    [ProducesResponseType(typeof(AlertaOrgaoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] AlertaOrgaoRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var alertaOrgao = alertaOrgaoService.Create(request);
        return Ok(alertaOrgao);
    }

    /// <summary>
    /// Atualiza uma notificação pelo Id.
    /// </summary>
    /// <param name="id">Identificador da notificação.</param>
    /// <param name="request">Dados atualizados.</param>
    /// <response code="200">Atualizada.</response>
    /// <response code="400">Validação inválida.</response>
    /// <response code="404">Não encontrada.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(AlertaOrgaoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(Guid id, [FromBody] AlertaOrgaoRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var alertaOrgao = alertaOrgaoService.Update(id, request);
        if (alertaOrgao is null)
            return NotFound();
        return Ok(alertaOrgao);
    }
    
    /// <summary>
    /// Remove uma notificação pelo Id.
    /// </summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="204">Removida.</response>
    /// <response code="404">Não encontrada.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        return alertaOrgaoService.Delete(id) ? NoContent() : NotFound();
    }
}