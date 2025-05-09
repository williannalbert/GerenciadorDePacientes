using Aplicacao.DTO.Convenio;
using Aplicacao.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Apresentacao.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ConvenioController(IConvenioService _convenioService) : ControllerBase
{
    [HttpGet("{id:Guid}", Name = "GetConvenio")]
    public async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var convenioDTO = await _convenioService.GetAsync(id);
            if (convenioDTO == null)
                return NotFound();

            return Ok(convenioDTO);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ConvenioDTO>>> GetAll()
    {
        try
        {
            var conveniosDTO = await _convenioService.GetAllAsync();
            if (conveniosDTO == null || conveniosDTO.Count() == 0)
                return NotFound();
            return Ok(conveniosDTO);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] NovoConvenioDTO novoConvenioDTO)
    {
        try
        {
            if (novoConvenioDTO == null)
                return BadRequest("Dados inválidos");

            var convenioCadastradoDTO = await _convenioService.CreateAsync(novoConvenioDTO);

            return CreatedAtRoute("GetConvenio", new { id = convenioCadastradoDTO.Id }, convenioCadastradoDTO);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        try
        {
            var convenioExcluido = await _convenioService.DeleteAsync(id);
            if (!convenioExcluido)
                return NotFound();

            return NoContent();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    [HttpPut("{id:Guid}")]
    public async Task<ActionResult<ConvenioDTO>> Put(Guid id, ConvenioDTO convenioDTO)
    {
        try
        {
            if (id != convenioDTO.Id)
                throw new Exception("Ids de Convênio não correspondem");

            var convenioAtualizadoDTO = await _convenioService.UpdateAsync(id, convenioDTO);
            return Ok(convenioAtualizadoDTO);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
