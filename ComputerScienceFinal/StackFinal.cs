﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScienceFinal
{
    public static class StackFinal
    {
        class Node
        {
            public int data;
            public Node next;
            public Node(int num)
            {
                data = num;
            }
        }
        // khởi tạo Stack theo Linked List
        class StackLinkedList
        {
            public Node head;
            public StackLinkedList()
            {
                this.head = null;
            }
            // khởi tạo hàm đưa phần tử vào stack
            public void Push(int num)
            {
                Node newNode = new Node(num);
                if (head == null)
                {
                    head = newNode;
                }
                else 
                { 
                    newNode.next = head;
                    head = newNode;
                }
            }
            // lấy phần tử đầu của stack ra
            public void Pop()
            {
                if (head != null)
                {
                    Console.Write("Gia tri duoc lay ra: " + head.data);
                    head = head.next;
                }
                else
                {
                    Console.Write("Stack Rỗng");
                }
            }
            // xem được giá trị đầu của Stack
            public void Peek()
            {
                if (head != null)
                {
                    Console.Write("Gia tri dau duoc them: " + head.data);
                }
                else
                {
                    Console.Write("Stack is Empty");
                }
            }
            public void DisplayStack()
            {
                Node temp = head;
                Console.Write("Gia tri Trong Stack: ");
                try
                {
                    while (temp != temp.next)
                    {
                        Console.Write(temp.data + " ");
                        temp = temp.next;
                    }
                    Console.WriteLine("\n");
                }
                catch(NullReferenceException) { }
            }
        }
        public static void RunStack()
        {
            StackLinkedList s = new StackLinkedList();
            s.Push(5);
            s.Push(10);
            s.Push(9);
            s.Push(1);
  
            s.Peek();
            Console.WriteLine();
            s.DisplayStack();
            Console.WriteLine();
            s.Pop();
            Console.WriteLine();
            s.DisplayStack();
        }
    }
}
