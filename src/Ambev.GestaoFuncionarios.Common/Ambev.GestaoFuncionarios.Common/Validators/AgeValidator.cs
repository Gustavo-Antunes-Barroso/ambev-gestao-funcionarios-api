namespace Ambev.GestaoFuncionarios.Common.Validators
{
    public static class AgeValidator
    {
        public static bool IsAdult(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age >= 18;
        }
    }
}
