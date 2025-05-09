using Aplicacao.DTO.Paciente;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aplicacao.DTO.Convenio;

public class ConvenioDTO
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required(ErrorMessage = "O Campo {0} é obrigatório")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
    public string Nome { get; set; }
    [JsonIgnore]
    public ICollection<PacienteDTO> Pacientes { get; set; } = new List<PacienteDTO>();
}
