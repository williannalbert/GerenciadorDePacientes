using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aplicacao.Validacoes;

public class RgAttribute : ValidationAttribute
{
    public RgAttribute()
    {
        ErrorMessage = "O campo {0} não é um RG válido.";
    }

    public override bool IsValid(object value)
    {
        if (value == null) return true;

        var rg = value.ToString()?.Replace(".", "").Replace("-", "").ToUpper();

        if (string.IsNullOrWhiteSpace(rg))
            return false;

        if (!Regex.IsMatch(rg, @"^\d{7,8}[\dX]?$"))
            return false;

        if (new string(rg[0], rg.Length) == rg)
            return false;

        return true;
    }

    public override string FormatErrorMessage(string name)
    {
        return string.Format(ErrorMessageString, name);
    }
}
