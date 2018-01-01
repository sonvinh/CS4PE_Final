using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScienceFinal
{
    class TreeNODE
    {
        public int data;
        public TreeNODE left = null;
        public TreeNODE right = null;

        public TreeNODE(int Data)
        {
            data = Data;
        }
        // hàm kiểm tra giá trị nhập vào có trùng với giá trị đã có trong tree hay chưa
        public bool isEqual(int Data)
        {
            return (data == Data);
        }
        // thêm phần tử phía sau node
        public void Insert(int Data)
        {
            if (isEqual(Data))
            {
                return;
            }
            if (data > Data)
            {
                if (left == null)
                    left = new TreeNODE(Data);
                else
                    left.Insert(Data);
            }
            else if (data < Data)
            {
                if (right == null)
                    right = new TreeNODE(Data);
                else
                    right.Insert(Data);
            }
        }
    }
}
