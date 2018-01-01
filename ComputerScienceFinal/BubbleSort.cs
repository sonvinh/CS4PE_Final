using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScienceFinal
{
    public static class BubbleSort
    {
        public static void Sort()
        {
            // cho nhap 1 chuoi so
            Console.Write("Nhap chuoi so: ");
            string s = Console.ReadLine().Trim();

            string[] aString = s.Split(',');
            int[] arr = new int[aString.Length];

            for (int i = 0; i < aString.Length; i++)
            {
                arr[i] = int.Parse(aString[i].Trim());
            }
            //
            int temp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }  
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0},", arr[i]);
            }
            Console.ReadKey();
        }
    }
}
