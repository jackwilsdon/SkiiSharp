using System;
using System.Collections.Generic;

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

        public static LogMessage[] Parse(params Object[] messages) {
            List<LogMessage> parsedMessages = new List<LogMessage>();

            LogMessage currentMessage = new LogMessage();

            foreach (Object message in messages) {
                Type messageType = message.GetType();

                if (messageType == typeof(LogMessage)) {
                    parsedMessages.Add((LogMessage) message);
                } else if (messageType == typeof(LogMessage[])) {
                    parsedMessages.AddRange((LogMessage[]) message);
                } else if (messageType == typeof(LogColor)) {
                    currentMessage.Color = (LogColor) message;
                } else {
                    currentMessage.Value += message.ToString();

                    parsedMessages.Add(currentMessage);
                    currentMessage = new LogMessage();
                }
            }

            return parsedMessages.ToArray();
        }
    }
}
