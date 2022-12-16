using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BinarySearch
    {
        #region Pseudo Code
        // while(there are more elements)
        // {
        //      middle = (low + high) / 2;
        //      if (searchNumber<List[middle])
        //	    {
        //          high = middle - 1 ;
        //	    }
        //	    else if (searchNumber>List[middle])
        //	    {
        //          ow = middle + 1;
        //	    }
        //	    else
        //      {
        //          return middle;
        //      }
        // }
        #endregion
        public static int DoBinarySearch(int[] numbers, int numberToFind)
        {
            // Console.WriteLine(Array.BinarySearch(numbers, 22)); // C# 內建的的BinarySearch 

            int low = 0;
            int high = numbers.Length - 1;

            while (low <= high) // 若是high>low，代表已經全部檢查過一遍了(low從左到右，high從又到左，已經重疊過，並超過了)
            {
                int mid = (low + high) / 2;
                int guess = numbers[mid];
                if (guess == numberToFind)
                {
                    return mid;
                }

                if (guess > numberToFind)
                {
                    high = mid - 1;
                }
                else if (guess < numberToFind)
                {
                    low = mid + 1;
                }
            }

            return -1; // 想找的數字不存在
        }
        public static int RecursionBinarySerach(int[] numbers, int numberToFind, int low, int high)
        {
            while (low <= high)
            {
                int mid = (low + high) / 2;
                int guess = numbers[mid];
                if (guess == numberToFind)
                {
                    return mid;
                }

                if (guess > numberToFind)
                {
                    //high = mid - 1;
                    return RecursionBinarySerach(numbers, numberToFind, low, mid - 1);
                }
                else if (guess < numberToFind)
                {
                    //low = mid + 1;
                    return RecursionBinarySerach(numbers, numberToFind, mid+1, high);
                }
            }

            return -1; // 想找的數字不存在
        }
    }
}
