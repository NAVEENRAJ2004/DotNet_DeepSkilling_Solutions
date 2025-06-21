namespace SingletonPatternExample
{
    internal class Program
    {
        static void Main()
        {
            var logger1 = Logger.Instance;
            logger1.Log("sending a log", "Logger1");

            var logger2 = Logger.Instance;
            logger2.Log("sending a log", "Logger2");

            Console.WriteLine($"Logger instances are same: {(ReferenceEquals(logger1, logger2) ? "Yes" : "No")}");
        }
    }
}