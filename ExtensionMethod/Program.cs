using System;
namespace ExtensionMethod
{
    static class TestExtensionMethod
    {
        public static void Print(this string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
            Console.ResetColor();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string s = "test";
            TestExtensionMethod.Print(s, ConsoleColor.Green);
            "test2".Print(ConsoleColor.Red);
        }
    }
}