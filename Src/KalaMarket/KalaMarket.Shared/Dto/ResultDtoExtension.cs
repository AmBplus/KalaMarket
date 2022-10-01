namespace KalaMarket.Shared.Dto;

public static class ResultDtoExtension
{
    public static bool CheckNullObject<T,TObject>(this ResultDto<T> result,TObject ob, string message)
    {
        if (ob != null) return false;
        result.Message = message;
        return true;
    }
}