using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScienceFinal
{
    public static class HashTableFinal
    {
        
        class HashNode
        {
            public object key;
            public object value;
            HashNode next;
            HashNode[] T;
            // khoi tao do dai cua bang Hash
            public void Init(int Size)
            {
                T = new HashNode[Size];

                for (int i = 0; i < Size; i++)
                {
                    T[i] = null;
                }
            }
            // ham hash theo microsoft
            public int Hashing(object key)
            {
                return Math.Abs(key.GetHashCode()) % T.Length;
            }
            // nhap tu khoa va tu can tim thay
            public void Insert(object key, object value)
            {
                HashNode h = new HashNode();
                h.key = key;
                h.value = value;
                int num = Hashing(key);
                if (T[num] == null)
                {
                    T[num] = h;
                }
                else
                {
                    h.next = T[num];
                    T[num] = h;
                }
            }
            // ham cho phep nhap tu khoa de hien tu can tim thay
            public object LookUp(object key)
            {
                int num = Hashing(key);
                HashNode current = T[num];
                while (current != null)
                {
                    if (current.key == key)
                    {
                        return current.value;   
                    }
                    else
                    {
                        current = current.next;
                    }
                }
                return "Khong tim thay tu khoa tuong ung";
            }

        }
        // ham chay HashTable
        public static void RunHastable()
        {
            HashNode h = new HashNode();
            h.Init(5);
            h.Insert("Gold","Vang");
            h.Insert("Silver","Bac");
            h.Insert("Bronze", "Dong");
            h.Insert("Diamond","Kim Cuong");

            Console.WriteLine("Ket Qua Tu Khoa Can Tim: ");


            Console.WriteLine(h.LookUp("Diamond"));
            Console.WriteLine(h.LookUp("Gold"));        
            Console.WriteLine(h.LookUp("Silver"));
            Console.WriteLine(h.LookUp("Blue"));
        }
    }
}
