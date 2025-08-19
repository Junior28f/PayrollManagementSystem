using Microsoft.Extensions.Logging;

namespace Infrastructure.Base
{
    public abstract class LoggerBase
    {
        protected readonly ILogger Logger;

        protected LoggerBase(ILogger logger)
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
}