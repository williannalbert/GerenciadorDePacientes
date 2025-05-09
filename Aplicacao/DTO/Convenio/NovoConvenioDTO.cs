using Aplicacao.DTO.Paciente;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.DTO.Convenio;

public class NovoConvenioDTO
{
    [Required(ErrorMessage = "O Campo {0} é obrigatório")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
    public string Nome { get; set; }
}
