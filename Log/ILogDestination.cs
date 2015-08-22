namespace Log {
    public interface ILogDestination {
        void Log(LogLevel logLevel, LogMessage[] logMessages);
    }
}
