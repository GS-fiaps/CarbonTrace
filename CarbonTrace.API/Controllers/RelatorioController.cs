using Microsoft.AspNetCore.Mvc;
using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.API.Controllers;

/// <summary>
/// Gerenciamento dos relatórios gerados no CarbonTrace.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class RelatorioController(IRelatorioService relatorioService) : ControllerBase
{
    /// <summary>
    /// Lista todos os relatórios.
    /// </summary>
    /// <response code="200">Lista retornada.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<RelatorioResponse>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(relatorioService.GetAll());
    }

    /// <summary>
    /// Obtém um relatório pelo Id.
    /// </summary>
    /// <param name="id">Identificador do relatório.</param>
    /// <response code="200">Encontrado.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(RelatorioResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var relatorio = relatorioService.GetById(id);
        if (relatorio is null)
            return NotFound();
        return Ok(relatorio);
    }

    /// <summary>
    /// Lista relatórios por usuário.
    /// </summary>
    /// <param name="usuarioId">Id do usuário.</param>
    /// <response code="200">Lista (pode ser vazia).</response>
    [HttpGet("by-usuario/{usuarioId:guid}")]
    [ProducesResponseType(typeof(IReadOnlyList<RelatorioResponse>), StatusCodes.Status200OK)]
    public IActionResult GetByUsuario(Guid usuarioId)
    {
        return Ok(relatorioService.GetByUsuario(usuarioId));
    }

    /// <summary>
    /// Cria um novo relatório.
    /// </summary>
    /// <param name="request">Dados do relatório.</param>
    /// <response code="201">Relatório criado.</response>
    /// <response code="400">Validação inválida.</response>
    [HttpPost]
    [ProducesResponseType(typeof(RelatorioResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] RelatorioRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var relatorio = relatorioService.Create(request);
            return Ok(relatorio);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Atualiza um relatório pelo Id.
    /// </summary>
    /// <param name="id">Identificador do relatório.</param>
    /// <param name="request">Dados atualizados.</param>
    /// <response code="200">Atualizado.</response>
    /// <response code="400">Validação inválida.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(RelatorioResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(Guid id, [FromBody] RelatorioRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var relatorio = relatorioService.Update(id, request);
            if (relatorio is null)
                return NotFound();
            return Ok(relatorio);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    /// <summary>
    /// Remove um relatório pelo Id.
    /// </summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="204">Removido.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        return relatorioService.Delete(id) ? NoContent() : NotFound();
    }
}