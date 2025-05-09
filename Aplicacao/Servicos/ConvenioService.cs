using Aplicacao.DTO.Convenio;
using Aplicacao.Interfaces;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Servicos;

public class ConvenioService(IMapper _mapper, IUnitOfWork _unitOfWork) : IConvenioService
{
    public async Task<ConvenioDTO> CreateAsync(NovoConvenioDTO novoConvenioDTO)
    {
        try
        {
            var convenioExiste = await _unitOfWork
                .ConvenioRepository
                .GetAsync(c => c.Nome.Trim().ToLower() == novoConvenioDTO.Nome.Trim().ToLower());

            if (convenioExiste is not null)
                throw new Exception("Convênio já cadastrado");

            var convenio = _mapper.Map<Convenio>(novoConvenioDTO);

            var novoConvenioCadastrado = await _unitOfWork.ConvenioRepository.CreateAsync(convenio);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ConvenioDTO>(novoConvenioCadastrado);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            var convenio = await _unitOfWork.ConvenioRepository.GetAsync(c => c.Id == id);
            if (convenio is null)
                return false;

            var pacienteConveniado = await _unitOfWork.PacienteRepository.GetAsync(p => p.ConvenioId == id);
            if (pacienteConveniado is not null)
                throw new Exception("Convênio possui pacientes cadastrados");

            _unitOfWork.ConvenioRepository.Delete(convenio);
            await _unitOfWork.CommitAsync();
            
            return true;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<IEnumerable<ConvenioDTO>> GetAllAsync()
    {
        try
        {
            var listaConvenios = await _unitOfWork.ConvenioRepository.GetAllAsync();
            if (listaConvenios is null)
                return new List<ConvenioDTO>();

            return _mapper.Map<IEnumerable<ConvenioDTO>>(listaConvenios);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<ConvenioDTO> GetAsync(Guid id)
    {
        try
        {
            var convenio = await _unitOfWork.ConvenioRepository.GetAsync(c => c.Id == id);
            if (convenio is null)
                return null;

            return _mapper.Map<ConvenioDTO>(convenio);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<ConvenioDTO> GetByNameAsync(string nome)
    {
        try
        {
            var convenio = await _unitOfWork.ConvenioRepository.GetAsync(c => c.Nome.Trim().ToLower() == nome.Trim().ToLower());
            if (convenio is null)
                return null;

            return _mapper.Map<ConvenioDTO>(convenio);
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public async Task<ConvenioDTO> UpdateAsync(Guid id, ConvenioDTO convenioDTO)
    {
        try
        {
            var convenio = await _unitOfWork.ConvenioRepository.GetAsync(c => c.Id == id);
            if (convenio is null)
                throw new Exception("Convênio não localizado");

            var convenioExiste = await _unitOfWork
                .ConvenioRepository
                .GetAsync(c => c.Nome.Trim().ToLower() == convenioDTO.Nome.Trim().ToLower() && c.Id != convenioDTO.Id);
            if (convenioExiste is not null)
                throw new Exception("Convênio já cadastrado");

            _mapper.Map(convenioDTO, convenio);
            _unitOfWork.ConvenioRepository.Update(convenio);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ConvenioDTO>(convenio);

        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
