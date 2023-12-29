using SimpleEnterpriseFramework.Logger;
using System;
using System.IO;

public class TextFileLogger : ILogger
{
    public void Log(string message)
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Diary.txt");
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"[NORMAL] {DateTime.Now}: {message}");
        }
    }
}

public abstract class LoggerDecorator : ILogger
{
    protected readonly ILogger _logger;

    public LoggerDecorator(ILogger logger)
    {
        _logger = logger;
    }

    public abstract void Log(string message);
}

public class ErrorLogger : LoggerDecorator
{
    public ErrorLogger(ILogger logger) : base(logger) { }

    public override void Log(string message)
    {
        _logger.Log($"[ERROR] {DateTime.Now}: {message}");
    }
}

public class SuccessLogger : LoggerDecorator
{
    public SuccessLogger(ILogger logger) : base(logger) { }

    public override void Log(string message)
    {
        _logger.Log($"[SUCCESS] {DateTime.Now}: {message}");
    }
}