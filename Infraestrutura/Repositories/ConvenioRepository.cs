using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestrutura.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositories;

public class ConvenioRepository(AppDbContext context):Repository<Convenio>(context), IConvenioRepository
{

}
