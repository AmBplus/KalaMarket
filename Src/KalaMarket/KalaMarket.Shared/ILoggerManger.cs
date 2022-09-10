

using KalaMarket.Shared.Dto;

namespace KalaMarket.Shared;
/// <summary>
/// Use For Logging in System
/// _V2_
/// </summary>
public interface ILoggerManger 
{

    #region Without Exception
    Task LogInformation(Exception? exception, string? message, params object?[] args);
    Task LogWarning(Exception? exception, string? message, params object?[] args);
    Task LogDebug(Exception? exception, string? message, params object?[] args);
    Task LogError(Exception? exception, string? message, params object?[] args);
    Task LogTrace(Exception? exception, string? message, params object?[] args);
    Task LogCritical(Exception? exception, string? message, params object?[] args);
    #endregion /Without Exception
   
    #region With Exception
    Task LogInformation(string? message, params object?[] args);
    Task LogWarning(string? message, params object?[] args);
    Task LogDebug(string? message, params object?[] args);
    Task LogError(string? message, params object?[] args);
    Task LogTrace(string? message, params object?[] args);
    Task LogCritical(string? message, params object?[] args);
    #endregion /With Exception
    
}
/// <summary>
/// Use For Logging in System
/// _V2_
/// </summary>
public interface ILoggerManger<T> : ILoggerManger where T : class
{
  
}