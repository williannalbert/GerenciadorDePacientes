using Aplicacao.DTO.Paciente;
using Aplicacao.Interfaces;
using Aplicacao.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apresentacao.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PacienteController(IPacienteService _pacienteService) : ControllerBase
{
    [HttpGet("{id:Guid}", Name = "GetPaciente")]
    public async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var pacienteDTO = await _pacienteService.GetAsync(id);
            if (pacienteDTO == null)
                return NotFound();

            return Ok(pacienteDTO);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PacienteDTO>>> GetAll()
    {
        try
        {
            var pacienteDTO = await _pacienteService.GetAllAsync();
            if (pacienteDTO == null || pacienteDTO.Count() == 0)
                return NotFound();
            return Ok(pacienteDTO);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] NovoPacienteDTO novoPacienteDTO)
    {
        try
        {
            if (novoPacienteDTO == null)
                return BadRequest("Dados inválidos");

            var pacienteCadastradoDTO = await _pacienteService.CreateAsync(novoPacienteDTO);

            return CreatedAtRoute("GetPaciente", new { id = pacienteCadastradoDTO.Id }, pacienteCadastradoDTO);
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
            var pacienteExcluido = await _pacienteService.DeleteAsync(id);
            if (!pacienteExcluido)
                return NotFound();

            return NoContent();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    [HttpPut("{id:Guid}")]
    public async Task<ActionResult<PacienteDTO>> Put(Guid id, AtualizarPacienteDTO atualizarPacienteDTO)
    {
        try
        {
            if (id != atualizarPacienteDTO.Id)
                throw new Exception("Ids de Pacientes não correspondem");

            var pacienteAtualizadoDTO = await _pacienteService.UpdateAsync(id, atualizarPacienteDTO);
            return Ok(pacienteAtualizadoDTO);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
