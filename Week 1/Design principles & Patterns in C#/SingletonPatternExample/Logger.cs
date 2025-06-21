namespace SingletonPatternExample
{
    internal sealed class Logger
    {
        private static Logger? _instance;
        private static readonly object _sync = new();

        private Logger()
        {
            Console.WriteLine("Logger instance created.");
        }

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new Logger();
                        }
                    }
                }
                return _instance;
            }
        }

        public void Log(string message, string source)
        {
            Console.WriteLine($"[{source}] {message}");
        }
    }
}