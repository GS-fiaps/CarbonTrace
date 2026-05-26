using Microsoft.AspNetCore.Mvc;
using CarbonTrace.Application.DTOs;
using CarbonTrace.Application.Services.Interfaces;

namespace CarbonTrace.API.Controllers;

/// <summary>
/// Gerenciamento das imagens satelitais capturadas no CarbonTrace.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class ImagemSatelitalController(IImagemSatelitalService imagemService) : ControllerBase
{
    /// <summary>
    /// Lista todas as imagens satelitais.
    /// </summary>
    /// <response code="200">Lista retornada.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ImagemSatelitalResponse>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(imagemService.GetAll());
    }

    /// <summary>
    /// Obtém uma imagem satelital pelo Id.
    /// </summary>
    /// <param name="id">Identificador da imagem.</param>
    /// <response code="200">Encontrada.</response>
    /// <response code="404">Não encontrada.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ImagemSatelitalResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var imagem = imagemService.GetById(id);
        if (imagem is null)
            return NotFound();
        return Ok(imagem);
    }

    /// <summary>
    /// Lista imagens satelitais por região.
    /// </summary>
    /// <param name="regiaoId">Id da região.</param>
    /// <response code="200">Lista (pode ser vazia).</response>
    [HttpGet("by-regiao/{regiaoId:guid}")]
    [ProducesResponseType(typeof(IReadOnlyList<ImagemSatelitalResponse>), StatusCodes.Status200OK)]
    public IActionResult GetByRegiao(Guid regiaoId)
    {
        return Ok(imagemService.GetByRegiao(regiaoId));
    }

    /// <summary>
    /// Cria uma nova imagem satelital.
    /// </summary>
    /// <param name="request">Dados da imagem satelital.</param>
    /// <response code="201">Imagem criada.</response>
    /// <response code="400">Validação inválida.</response>
    [HttpPost]
    [ProducesResponseType(typeof(ImagemSatelitalResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] ImagemSatelitalRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var imagem = imagemService.Create(request);
        return Ok(imagem);
    }
    
    /// <summary>
    /// Atualiza uma imagem satelital pelo Id.
    /// </summary>
    /// <param name="id">Identificador da imagem.</param>
    /// <param name="request">Dados atualizados.</param>
    /// <response code="200">Atualizada.</response>
    /// <response code="400">Validação inválida.</response>
    /// <response code="404">Não encontrada.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(ImagemSatelitalResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(Guid id, [FromBody] ImagemSatelitalRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var imagem = imagemService.Update(id, request);
        if (imagem is null)
            return NotFound();
        return Ok(imagem);
    }
    
    /// <summary>
    /// Remove uma imagem satelital pelo Id.
    /// </summary>
    /// <param name="id">Identificador único.</param>
    /// <response code="204">Removida.</response>
    /// <response code="404">Não encontrada.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        return imagemService.Delete(id) ? NoContent() : NotFound();
    }
}