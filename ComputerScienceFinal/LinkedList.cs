using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThuanCS
{
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

            //Xử lý List
            if(head == null) //Nếu List rỗng
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;       //Tail của List sẽ trỏ tới Node mới
                tail = newNode;            //Gía trị của Tail sẽ thay bằng Node mới
            }
            
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

        /*==============================================================*/
        //Hàm thêm một Node mới có dữ liệu "data" vào vị trí sau Node Position (Position.Next)
        public void addAnyWhere(int data, Node Position)
        {
            Node Temp;                  //Tạo Node lưu trữ đệm
            Temp = head;                //Node đệm bắt đầu chạy duyệt từ Head
            Node newNode = new Node();  //Tạo Node mới cần thêm vào

            //Chạy Node Temp rà soát từng Node trên chuỗi để tìm đến vị trí "Node Position"
            while((Temp != null) && (Temp != Position)) 
            {
                /*Khi Node Temp chưa chạy tới Tail (khác null) 
                và Node Temp chưa tìm được đến vị trí Node Position*/
                Temp = Temp.Next; //Nhảy đến Node kế tiếp
            }
            if (Temp == null) 
            {
                /*Khi Node Temp duyệt qua hết các Node trong chuỗi nhưng
                không tìm thấy Node Position cần tìm, và Node Temp chạy đến Tail (=null)*/
                //
                Console.WriteLine("Insertion position not found");
                //DisposeOf(newNode);
                
                newNode = null;  //Xóa Node mới không được add vào để tiết kiệm bộ nhớ
            }
            else
            {
                /*Khi Node Temp tìm thấy được Node Position*/
                /*Hiện tại Node Temp đang bằng với Node Position*/
                newNode.data = data; //Gán dữ liệu vào newNode để thêm vào List
                newNode.Next = Temp.Next;  //Trỏ con trỏ của newNode tới Node kế tiếp của Node Position
                Temp.Next = newNode;  //Trỏ con trỏ của Node Position tới newNode
                /*Tới bước này, newNode đã được chèn vào sau Node Position và trỏ tới các Node còn lại của List*/
            }
        }

        /*=================================================================*/
        //Hàm Xóa một Node tại vị trí Node Position
        public Boolean removeByNode(Node Position)
        {
            //Khởi tạo các biến xác định kết quả xóa thành công hay không
            Boolean result = false, found = false;
            Node Temp;
            Node Junk;
            Temp = head;
            if(head == Position) //Khi Node muốn xóa là phần tử đầu tiên
            {
                head = head.Next; 
                Position = null;
                Temp = null;
            }
            else //Duyệt List, tìm Node Pos
            {
                while (result == false)  //Khi chưa rà soát hết List
                {
                    if(Temp == null)  //Nếu Temp chạy tới Tail
                    {
                        result = true;  // Đã duyệt qua List, out khỏi While
                    }
                    else
                    {
                        if(Temp.Next == Position) //Tìm thấy Node Position
                        {
                            found = true;  
                            result = true;  //Không duyệt List nữa vì đã tìm thấy Node Pos, out khỏi While
                        }
                        Temp = Temp.Next; //Nhảy thằng Temp qua Node Pos
                    }
                }
            }
            if(found == false) //Nếu duyệt hết List mà vẫn ko tìm thấy tml Node Pos
            {
                Console.WriteLine("Insertion position not found"); //Chửi
            }
            else
            {
                //Lúc này thằng Temp đang = Node Position, tức Node cần xóa
                Junk = Temp.Next; //Lưu đệm thằng Node cần xóa ra ngoài, để tí mình xóa nó khỏi bộ nhớ
                Temp.Next = Temp.Next.Next; //Thay thế thằng Node đã xóa bằng thằng Node sau nó (dồn lại)
                //Xóa 2 Node sau khi sử dụng
                Position = null; 
                Junk = null; 
            }
            return found; //Trả về kết quả có xóa được hay không
        }

        /*=========================================================*/
        //Hàm xóa phần tử đầu tiên của Node
       
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
    }
}
