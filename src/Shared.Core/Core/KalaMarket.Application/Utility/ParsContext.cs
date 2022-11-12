using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Utility;

public static class ParsContext
{
    public static bool HandleSaveChange(this IKalaMarketContext context, ResultDto result, ILoggerManger logger)
    {
        try
        {
            context.SaveChanges();
            result.IsSuccess = true;
            result.Message = Messages.OperationDoneSuccessfully;
            return true;
        }
        catch (Exception e)
        {
            result.Message = ErrorMessages.ProblemOccurred;
            result.IsSuccess = false;
            logger.LogError(e, e.Message);
        }

        return false;
    }

    public static bool HandleSaveChange<T>(this IKalaMarketContext context, ResultDto<T> result, ILoggerManger logger)
    {
        try
        {
            if (context.SaveChanges() > 0)
            {
                result.IsSuccess = true;
                result.Message = Messages.OperationDoneSuccessfully;
                return true;
            }
        }
        catch (Exception e)
        {
            result.Message = ErrorMessages.ProblemOccurred;
            result.IsSuccess = false;
            logger.LogError(e, e.Message);
        }

        return false;
    }
}