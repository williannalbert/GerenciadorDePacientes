using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces;

public interface IUnitOfWork
{
    IPacienteRepository PacienteRepository { get; }
    IConvenioRepository ConvenioRepository { get; }
    Task CommitAsync();
}
