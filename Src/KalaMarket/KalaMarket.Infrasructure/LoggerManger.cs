using KalaMarket.Shared;
using Microsoft.Extensions.Logging;
using NLog;
using ILogger = Microsoft.Extensions.Logging.ILogger;


namespace KalaMarket.Infrastructure;

public class LoggerManger<T> :ILoggerManger<T> 
{

    private  NLog.ILogger Logger { get; }
  
    public LoggerManger()
    {
        Logger = LogManager.GetLogger(typeof(T).FullName);
    }
    #region With Exception

    public async Task LogInformation(Exception? exception, string? message, params object?[] args)
        => Logger.Info(exception: exception, message: message, args: args);
   
    
    public async Task LogWarning(Exception? exception, string? message, params object?[] args)
        => Logger.Warn(exception: exception, message: message, args: args);

    public async Task LogDebug(Exception? exception, string? message, params object?[] args)
        => Logger.Debug(exception: exception, message: message, args: args);

    public async Task LogError(Exception? exception, string? message, params object?[] args)
        => Logger.Error(exception: exception, message: message, args: args);

    public async Task LogTrace(Exception? exception, string? message, params object?[] args)
        => Logger.Trace(exception: exception, message: message, args: args);

    public async Task LogCritical(Exception? exception, string? message, params object?[] args)
        => Logger.Fatal(exception: exception, message: message, args: args);


    #endregion /With Exception

    #region Without Exception

    public async Task LogInformation(string? message, params object?[] args)
        => Logger.Info(message: message, args: args);

    public async Task LogWarning(string? message, params object?[] args)
        => Logger.Warn(message: message, args: args);

    public async Task LogDebug(string? message, params object?[] args)
        => Logger.Debug(message: message, args: args);

    public async Task LogError(string? message, params object?[] args)
        => Logger.Error(message: message, args: args);

    public async Task LogTrace(string? message, params object?[] args)
        => Logger.Trace(message: message, args: args);

    public async Task LogCritical(string? message, params object?[] args)
        => Logger.Fatal(message: message, args: args);

    #endregion /Without Exception
}