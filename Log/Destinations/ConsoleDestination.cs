using System;

namespace Log.Destinations {
    public class ConsoleDestination : ILogDestination {
        public bool LogDate;

        public ConsoleDestination() : this(true) {}

        public ConsoleDestination(bool logDate) {
            LogDate = logDate;
        }

        private ConsoleColor? GetConsoleColor(LogColor color) {
            switch (color) {
            case LogColor.Red:
                return ConsoleColor.Red;
            case LogColor.Yellow:
                return ConsoleColor.Yellow;
            case LogColor.Green:
                return ConsoleColor.Green;
            case LogColor.Cyan:
                return ConsoleColor.Cyan;
            case LogColor.Blue:
                return ConsoleColor.Blue;
            case LogColor.Black:
                return ConsoleColor.Black;
            case LogColor.Gray:
                return ConsoleColor.Gray;
            case LogColor.White:
                return ConsoleColor.White;
            }

            return null;
        }

        private void LogRaw(LogMessage message) {
            ConsoleColor? color = GetConsoleColor(message.Color);

            if (color != null) {
                Console.ForegroundColor = (ConsoleColor) color;
            } else if (message.Color == LogColor.Default) {
                Console.ResetColor();
            }

            Console.Write(message.Value);
            Console.ResetColor();
        }

        private void LogRaw(LogMessage[] messages) {
            foreach (LogMessage message in messages) {
                LogRaw(message);
            }
        }

        private LogMessage GetDateMessage() {
            return new LogMessage(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
        }

        private LogMessage[] GetLevelMessages(LogLevel level) {
            return LogMessage.Parse("[", level.GetColor(), level.ToString(), LogColor.Default, "]");
        }

        public void Log(LogLevel level, LogMessage[] messages) {
            if (LogDate) {
                LogRaw(GetDateMessage());
                LogRaw(new LogMessage(" - "));
            }

            LogRaw(LogMessage.Parse("[", level.GetMessage(), "] "));
            LogRaw(messages);

            Console.WriteLine();
        }
    }
}
