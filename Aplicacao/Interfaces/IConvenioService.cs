using Aplicacao.DTO.Convenio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces;

public interface IConvenioService
{
    Task<IEnumerable<ConvenioDTO>> GetAllAsync();
    Task<ConvenioDTO> GetAsync(Guid id);
    Task<ConvenioDTO> GetByNameAsync(string nome);
    Task<ConvenioDTO> CreateAsync(NovoConvenioDTO novoConvenioDTO);
    Task<ConvenioDTO> UpdateAsync(Guid id, ConvenioDTO convenioDTO);
    Task<bool> DeleteAsync(Guid id);
}
