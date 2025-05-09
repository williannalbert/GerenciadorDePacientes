using Aplicacao.DTO.Convenio;
using AutoMapper;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Mapeamentos;

public class ConvenioProfile : Profile
{
    public ConvenioProfile()
    {
        CreateMap<ConvenioDTO, Convenio>().ReverseMap();
        CreateMap<NovoConvenioDTO, Convenio>().ReverseMap();
    }
}
