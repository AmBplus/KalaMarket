using KalaMarket.Shared;
using NLog;

namespace KalaMarket.Infrastructure;

public class LoggerManger : ILoggerManger
{
    public LoggerManger()
    {
        if (Logger == null) Logger = LogManager.GetCurrentClassLogger();
    }

    protected ILogger Logger { get; set; }

    #region Methods

    #region With Exception

    public async Task LogInformation(Exception? exception, string? message, params object?[] args)
    {
        Logger.Info(exception, message, args);
    }


    public async Task LogWarning(Exception? exception, string? message, params object?[] args)
    {
        Logger.Warn(exception, message, args);
    }

    public async Task LogDebug(Exception? exception, string? message, params object?[] args)
    {
        Logger.Debug(exception, message, args);
    }

    public async Task LogError(Exception? exception, string? message, params object?[] args)
    {
        Logger.Error(exception, message, args);
    }

    public async Task LogTrace(Exception? exception, string? message, params object?[] args)
    {
        Logger.Trace(exception, message, args);
    }

    public async Task LogCritical(Exception? exception, string? message, params object?[] args)
    {
        Logger.Fatal(exception, message, args);
    }

    #endregion /With Exception

    #region Without Exception

    public async Task LogInformation(string? message, params object?[] args)
    {
        Logger.Info(message, args);
    }

    public async Task LogWarning(string? message, params object?[] args)
    {
        Logger.Warn(message, args);
    }

    public async Task LogDebug(string? message, params object?[] args)
    {
        Logger.Debug(message, args);
    }

    public async Task LogError(string? message, params object?[] args)
    {
        Logger.Error(message, args);
    }

    public async Task LogTrace(string? message, params object?[] args)
    {
        Logger.Trace(message, args);
    }

    public async Task LogCritical(string? message, params object?[] args)
    {
        Logger.Fatal(message, args);
    }

    #endregion /Without Exception

    #endregion
}

public class LoggerManger<T> : LoggerManger, ILoggerManger<T> where T : class
{
    public LoggerManger()
    {
        Logger = LogManager.GetLogger(typeof(T).FullName);
    }
}