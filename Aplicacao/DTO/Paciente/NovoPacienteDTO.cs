using Aplicacao.DTO.Convenio;
using Aplicacao.Validacoes;
using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.DTO.Paciente;

public class NovoPacienteDTO
{
    [Required(ErrorMessage = "O Campo {0} é obrigatório")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O Campo {0} é obrigatório")]
    [StringLength(255, MinimumLength = 2, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
    public string Sobrenome { get; set; }
    [Required(ErrorMessage = "O Campo {0} é obrigatório")]
    [DataNascimento]
    public DateTime DataNascimento { get; set; }
    [Required(ErrorMessage = "O Campo {0} é obrigatório")]
    public Genero Genero { get; set; }
    [Cpf]
    public string? CPF { get; set; }
    [Required(ErrorMessage = "O Campo {0} é obrigatório")]
    [Rg]
    public string RG { get; set; }
    [Required(ErrorMessage = "O Campo {0} é obrigatório")]
    public Estado Estado { get; set; }
    [Required(ErrorMessage = "O Campo {0} é obrigatório")]
    [EmailAddress]
    public string Email { get; set; }
    [Celular]
    public string? Celular { get; set; }
    [TelefoneFixo]
    public string? TelefoneFixo { get; set; }
    [Required(ErrorMessage = "O Campo {0} é obrigatório")]
    public Guid ConvenioId { get; set; }
    public ConvenioDTO? Convenio { get; set; }
    [Required(ErrorMessage = "O Campo {0} é obrigatório")]
    [RegularExpression(@"^\d+$", ErrorMessage = "O campo {0} deve conter apenas números.")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
    public string NumeroCarteirinha { get; set; }
    [Required(ErrorMessage = "O Campo {0} é obrigatório")]
    [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = "O campo {0} deve estar no formato MM/AA.")]
    public string ValidadeCarteirinha { get; set; }
    public bool Status { get; set; } = true;
}
