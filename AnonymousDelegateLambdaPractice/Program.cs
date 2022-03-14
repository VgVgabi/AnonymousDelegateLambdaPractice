using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousDelegateLambdaPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string strCheck;
            int itemNumber;
            //
            // -->
            var GetFiltered = (int[] newArray, Func<int, bool> arrFilter) =>
            {
                int[] nArr = new int[0];
                for (int i = 0; i < newArray.Length; i++)
                {
                    if (arrFilter(newArray[i]))
                    {
                        Array.Resize(ref nArr, nArr.Length + 1);
                        nArr[nArr.Length - 1] = newArray[i];
                    }
                }
                return nArr;
            };
            //
            // -->             
            int[] array = new int[] { 1, 2, 3, 5, 6, 11, 12, 13, 14, 22, 23, 33, 44, 55 };
            int[] evenArray = GetFiltered(array, (itemNumber) => itemNumber % 2 == 0);
            int[] notEvenArray = GetFiltered(array, (itemNumber) => !(itemNumber % 2 == 0));
            int[] has3Array = GetFiltered(array, (itemNumber) =>
            {
                strCheck = itemNumber.ToString();
                if (strCheck.Contains("3"))
                    return true;
                return false;
            });
            int[] hasSameNumberArray = GetFiltered(array, (itemNumber) =>
            {
                strCheck = itemNumber.ToString();
                if (strCheck.Length < 2)
                    return false;
                else
                    for (int i = 0; i < strCheck.Length - 1; i++)
                    {
                        if (!(strCheck[i] == strCheck[i + 1]))
                        {
                            return false;
                        }
                    }
                return true;
            });
            //
            // ->
            void Print(int[] newArray)
            {
                foreach (int item in newArray)
                    Console.Write(item + ", ");
            }
            //
            // -->
            System.Console.WriteLine("Original array items:");
            Print(array);
            System.Console.WriteLine("\n********************");
            System.Console.WriteLine("Even array items:");
            Print(evenArray);
            System.Console.WriteLine("\n********************");
            System.Console.WriteLine("Not even array items:");
            Print(notEvenArray);
            System.Console.WriteLine("\n********************");
            System.Console.WriteLine("Has 3 array items:");
            Print(has3Array);
            System.Console.WriteLine("\n********************");
            System.Console.WriteLine("Has same number array items:");
            Print(hasSameNumberArray);
            System.Console.WriteLine("\n********************");
            //
        }
    }
}
