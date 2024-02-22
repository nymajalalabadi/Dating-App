namespace Application.Extensions.Common
{
    public static class DateExtention
    {
        public static int CalculateAge(this DateTime date)
        {
            var today = DateTime.Today;

            var age = today.Year - date.Year;

            if (date.Date > today.AddYears(-1)) age--;

            return age;
        }
    }

}
