using System;

namespace Log {
    public class LogMessage {
        public LogColor Color;
        public String Value;

        public LogMessage() : this("") {}

        public LogMessage(String value) : this(LogColor.Default, value) {}

        public LogMessage(LogColor color, String value) {
            Color = color;
            Value = value;
        }
    }
}
