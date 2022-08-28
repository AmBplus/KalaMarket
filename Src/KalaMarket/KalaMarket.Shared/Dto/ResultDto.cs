namespace KalaMarket.Shared.Dto;

public class ResultDto
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}
public class ResultDto<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
}
public class ResultListMessageDto<T>
{
    public bool IsSuccess { get; set; }
    public IList<string> Messages { get; set; } 
    public T Data { get; set; }
}