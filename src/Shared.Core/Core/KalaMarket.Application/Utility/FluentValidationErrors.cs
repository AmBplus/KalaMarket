using System.Text;
using FluentValidation.Results;

namespace KalaMarket.Application.Utility;

public static class FluentValidationErrors
{
    public static string ToStringError(this List<ValidationFailure> resultValidateErrors)
    {
        var stringBuilder = new StringBuilder();
        foreach (var error in resultValidateErrors) stringBuilder.AppendLine(error.ErrorMessage);
        return stringBuilder.ToString();
    }
}