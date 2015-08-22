using System;
using System.Collections.Generic;

namespace Log {
    public class Logger {
        private HashSet<ILogDestination> destinations = new HashSet<ILogDestination>();

        public LogLevel Level = LogLevel.Debug;

        public bool AddDestination(ILogDestination destination) {
            return destinations.Add(destination);
        }

        public bool RemoveDestination(ILogDestination destination) {
            return destinations.Remove(destination);
        }

        public void Log(LogLevel level, params Object[] messages) {
            if (level < Level) {
                return;
            }

            if (destinations.Count == 0) {
                throw new InvalidOperationException("no destinations for logger");
            }

            LogMessage[] logMessages = LogMessage.Parse(messages);

            foreach (ILogDestination destination in destinations) {
                destination.Log(level, logMessages);
            }
        }

        public void Log(params Object[] messages) {
            Log(LogLevel.Information, messages);
        }
    }
}
