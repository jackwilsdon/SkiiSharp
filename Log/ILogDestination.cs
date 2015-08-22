namespace Log {
    public interface ILogDestination {
        void Log(LogLevel level, LogMessage[] messages);
    }
}
