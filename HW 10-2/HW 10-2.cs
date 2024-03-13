using System;
using System.Runtime.CompilerServices;

namespace MiniCalculator
{
    class Program
    {
        static ILogger Logger { get; set; }
        static void Main()
        {           
            Logger = new Logger();
            MiniCalculator minicalculator = new MiniCalculator(Logger);
            minicalculator.Calculate();            
        }
    }
    public interface ICalculator
    {
        void Calculate();
    }
    public interface ILogger
    {
        void Event(string message);
        void Error(string message);
    }
    public class Logger : ILogger
    {
        public void Event(string message)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
    public class MiniCalculator : ICalculator
    {
        ILogger Logger { get; }
        public MiniCalculator(ILogger logger)
        {
            Logger = logger;
        }
        public void Calculate()
        {
            bool validInput = false;
            do                                                               //я это сделал чтобы цикл не прерывался на ошибке и продолжал спрашивать цифру
            {
                try
                {
                    Logger.Event("Enter the first number for addition:");
                    long a = Convert.ToInt64(Console.ReadLine());
                    Logger.Event("Enter the second number for addition:");
                    long b = Convert.ToInt64(Console.ReadLine());
                    var result = a + b;
                    Logger.Event("Here is your result: " + result);
                    validInput = true;
                }
                catch (FormatException)
                {
                    Logger.Error("What you entered is NOT a number!");
                }
                finally
                {
                    Console.ReadKey();
                }
            } while (!validInput);
        }
    }
}