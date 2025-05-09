using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aplicacao.Validacoes;

public class CelularAttribute : ValidationAttribute
{
    public CelularAttribute()
    {
        ErrorMessage = "O campo {0} deve ser um número de celular válido com 11 dígitos.";
    }

    public override bool IsValid(object value)
    {
        if (value == null || value.ToString() == String.Empty) return true;

        var celular = value.ToString();

        if (string.IsNullOrWhiteSpace(celular))
            return false;

        if (!Regex.IsMatch(celular, @"^\d{11}$"))
            return false;

        return celular[0] != '0' && celular[1] != '0' && celular[2] == '9';
    }

    public override string FormatErrorMessage(string name)
    {
        return string.Format(ErrorMessageString, name);
    }
}
