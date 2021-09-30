using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 10;
            var fibo1 = new FiboRec();
            var fibo2 = new FiboLoop();
            Console.WriteLine($"Число фибоначчи для f({n}) = {fibo1.Calculate(n)} (рекурсия)");
            Console.WriteLine($"Число фибоначчи для f({n}) = {fibo2.Calculate(n)} (цикл)");
        }
    }
}