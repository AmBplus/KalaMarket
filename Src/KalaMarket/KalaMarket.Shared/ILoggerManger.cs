using Microsoft.Extensions.Logging;

namespace KalaMarket.Shared;
/// <summary>
/// Use For Logging in System
/// _V1_
/// </summary>
public interface ILoggerManger
{
  
    void LogInfo(Exception? exception ,string? message, params object?[] args);
    void LogWarning(Exception? exception, string? message, params object?[] args);
    void LogDebug(Exception? exception, string? message, params object?[] args);
    void LogError(Exception? exception, string? message, params object?[] args);
    void LogTrace(Exception? exception, string? message, params object?[] args);
    void LogCritical(Exception? exception, string? message, params object?[] args);
    //
    void LogInfo(string? message, params object?[] args);
    void LogWarning(string? message, params object?[] args);
    void LogDebug(string? message, params object?[] args);
    void LogError(string? message, params object?[] args);
    void LogTrace(string? message, params object?[] args);
    void LogCritical(string? message, params object?[] args);
    //
}