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

public class ErrorLogger : ILogger
{
    private readonly ILogger _logger;

    public ErrorLogger(ILogger logger)
    {
        _logger = logger;
    }

    public void Log(string message)
    {
        _logger.Log($"[ERROR] {DateTime.Now}: {message}");
    }
}

public class SuccessLogger : ILogger
{
    private readonly ILogger _logger;

    public SuccessLogger(ILogger logger)
    {
        _logger = logger;
    }

    public void Log(string message)
    {
        _logger.Log($"[SUCCESS] {DateTime.Now}: {message}");
    }
}
