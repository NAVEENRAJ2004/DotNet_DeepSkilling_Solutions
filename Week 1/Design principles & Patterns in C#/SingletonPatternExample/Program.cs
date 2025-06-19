using System;


namespace SingletonPatternExample
{
    internal class Program
    {
        static void Main(string[] args) {
            Logger L1 = Logger.GetInstance();
            L1.Log("Message from Instance 1");

            Logger L2 = Logger.GetInstance();
            L2.Log("Message from Instance 2");

            Console.WriteLine($"Are Both Instance are Same? : {(L1 == L2 ? "Yes": "No")}");
        }
    }
}
