using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScienceFinal
{
    /*Author: Thuan Nguyen
     * Note: Dưới đây mình trình bày những hàm cơ bản của Linked List, và comment giải thích từng dòng
     * Cmt khá nhiều chứ code không dài. Bạn có thể đọc qua một lần, hiểu cách chạy từng hàm 
     * sau đó xóa bớt comment đi cho đỡ rối mắt!
	 * Chúc bạn thi tốt
     * */
     public class Node
    {
        public Node Next;
        public int data;
    }
    public class LinkedList
    {
        //Gọi cấu trúc Node từ Node.cs
        public Node head;
        public Node tail;

        //Cấu trúc của Linked List
        public LinkedList()
        {
            //Head và Tail là đầu và đuôi của List, chứa con trỏ và giá trị null
            head = new Node();
            head = null;
            tail = head;
        }
        //Hàm In danh sách phần tử trong List ra màn hình
        public void printList()
        {
            Node Temp = new Node();
            Temp = head;

            //List rỗng
            if (head == null)
            {
                Console.Write("The list is empty!");
            }

            //List không rỗng
            while(Temp != null)
            {
                
                Console.Write(" -> "+Temp.data);
                Temp = Temp.Next;
            }

            //Dọn bộ nhớ đệm
            Temp = null;

        }
         
        //Hàm Kiểm tra độ dài của List
        public int lengthList()
        {
            Node Temp; //Node này dùng để duyệt danh sách list
            int i = 0; //Biến đếm
            Temp = head; //Bắt đầu chạy từ Head
            //Duyệt hết List
            while (Temp != null)
            {
                i++;
                Temp = Temp.Next;
            }
            return i;
        }
        
        //Hàm Search một phần tử trong Linked List bằng Data
        public int SearchWithData(int data)
        {
            Node Temp = new Node();
            Temp = head;
            int i = 1;
            while(Temp != null && Temp.data != data) // Duyệt List cho tới khi tìm thấy Node chứa 'data'
            {
                Temp = Temp.Next;
                i++;
            }
            if(Temp != null)
            {
                return i;       // Vị trí của Node cần tìm
            }
            else
            {
                return 0;       //Không tìm thấy
            }
        }
        /*========================================================================*/
        //Hàm Append - Thêm một Node chứa dữ liệu "data" vào cuối List
        public void addAtTail(int data)
        {
            //Xử lý Node mới
            Node newNode = new Node(); //tạo Node mới
            newNode.data = data;       //Thêm dữ liệu "data" cho Node mới
            newNode.Next = null;       //Con trỏ của Node mới sẽ là Tail (null) vì đứng cuối List

            //Node đệm
            
            Node Temp = head;
            //Xử lý List
            if(head == null) //Nếu List rỗng
            {
                head = newNode;
                
            }
            else
            {
                //Duyệt cho Node Temp chạy tới Tail
                while (Temp.Next != null)
                {
                    Temp = Temp.Next;
                }
                Temp.Next = newNode;
            }
            
            //else
            //{ 
            //    tail.Next = newNode;       //Tail của List sẽ trỏ tới Node mới
            //    tail = newNode;            //Gía trị của Tail sẽ thay bằng Node mới
            //}
            
        }

        /*-=========================================================-*/
        //Hàm thêm một Node vào đầu List
        public void addAtHead(int data)
        {
            //Xử lý Node mới
            Node newNode = new Node();  //Tạo node mới
            newNode.data = data;        //Thêm dữ liệu "data" cho Node mới
            
            
            //Xử lý List
            if(head == null)    //Nếu List đang rỗng
            {
                head = newNode;
            }
            else
            {
                Node Temp = new Node();
                Temp = head;
                head = newNode;   //Trỏ con trỏ của newNode đến Node đầu tiên của List (nằm sau Head)
                newNode.Next = Temp;       //Đổi con trỏ của Head nối sang newNode
            }
            
        }
       
        /*=======================================================*/
        //Hàm xóa một Node tại một vị trí nodeNumber nào đó
        public bool removeByPosition(int nodeNumber)
        {
            
            bool result = false;
            Node Temp;
            Temp = head; //Tạo một node chạy duyệt từ Head
            Node prev = null; //Node đứng trước Node Temp

            int index = 0;
            
            //Nếu vị trí Node nhập vào không nằm trong độ dài của List
            if(nodeNumber < 1 || nodeNumber > this.lengthList())
            {
                Console.WriteLine("The Position is invalid, please check again!");
            }

            //Bắt đầu chạy duyệt List cho đến khi đến vị trí nodeNumber
            while (index < nodeNumber && Temp != null)
            {
                prev = Temp;
                Temp = Temp.Next;

                index++;
            }

            //Nếu chạy đến vị trí Node cần xóa và Node đó có giá trị (khác Tail)
            if(Temp != null)
            {
                //Nếu Node Pre là Node head, tức vị trí cần xóa là Head
                if(prev == null)
                {
                    head = Temp.Next;
                    
                }
                else 
                {
                    //Xóa Node tại vị trí nodeNumber
                    prev.Next = Temp.Next;
                    Temp = null;
                    
                }

                //Dọn bộ nhớ
                Temp = null;
                result = true;
            }
            return result;
        }
        
        //Hàm add một Node tại vị trí nằm sau vị trí Node bất kì
        public bool addByPosition(int nodeNumber, int data)
        {
            bool result = false;
            Node newNode = new Node();
            newNode.data = data;

            Node Temp;
            Node prev = null;
            Temp = head;
            
            int index = 0;
            //kiểm tra
            if(nodeNumber < 0 || nodeNumber > this.lengthList())
            {
                Console.WriteLine("The position is invalid, please check again!");
            }
            else
            {
                while (index < nodeNumber && Temp != null)
                {
                    prev = Temp;
                    Temp = Temp.Next;
                    index++;
                }
                if (Temp != null)
                {
                    if (prev == null)
                    {
                        head = newNode;
                        newNode.Next = Temp;
                    }
                    else
                    {
                        newNode.Next = prev.Next;
                        prev.Next = newNode;
                    }
                    result = true;
                }
            }
          
            return result;
        }
        //Hàm chạy thử
        public static void runLinkedList()
        {
            LinkedList list = new LinkedList();
            list.addAtHead(1);
            list.addAtHead(9);
            list.addAtTail(2);
            list.addAtTail(3);
            list.addAtHead(15);
            //list.addByPosition(1, 113);
            list.removeByPosition(2);
            list.addByPosition(2, 113);

            list.printList();
        }
    }
}
