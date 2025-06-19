using System;

namespace SingletonPatternExample
{
    internal class Logger
    {
        private static Logger? instance = null; // Private Instance set null at initial stage
        private static readonly object lockObj = new object(); // lock object for thread safety

        // Private constructor
        private Logger() {
            Console.WriteLine("Logger initialized.");
        }

        public static Logger GetInstance()
        {
            if(instance == null)
            {
                lock(lockObj)
                {
                    if(instance == null)
                    {
                        instance = new Logger();
                    }
                }
            }
            return instance;
        }

        public void Log(string message)
        {
            Console.WriteLine("Log : {0}", message);
        }
    }
}
