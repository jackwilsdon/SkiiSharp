using System;

using Log;
using Log.Destinations;

namespace SkiiSharp {
    class MainClass {
        public static void Main(string[] args) {
            Logger logger = LogManager.GetLogger("Hello", true, true);

            logger.Log("Hello, world!");
        }
    }
}
