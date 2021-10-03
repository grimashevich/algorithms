using System.Collections.Generic;

namespace Task2
{
    public class ListSearch: List<int>
    {
        public int BinSearch(int value)
        {
            /*Возвращает -1 если элемент не найден, иначе индекс элемента*/
            Sort();
            var top = 0;
            var bot = Count - 1;
            while (top < bot)
            {
                if (this[top] == value) return top;
                if (this[bot] == value) return bot;
                var half = (top + bot) / 2;
                if (this[half] == value) return half;
                if (this[half] > value) bot = half - 1;
                else top = half + 1;
            }

            return -1;
        }
    }
}