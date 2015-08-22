namespace Log {
    public enum LogLevel {
        Debug,
        Information,
        Warning,
        Error,
        Fatal
    }

    public static class LogLevelExtensions {
        public static LogColor GetColor(this LogLevel level) {
            switch (level) {
            case LogLevel.Debug:
                return LogColor.Gray;
            case LogLevel.Information:
                return LogColor.Cyan;
            case LogLevel.Warning:
                return LogColor.Yellow;
            case LogLevel.Error:
                return LogColor.Red;
            case LogLevel.Fatal:
                return LogColor.Red;
            }

            return LogColor.Default;
        }
    }
}
