using System;

using Log;
using Log.Destinations;

namespace SkiiSharp {
    class MainClass {
        public static void Main(string[] args) {
            Logger logger = new Logger();

            logger.AddDestination(new ConsoleDestination());
            logger.Log("Hello!");
        }
    }
}
