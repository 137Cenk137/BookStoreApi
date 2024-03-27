namespace WebApi.Services;

public class DbLogger : ILoggerService
{
    public void Write(string value)
    {
        Console.WriteLine("[DB Logger - ]" + value);
    }
}