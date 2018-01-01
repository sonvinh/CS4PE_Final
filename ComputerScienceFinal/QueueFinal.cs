using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScienceFinal
{
    public  class QueueFinal
    {
        // khoi tao Node
        class Node
        {
            public int data;
            public Node next;
            public Node(int x)
            {
                data = x;
                next = null;
            }
        }
        
        // khởi tạo queue
        class Queue{

            public  Node Head, Tail;
            public Queue()
            {
                Head = Tail = null;
            }
            // Thêm vào cuối hàng đợi

            public void enQueue(Queue q,int x)
            {
                Node p = new Node(x);
                if (Head == null)
                {
                    Head = Tail = p;
                }
                Tail.next = p;
                Tail = p;
                return;
            }
            // Lấy ra đầu hàng đợi
            public void deQueue(Queue q)
            {
                if (Head == null)
                {
                    Console.Write("Hang doi rong");
                }
                if (Head == Tail)
                {
                    Console.Write("Lay ra khoi hang doi: " + Head.data);
                }
                else
                {
                    Console.Write("Lay ra khoi hang doi: " + Head.data);
                    Head = Head.next;
                }
                return;
            }
            // xem gia trị của head
            public void front(Queue q)
            {
                if (Head == null)
                {
                    Console.Write("Hang doi rong");
                    return;
                }
                Console.Write("Gia tri dau cua hang doi = "+ Head.data);
                return;
            }
            // hiện danh sách queue ra
            public void DisplayQueue()
            {
                Node temp = Head;
                Console.Write("Gia Tri Trong Queue: ");
                try { 
                        while (temp != temp.next)
                        {
                            Console.Write(temp.data + " ");
                            temp = temp.next;
                        }
                            Console.WriteLine("\n");
                    }
                catch(NullReferenceException){}
            }
       }
        // hàm sẽ gọi qua Program để chạy Queue
        public static void RunQueue()
        {
            Queue q = new Queue();
            q.enQueue(q,4);
            q.enQueue(q,5);
            q.enQueue(q,6);
            q.enQueue(q,7);
            q.enQueue(q,8);

            q.DisplayQueue();
            
            Console.WriteLine();
            
            q.front(q);
            Console.WriteLine();
            q.deQueue(q);
            Console.WriteLine();
            q.deQueue(q);
            Console.WriteLine();
            q.DisplayQueue();
            
        }
    }
}
