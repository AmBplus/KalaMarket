using FluentValidation.Results;
using System.Text;

namespace KalaMarket.Application.User.Validations.Utility;

public static class FluentValidationErrors
{
    public static string ToStringError(this List<ValidationFailure> resultValidateErrors)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var error in resultValidateErrors)
        {
            stringBuilder.AppendLine(error.ErrorMessage);
        }
        return stringBuilder.ToString();
    }
}