using System;

namespace Task1
{
    public class DListMinitester
    {
        public static void DoTest()
        {
            var fakeNode = new Node(999);
            DLinkedList l1 = new DLinkedList();
            l1.FindNode(5); //Проверка на падение
            l1.AddNode(100);
            l1.AddNode(101);
            l1.AddNodeAfter(l1.First, 102);
            l1.AddNodeAfter(l1.Last, 103);
            l1.AddNodeAfter(fakeNode, 888); //Проверка на падение 
            l1.RemoveNode(-1); //Проверка на падение
            l1.RemoveNode(5); //Проверка на падение
            l1.RemoveNode(fakeNode); //Проверка на падение
            l1.Print();
            Console.WriteLine($"Количество элементов: {l1.GetCount()}");

            for (int i = 0; i < 5; i++) //Проверка на падение
            {
                l1.RemoveNode(l1.First); 
            }
        }
    }
}