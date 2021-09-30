using System;

namespace Task3
{
    public class FiboLoop
    {
        public int Calculate(int x)
        {
            if (x < 0)  throw new ArgumentException("Аргумент должен быть >= 1");
            if (x == 0) return 0;
            if (x == 1) return 1;
            var arg1 = 0;
            var arg2 = 1;
            for (int i = 2; i < x; i++)
            {
                var tmp = arg1 + arg2;
                arg1 = arg2;
                arg2 = tmp;
            }

            return arg1 + arg2;
        }
    }
}