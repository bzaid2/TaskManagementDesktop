﻿namespace TaskManagement.Interfaces
{
    public interface ILoggerManager
    {
        void Information(string message);
        void Information(string message, Exception ex);
        void Warning(string message);
        void Warning(string message, Exception ex);
        void Error(string message);
        void Error(string message, Exception ex);
    }
}
