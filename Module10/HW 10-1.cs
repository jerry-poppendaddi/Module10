using System;
namespace MiniCalculator;

class Program
{
    static void Main()
    {
        MiniCalculator minicalculator = new MiniCalculator();
        minicalculator.Calculate();
    }
}
public interface ICalculator
{
    void Calculate();
}
public class MiniCalculator : ICalculator
{
    public void Calculate()
    {
        bool validInput = false;
        do
        {
            try
            {
                Console.WriteLine("Hello \n Enter the first number for addition:");
                long a = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Now enter the second number for addition:");
                long b = Convert.ToInt64(Console.ReadLine());
                var result = a + b;
                Console.WriteLine("Here is your result: " + result);
                validInput = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("What you entered is NOT a number!");
            }
            finally
            {
                Console.ReadKey();
            }
        } while (!validInput);
    }
}