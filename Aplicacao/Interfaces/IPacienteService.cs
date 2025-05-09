using Aplicacao.DTO.Convenio;
using Aplicacao.DTO.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces;

public interface IPacienteService
{
    Task<IEnumerable<PacienteDTO>> GetAllAsync();
    Task<PacienteDTO> GetAsync(Guid id);
    Task<PacienteDTO> GetByCpfAsync(string cpf);
    Task<PacienteDTO> CreateAsync(NovoPacienteDTO novoPacienteDTO);
    Task<PacienteDTO> UpdateAsync(Guid id, AtualizarPacienteDTO atualizarPacienteDTO);
    Task<bool> DeleteAsync(Guid id);
}
