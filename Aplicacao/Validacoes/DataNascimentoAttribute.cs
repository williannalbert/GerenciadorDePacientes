using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Validacoes;

public class DataNascimentoAttribute : ValidationAttribute
{
    public DataNascimentoAttribute()
    {
        ErrorMessage = "A data de nascimento não pode ser maior que a data atual.";
    }
    public override bool IsValid(object value)
    {
        if (value == null)
            return true; 

        if (value is DateTime dataNascimento)
        {
            return dataNascimento <= DateTime.Now.Date; 
        }

        return false;
    }
}
