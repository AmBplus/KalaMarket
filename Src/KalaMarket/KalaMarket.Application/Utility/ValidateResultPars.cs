using FluentValidation.Results;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Utility;

public static class ValidateResultPars
{
    public static bool ValidateResultHasError<T>(this ValidationResult resultValidate, ResultDto<T> result) where T : class
    {
        if (resultValidate.Errors.Count > 0)
        {
            result.Message = resultValidate.Errors.ToStringError();
            return true;
        }
        return false;
    }
    public static bool ValidateResultHasError(this ValidationResult resultValidate, ResultDto result)
    {
        if (resultValidate.Errors.Count > 0)
        {
            result.Message = resultValidate.Errors.ToStringError();
            return true;
        }
        return false;
    }
}