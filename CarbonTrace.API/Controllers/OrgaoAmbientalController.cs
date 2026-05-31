using Microsoft.AspNetCore.Mvc;
using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.API.Controllers;

/// <summary>
/// Gerenciamento dos órgãos ambientais notificados pelo CarbonTrace.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class OrgaoAmbientalController(IOrgaoAmbientalService orgaoService) : ControllerBase
{
    /// <summary>
    /// Lista todos os órgãos ambientais.
    /// </summary>
    /// <response code="200">Lista retornada.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<OrgaoAmbientalResponse>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(orgaoService.GetAll());
    }

    /// <summary>
    /// Obtém um órgão ambiental pelo Id.
    /// </summary>
    /// <param name="id">Identificador do órgão.</param>
    /// <response code="200">Encontrado.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(OrgaoAmbientalResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var orgao = orgaoService.GetById(id);
        if (orgao is null)
            return NotFound();
        return Ok(orgao);
    }

    /// <summary>
    /// Lista órgãos ambientais por estado.
    /// </summary>
    /// <param name="estadoId">Id do estado.</param>
    /// <response code="200">Lista (pode ser vazia).</response>
    [HttpGet("by-estado/{estadoId:guid}")]
    [ProducesResponseType(typeof(IReadOnlyList<OrgaoAmbientalResponse>), StatusCodes.Status200OK)]
    public IActionResult GetByEstado(Guid estadoId)
    {
        return Ok(orgaoService.GetByEstado(estadoId));
    }

    /// <summary>
    /// Cria um novo órgão ambiental.
    /// </summary>
    /// <param name="request">Dados do órgão ambiental.</param>
    /// <response code="201">Órgão criado.</response>
    /// <response code="400">Validação inválida.</response>
    [HttpPost]
    [ProducesResponseType(typeof(OrgaoAmbientalResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] OrgaoAmbientalRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var orgao = orgaoService.Create(request);
            return Ok(orgao);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Atualiza um órgão ambiental pelo Id.
    /// </summary>
    /// <param name="id">Identificador do órgão.</param>
    /// <param name="request">Dados atualizados.</param>
    /// <response code="200">Atualizado.</response>
    /// <response code="400">Validação inválida.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(OrgaoAmbientalResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(Guid id, [FromBody] OrgaoAmbientalRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var orgao = orgaoService.Update(id, request);
            if (orgao is null)
                return NotFound();
            return Ok(orgao);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    /// <summary>
    /// Remove um órgão ambiental pelo Id.
    /// </summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="204">Removido.</response>
    /// <response code="404">Não encontrado.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        return orgaoService.Delete(id) ? NoContent() : NotFound();
    }
}