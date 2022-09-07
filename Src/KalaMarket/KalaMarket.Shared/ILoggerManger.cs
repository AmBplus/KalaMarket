

namespace KalaMarket.Shared;
/// <summary>
/// Use For Logging in System
/// _V1_
/// </summary>
public interface ILoggerManger<T>
{
   
    Task LogInformation(Exception? exception ,string? message, params object?[] args);
    Task LogWarning(Exception? exception, string? message, params object?[] args);
    Task LogDebug(Exception? exception, string? message, params object?[] args);
    Task LogError(Exception? exception, string? message, params object?[] args);
    Task LogTrace(Exception? exception, string? message, params object?[] args);
    Task LogCritical(Exception? exception, string? message, params object?[] args);
    //
    Task LogInformation(string? message, params object?[] args);
    Task LogWarning(string? message, params object?[] args);
    Task LogDebug(string? message, params object?[] args);
    Task LogError(string? message, params object?[] args);
    Task LogTrace(string? message, params object?[] args);
    Task LogCritical(string? message, params object?[] args);
    //
}