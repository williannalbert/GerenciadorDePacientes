using Aplicacao.DTO.Paciente;
using AutoMapper;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Mapeamentos;

public class PacienteProfile : Profile
{
    public PacienteProfile()
    {
        CreateMap<PacienteDTO, Paciente>().ReverseMap();
        CreateMap<NovoPacienteDTO, Paciente>().ReverseMap();
        CreateMap<AtualizarPacienteDTO, Paciente>().ReverseMap();
    }
}
