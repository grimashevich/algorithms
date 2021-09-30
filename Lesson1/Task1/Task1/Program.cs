using System;

namespace Task1
{
    internal class Program
    {
        
        public class TestCase
        {
            public int X { get; set; }
            public bool Expected { get; set; }
            public Exception ExpectedException { get; set; }

            public TestCase(int x, bool exp, Exception ex = null)
            {
                X = x;
                Expected = exp;
                ExpectedException = ex;
            }
        }
        
        public static void Main(string[] args)
        {
            TestCase[] arr = new TestCase[5]
            {
                new TestCase(2, true),
                new TestCase(4, false),
                new TestCase(101, true),
                new TestCase(1, false, new ArgumentException("Argument must be <= 2")),
                new TestCase(-5, false, new ArgumentException("Argument must be <= 2"))
            };

            foreach (var tc in arr)
                TestSimple(tc);
        }

        static bool IsIntSimple(int n)
        {
            var d = 0;
            var i = 2;
            while (i < n)
            {
                if (n % i == 0) d++;
                i++;
            }
            /*return d == 0;*/
            /*Я бы лучше так написал, но если строго следовать схеме...*/
            if (d == 0) return true;
            return false;
        }
        
        static bool CheckSimple(int x)
        {
            if (x < 2)
                throw new ArgumentException("Число должно быть больше или равно 2");

            return IsIntSimple(x);
        }
        
        static void TestSimple(TestCase testCase)
        {
            try
            {
                var actual = CheckSimple(testCase.X);

                if (actual == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch(Exception ex)
            {
                if(testCase.ExpectedException != null)
                {
                    
                    if (testCase.ExpectedException.GetType() == ex.GetType())
                        Console.WriteLine("VALID TEST");
                    else
                        Console.WriteLine("INVALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }
    }
}