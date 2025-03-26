using System.Text.RegularExpressions;

namespace Ambev.GestaoFuncionarios.Common.Validators
{
    public static class DocumentValidator
    {
        public static bool IsValidDocumento(string documento)
        {

            Regex rgOrCpfRegex = new(@"^\d{7,9}$|^\d{11}$", RegexOptions.Compiled);
            if (string.IsNullOrEmpty(documento) && !rgOrCpfRegex.IsMatch(documento))
                return false;

            if (documento.Length == 11)
            {
                return IsValidCPF(documento);
            }
            else if (documento.Length >= 7 || documento.Length <= 10)
            {
                return true;
            }

            return false;
        }

        private static bool IsValidCPF(string cpf)
        {
            // Validação de CPF (formato e dígitos verificadores)
            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            if (cpf.Length != 11 || !long.TryParse(cpf, out _)) return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            tempCpf += digito1;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            return cpf.EndsWith($"{digito1}{digito2}");
        }
    }
}
