using System.ComponentModel.DataAnnotations;

namespace News.BL;

public class DateValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        DateTime? date = value as DateTime?;

        if (date == null)
        {
            return false;
        }
        if (date >= DateTime.Now && date < DateTime.Now.AddDays(7))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
