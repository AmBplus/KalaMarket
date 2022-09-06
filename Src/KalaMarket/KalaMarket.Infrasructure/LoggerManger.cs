using KalaMarket.Shared;


namespace KalaMarket.Infrastructure;

public class LoggerManger : ILoggerManger
{
    private  NLog.ILogger Logger { get; }

    public LoggerManger(NLog.ILogger logger)
    {
        Logger = logger;
    }

    #region With Exception

    public void LogInfo(Exception? exception, string? message, params object?[] args)
        => Logger.Info(exception: exception, message: message, args: args);

    public void LogWarning(Exception? exception, string? message, params object?[] args)
        => Logger.Warn(exception: exception, message: message, args: args);

    public void LogDebug(Exception? exception, string? message, params object?[] args)
        => Logger.Debug(exception: exception, message: message, args: args);

    public void LogError(Exception? exception, string? message, params object?[] args)
        => Logger.Error(exception: exception, message: message, args: args);

    public void LogTrace(Exception? exception, string? message, params object?[] args)
        => Logger.Trace(exception: exception, message: message, args: args);

    public void LogCritical(Exception? exception, string? message, params object?[] args)
        => Logger.Fatal(exception: exception, message: message, args: args);


    #endregion /With Exception

    #region Without Exception

    public void LogInfo(string? message, params object?[] args)
        => Logger.Fatal(message: message, args: args);

    public void LogWarning(string? message, params object?[] args)
        => Logger.Warn(message: message, args: args);

    public void LogDebug(string? message, params object?[] args)
        => Logger.Debug(message: message, args: args);

    public void LogError(string? message, params object?[] args)
        => Logger.Error(message: message, args: args);

    public void LogTrace(string? message, params object?[] args)
        => Logger.Trace(message: message, args: args);

    public void LogCritical(string? message, params object?[] args)
        => Logger.Fatal(message: message, args: args);

    #endregion /Without Exception
}