using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades;

public class Convenio
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; }
    public ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();

}
