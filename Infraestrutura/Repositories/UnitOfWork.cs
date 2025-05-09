using Dominio.Interfaces;
using Infraestrutura.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositories;

public class UnitOfWork(AppDbContext _context) : IUnitOfWork
{
    public IPacienteRepository _pacienteRepository;

    public IConvenioRepository _convenioRepository;

    public IPacienteRepository PacienteRepository
    {
        get
        {
            return _pacienteRepository = _pacienteRepository ?? new PacienteRepository(_context);
        }
    }

    public IConvenioRepository ConvenioRepository
    {
        get
        {
            return _convenioRepository = _convenioRepository ?? new ConvenioRepository(_context);
        }
    }
    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
