using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aplicacao.Validacoes;

public class CpfAttribute : ValidationAttribute
{
    public CpfAttribute()
    {
        ErrorMessage = "O campo {0} não é um CPF válido.";
    }

    public override bool IsValid(object value)
    {
        if (value == null || value.ToString() == String.Empty) return true; 

        var cpf = value.ToString()?.Replace(".", "").Replace("-", "");

        if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 || !Regex.IsMatch(cpf, @"^\d{11}$"))
            return false;

        if (new string(cpf[0], cpf.Length) == cpf)
            return false;

        int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCpf = cpf.Substring(0, 9);
        int soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        int resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        string digito = resto.ToString();
        tempCpf += digito;
        soma = 0;

        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito += resto.ToString();
        return cpf.EndsWith(digito);
    }

    public override string FormatErrorMessage(string name)
    {
        return string.Format(ErrorMessageString, name);
    }
}
