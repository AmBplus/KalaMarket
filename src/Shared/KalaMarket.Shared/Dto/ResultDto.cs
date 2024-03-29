﻿namespace KalaMarket.Shared.Dto;

public class ResultDto
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}

public class ResultDto<T>
{
    public ResultDto(T data)
    {
        Data = data;
    }

    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
}