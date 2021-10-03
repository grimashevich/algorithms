using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            ListSearch l1 = new();
            for (int i = 100; i < 201; i++)
                l1.Add(i);

            for (int i = 75; i < 226; i += 25)
                Console.WriteLine($"Ищем {i}, результат: {l1.BinSearch(i)}");
        }
    }
}