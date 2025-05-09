using Aplicacao.DTO.Paciente;
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

public class PacienteService(IMapper _mapper, IUnitOfWork _unitOfWork) : IPacienteService
{
    public async Task<PacienteDTO> CreateAsync(NovoPacienteDTO novoPacienteDTO)
    {
        try
        {
            if (string.IsNullOrEmpty(novoPacienteDTO.Celular) && string.IsNullOrEmpty(novoPacienteDTO.TelefoneFixo))
                throw new Exception("Telefone ou Celular deve ser preenchido");

            var pacienteExiste = await _unitOfWork.PacienteRepository.GetAsync(p => p.CPF == novoPacienteDTO.CPF && novoPacienteDTO.CPF != null);
            if (pacienteExiste is not null)
                throw new Exception("Paciente já cadastrado");

            var convenio = await _unitOfWork.ConvenioRepository.GetAsync(c => c.Id == novoPacienteDTO.ConvenioId);
            if (convenio is null)
                throw new Exception("Convenio não localizado");

            var paciente = _mapper.Map<Paciente>(novoPacienteDTO);

            var novoPacienteCadastrado = await _unitOfWork.PacienteRepository.CreateAsync(paciente);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<PacienteDTO>(novoPacienteCadastrado);
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
            var paciente = await _unitOfWork.PacienteRepository.GetAsync(p => p.Id == id);
            if (paciente is null)
                return false;

            paciente.Status = false;

            _unitOfWork.PacienteRepository.Update(paciente);
            await _unitOfWork.CommitAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<IEnumerable<PacienteDTO>> GetAllAsync()
    {
        try
        {
            var listaPacientes = await _unitOfWork.PacienteRepository.GetAllAsync(p => p.Convenio);
            if(listaPacientes is null)
                return new List<PacienteDTO>();

            return _mapper.Map<IEnumerable<PacienteDTO>>(listaPacientes);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<PacienteDTO> GetAsync(Guid id)
    {
        try
        {
            var paciente = await _unitOfWork.PacienteRepository.GetAsync(p => p.Id == id, p => p.Convenio);
            if (paciente is null)
                return null;

            return _mapper.Map<PacienteDTO>(paciente);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<PacienteDTO> GetByCpfAsync(string cpf)
    {
        try
        {
            var paciente = await _unitOfWork.PacienteRepository.GetAsync(p => p.CPF == cpf);
            if (paciente is null)
                return null;

            return _mapper.Map<PacienteDTO>(paciente);

        }
        catch (Exception ex)
        {
            throw;
        }    
    }

    public async Task<PacienteDTO> UpdateAsync(Guid id, AtualizarPacienteDTO atualizarPacienteDTO)
    {
        try
        {
            if (string.IsNullOrEmpty(atualizarPacienteDTO.Celular) && string.IsNullOrEmpty(atualizarPacienteDTO.TelefoneFixo))
                throw new Exception("Telefone ou Celular deve ser preenchido");

            var pacienteAtualizar = await _unitOfWork.PacienteRepository.GetAsync(p => p.Id == atualizarPacienteDTO.Id);
            if (pacienteAtualizar is null)
                throw new Exception("Paciente não localizado");

            var pacienteExiste = await _unitOfWork.PacienteRepository.GetAsync(p => p.CPF == atualizarPacienteDTO.CPF && p.Id != atualizarPacienteDTO.Id);
            if (pacienteExiste is not null)
                throw new Exception("Paciente já cadastrado");

           var convenio = await _unitOfWork.ConvenioRepository.GetAsync(c => c.Id == atualizarPacienteDTO.ConvenioId);
            if (convenio is null)
                throw new Exception("Convenio não localizado");

            var paciente = _mapper.Map(atualizarPacienteDTO, pacienteAtualizar);

            _unitOfWork.PacienteRepository.Update(paciente);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<PacienteDTO>(paciente);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
