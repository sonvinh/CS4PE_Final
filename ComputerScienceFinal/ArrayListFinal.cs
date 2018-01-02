using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScienceFinal
{
    public static class ArrayListFinal
    {
        public class ArrayList
        {
            int[] arr;
            int len = 0;
            public ArrayList(int[] ArrInt, int maxSize)
            {
                arr = new int[maxSize];
                for (int i = 0; i < ArrInt.Length; i++)
                {
                    arr[i] = ArrInt[i];
                }

                len = ArrInt.Length;

            }
            public void Append(int value)
            {

                arr[len] = value;
                len++;
            }
            public void InsertAt(int index, int value)
            {
                for (int i = len - 1; i >= index; i--)
                {
                    arr[i + 1] = arr[i];
                }
                arr[index] = value;
                len++;
            }
            public int Get(int index)
            {
                return arr[index];
            }
            public void Set(int index, int value)
            {
                arr[index] = value;
            }
            public void RemoveAt(int index)
            {
                for (int i = index; i < len; i++)
                {
                    arr[index] = arr[index + 1];
                }
                len--;

            }
            private static void Print(ArrayList arr)
            {
                for (int i = 0; i < arr.len; i++)
                {

                    Console.Write(arr.Get(i));


                }
            }

            public static void Run()
            {
                int[] Arr = { 2, 5, 7, 3 };
                ArrayList arr = new ArrayList(Arr, 100);
                //get
                Console.WriteLine(arr.Get(1));
                //Append
                arr.Append(9);
                Print(arr);
                Console.WriteLine();
                //set
                arr.Set(2, 4);
                Print(arr);
                Console.WriteLine();
                //RemoveAt
                arr.RemoveAt(1);
                Print(arr);
                Console.WriteLine();
            }
        }
    
    }
}
