using System;
using System.Threading.Tasks;

class Program
{
    public static async Task Main(string[] args) //використовуємо async для асинхронності
    {
        Console.WriteLine("Введіть число для обчислення факторіалу:");
        
        string input = Console.ReadLine();
        
        if (int.TryParse(input, out int number) && number >= 0)
        {
            // Виклик асинхронного методу для обчислення факторіалу
            long factorial = await CalculateFactorialAsync(number);
            Console.WriteLine($"Факторіал числа {number} = {factorial}");
        }
        else
        {
            Console.WriteLine("Будь ласка, введіть невід'ємне ціле число.");
        }
    }
    
    // метод, який запускає цей код в окремому потоці через метод .Run
    public static Task<long> CalculateFactorialAsync(int number)
    {
        return Task.Run(() => CalculateFactorial(number));
    }
    
    // основний метод, який фактично створює сам цикл знаходження факторіалу
    public static long CalculateFactorial(int number)
    {
        if (number == 0 && number == 1)
        {
            return 1;
        }

        long result = 1;
        
        for (int i = 2; i <= number; i++)
        {
            result *= i;
        }
        return result;
    }
}