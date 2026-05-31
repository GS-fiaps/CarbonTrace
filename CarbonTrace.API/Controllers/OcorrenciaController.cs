using Microsoft.AspNetCore.Mvc;
using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.API.Controllers;

/// <summary>
/// Gerenciamento das ocorrências reportadas em campo no CarbonTrace.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class OcorrenciaController(IOcorrenciaService ocorrenciaService) : ControllerBase
{
    /// <summary>
    /// Lista todas as ocorrências.
    /// </summary>
    /// <response code="200">Lista retornada.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<OcorrenciaResponse>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(ocorrenciaService.GetAll());
    }

    /// <summary>
    /// Obtém uma ocorrência pelo Id.
    /// </summary>
    /// <param name="id">Identificador da ocorrência.</param>
    /// <response code="200">Encontrada.</response>
    /// <response code="404">Não encontrada.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(OcorrenciaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var ocorrencia = ocorrenciaService.GetById(id);
        if (ocorrencia is null)
            return NotFound();
        return Ok(ocorrencia);
    }

    /// <summary>
    /// Lista ocorrências por região.
    /// </summary>
    /// <param name="regiaoId">Id da região.</param>
    /// <response code="200">Lista (pode ser vazia).</response>
    [HttpGet("by-regiao/{regiaoId:guid}")]
    [ProducesResponseType(typeof(IReadOnlyList<OcorrenciaResponse>), StatusCodes.Status200OK)]
    public IActionResult GetByRegiao(Guid regiaoId)
    {
        return Ok(ocorrenciaService.GetByRegiao(regiaoId));
    }

    /// <summary>
    /// Lista ocorrências por usuário.
    /// </summary>
    /// <param name="usuarioId">Id do usuário.</param>
    /// <response code="200">Lista (pode ser vazia).</response>
    [HttpGet("by-usuario/{usuarioId:guid}")]
    [ProducesResponseType(typeof(IReadOnlyList<OcorrenciaResponse>), StatusCodes.Status200OK)]
    public IActionResult GetByUsuario(Guid usuarioId)
    {
        return Ok(ocorrenciaService.GetByUsuario(usuarioId));
    }

    /// <summary>
    /// Cria uma nova ocorrência.
    /// </summary>
    /// <param name="request">Dados da ocorrência.</param>
    /// <response code="201">Ocorrência criada.</response>
    /// <response code="400">Validação inválida.</response>
    [HttpPost]
    [ProducesResponseType(typeof(OcorrenciaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] OcorrenciaRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var ocorrencia = ocorrenciaService.Create(request);
            return Ok(ocorrencia);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Atualiza uma ocorrência pelo Id.
    /// </summary>
    /// <param name="id">Identificador da ocorrência.</param>
    /// <param name="request">Dados atualizados.</param>
    /// <response code="200">Atualizada.</response>
    /// <response code="400">Validação inválida.</response>
    /// <response code="404">Não encontrada.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(OcorrenciaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(Guid id, [FromBody] OcorrenciaRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var ocorrencia = ocorrenciaService.Update(id, request);
            if (ocorrencia is null)
                return NotFound();
            return Ok(ocorrencia);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    /// <summary>
    /// Remove uma ocorrência pelo Id.
    /// </summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="204">Removida.</response>
    /// <response code="404">Não encontrada.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        return ocorrenciaService.Delete(id) ? NoContent() : NotFound();
    }
}