using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aplicacao.Validacoes;

public class TelefoneFixoAttribute : ValidationAttribute
{
    public TelefoneFixoAttribute()
    {
        ErrorMessage = "O campo {0} não é um número de telefone fixo válido.";
    }

    public override bool IsValid(object value)
    {
        if (value == null || value.ToString() == String.Empty) return true;

        var telefone = value.ToString();

        if (string.IsNullOrWhiteSpace(telefone))
            return false;

        if (!Regex.IsMatch(telefone, @"^\d{10}$"))
            return false;

        return telefone[0] != '0' && telefone[1] != '0' && telefone[2] != '9';
    }

    public override string FormatErrorMessage(string name)
    {
        return string.Format(ErrorMessageString, name);
    }
}
