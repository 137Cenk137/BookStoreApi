namespace WebApi.Services;

public class ConsoleLogger : ILoggerService
{
    public void Write(string value)
    {
        Console.WriteLine("[Console Logger] - " + value);
    }
}