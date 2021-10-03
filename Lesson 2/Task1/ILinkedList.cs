using System;
using System.Runtime.InteropServices;

namespace Task1
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }

        public Node(int value) => Value = value;
    }

    public class DLinkedList : ILinkedList
    {
        public Node First;
        public Node Last;
        
        public int GetCount()
        {
            var count = 0;
            if (First == null) return 0;
            var tmp = First;
            while (tmp != Last)
            {
                tmp = tmp.NextNode;
                count++;
            }

            return count + 1;
        }

        public void AddNode(int value)
        {
            var tmp = new Node(value);
            if (First == null)
            {
                First = tmp;
                Last = tmp;
                return;
            }

            Last.NextNode = tmp;
            Last = tmp;
        }

        public void AddNodeAfter(Node node, int value)
        {
            if (! NodeExist(node)) return;

            if (node.NextNode != null)
            {
                var tmp = new Node(value);
                tmp.NextNode = node.NextNode;
                tmp.PrevNode = node;
                node.NextNode.PrevNode = tmp;
                node.NextNode = tmp;
                return;
            }
            AddNode(value);
        }

        public void RemoveNode(int index)
        {
            if (First == null || index < 0) return;
            if (First == Last)
            {
                First = null;
                Last = null;
                return;
            }
            
            if (index == 0)
            {
                First.NextNode.PrevNode = null;
                First = First.NextNode;
                return;
            }

            Node tmp = First;
            for (int i = 0; i <= index; i++)
            {
                if (tmp.NextNode == null) return;
                tmp = tmp.NextNode;
            }
            
            if (tmp.NextNode == null)
            {
                tmp.PrevNode = null;
                Last = tmp.PrevNode;
                return;
            }

            tmp.PrevNode.NextNode = tmp.NextNode;
            tmp.NextNode.PrevNode = tmp.PrevNode;
        }

        public void RemoveNode(Node node)
        {
            if (First == null) return;
            var tmp = First;
            var i = 0;
            while (tmp != node && tmp.NextNode != null)
            {
                tmp = tmp.NextNode;
                i++;
            }
            if (tmp != node) return;
            RemoveNode(i);
        }

        public Node FindNode(int searchValue)
        {
            if (First == null) return null;
            var tmp = First;
            while (tmp.Value != searchValue && tmp.NextNode != null)
                tmp = tmp.NextNode;
            if (tmp.Value != searchValue) return null;
            return tmp;
        }

        public override string ToString()
        {
            if (First == null) return string.Empty;
            var tmp = First;
            var i = 0;
            var print = $"{i++}: \t {tmp.Value}";
            while (tmp != Last)
            {
                tmp = tmp.NextNode;
                print += $"\n{i++}: \t {tmp.Value}";
            }

            return print;
        }

        public bool NodeExist(Node node)
        {
            if (First == null) return false;
            var tmp = First;
            while (tmp != node && tmp.NextNode != null) tmp = tmp.NextNode;
            return tmp == node;
        }
        
        public void Print() => Console.WriteLine(ToString());
    }
//Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value); // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
        void Print();
    }
}