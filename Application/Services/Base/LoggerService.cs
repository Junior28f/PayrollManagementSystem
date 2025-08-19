using Microsoft.Extensions.Logging;

namespace ClassLibrary1.Services.Base;

public abstract  class LoggerService
{
    
    protected readonly ILogger Logger;

    protected LoggerService(ILogger logger)
    {
        Logger = logger;
    }

    protected void LogInformation(string? message, params object[] args)
    {
        Logger?.LogInformation(message ?? string.Empty, args);
    }

    protected void LogError(Exception? exception, string? message, params object[] args)
    {
        Logger?.LogError(exception ?? new Exception("Error desconocido"),
            message ?? "Error", 
            args);
    }

     
    protected void LogWarning(string? message, params object[] args)
    {
        Logger?.LogWarning(message ?? string.Empty, args);
    }

}