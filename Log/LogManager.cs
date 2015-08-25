using System;
using System.Collections.Generic;

namespace Log
{
    public static class LogManager
    {
        private static Dictionary<string, Logger> instances = new Dictionary<string, Logger>();

        public static Logger CreateLogger(bool addConsoleDestination = false, bool logDate = false) {
            Logger logger = new Logger();

            if (addConsoleDestination) {
                logger.AddDestination(new Destinations.ConsoleDestination(logDate));
            }

            return logger;
        }

        public static Logger GetLogger(string name = null, bool addConsoleDestination = true, bool logDate = false) {
            if (name == null || !instances.ContainsKey(name)) {
                Logger logger = CreateLogger(addConsoleDestination, logDate);

                if (name != null) {
                    instances.Add(name, logger);
                }

                return logger;
            } else {
                return instances[name];
            }
        }
    }
}

