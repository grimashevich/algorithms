using System;

namespace Task3
{
    public class FiboRec
    {
        public int Calculate(int x)
        {
            if (x < 0)  throw new ArgumentException("Аргумент должен быть >= 1");
            if (x == 0) return 0;
            if (x == 1) return 1;
            return Calculate(x - 1) + Calculate(x - 2);
        }
    }
}