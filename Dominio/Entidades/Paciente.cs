using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades;

public class Paciente
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; } = null!;
    public string Sobrenome { get; set; } = null!;
    public DateTime DataNascimento { get; set; }
    public Genero Genero { get; set; }
    public string? CPF { get; set; }
    public string RG { get; set; } = null!; 
    public Estado Estado { get; set; }
    public string Email { get; set; } = null!;
    public string? Celular { get; set; }
    public string? TelefoneFixo { get; set; }
    public Guid ConvenioId { get; set; }
    public Convenio Convenio { get; set; }
    public string NumeroCarteirinha { get; set; } = null!;
    public string ValidadeCarteirinha { get; set; } = null!;
    public bool Status { get; set; } = true;
}
