using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class RecursivePermutation
    {
        /// <summary>
        /// Generate all the permutation(排列) of Array[start], ..., Array[end]
        /// </summary>
        /// <param name="charArray">要做排列的字元陣列</param>
        /// <param name="start">從第 start 位置開始</param>
        /// <param name="end">到第 end 位置的字元陣列作排列</param>
        public static void Permutation(char[] charArray, int start, int end)
        {
            #region 註解
            // 這段程式碼是實現字符串的全排列的递归算法。
            // 它接受三個參數：
            // charArray：要排列的字符串，以字符數組的形式傳遞。
            // start：排列過程中，當前正在處理的字符的位置。
            // end：字符串的長度。
            // 程式首先通過判斷start是否等於end來確定是否遞歸到了最底層。如果是，則輸出當前的字符串。
            // 否則，程式會從start位置開始，遍歷剩下的字符，並將當前位置的字符與它們交換。
            // 然後，程式會遞歸地呼叫自身，傳遞新的字符串和新的start位置（start + 1）。
            // 遞歸結束後，程式會再次交換字符，使字符串恢復原狀，以便接下來的遞歸運算。


            // 這段程式碼實現了一個函數，用於計算給定字符串的所有排列。它使用了遞歸的方法，每次遞歸都會將字符串中的一個字符與其他字符交換，然後遞歸處理剩下的字符。當遞歸到最底層時，會輸出當前的字符串。
            // 舉例來說，如果我們對字符串"abc"調用這個函數，那麼會得到以下的輸出：
            // abc
            // acb
            // bac
            // bca
            // cab
            // cba
            // 也就是說，這個函數會計算出字符串"abc"的所有排列，並將它們輸出到控制台。

            // 假設我們要對字符串"abc"調用這個函數。
            // 首先，我們會調用函數並傳遞字符串"abc"，以及其長度3和起始位置0，即：
            // Permutation("abc", 0, 3);
            // 函數首先會檢查起始位置（也就是0）是否等於字符串長度（也就是3）。由於不相等，所以函數會進入下一個分支。
            // 接下來，函數會從起始位置0開始，遍歷剩下的字符。也就是說，它會將字符'a'與'b'和'c'交換，然後遞歸調用函數。傳遞的參數分別為：
            // 將'a'與'b'交換後的字符串"bac"
            // 起始位置1（因為交換後的字符串已經處理過了字符'a'）
            // 字符串長度3
            // 函數會繼續遞歸下去，直到遞歸到最底層。當遞歸到最底層時，起始位置（也就是1）會等於字符串長度（也就是3）。此時，函數會進入第一個分支，並將當前的字符串"bac"輸出到控制台。
            // 接下來，函數會回到上一層遞歸，並再次將字符'a'與'c'交換，然後遞歸調用函數。傳遞的參數分別為：
            // 將'a'與'c'交換後的字符串"cab"
            // 起始位置1（因為交換後的字符串已經處理過了字符'a'）
            // 字符串長度3
            // 函數又會繼續遞歸下去，直到遞歸到最底層。當遞歸到最底層時，起始位置（也就是1）會等於字符串長度（也就是3）。此時，函數會進入第一個分支，並將當前的字符串"cab"輸出到控制台。
            // 接下來，函數又會回到上一層遞歸，將字符'a'和'b'交換回來，使字符串恢復原狀。然後，函數會再次回到第一層遞歸，並繼續從字符'b'開始遍歷。
            // 同樣地，函數會將字符'b'與'a'和'c'交換，然後遞歸調用函數。傳遞的參數分別為：
            // 將'b'與'a'交換後的字符串"abc"
            // 起始位置1（因為交換後的字符串已經處理過了字符'b'）
            // 字符串長度3
            // 函數會繼續遞歸下去，直到遞歸到最底層。當遞歸到最底層時，起始位置（也就是1）會等於字符串長度（也就是3）。此時，函數會進入第一個分支，並將當前的字符串"abc"輸出到控制台。
            // 接下來，函數又會回到上一層遞歸，將字符'b'和'c'交換，然後遞歸調用函數。傳遞的參數分別為：
            // 將'b'與'c'交換後的字符串"bca"
            // 起始位置1（因為交換後的字符串已經處理過了字符'b'）
            // 字符串長度3
            // 函數會繼續遞歸下去，直到遞歸到最底層。當遞歸到最底層時，起始位置（也就是1）會等於字符串長度（也就是3）。此時，函數會進入第一個分支，並將當前的字符串"bca"輸出到控制台。
            // 最後，函數會回到第一層遞歸，將字符'b'和'a'交換回來，使字符串恢復原狀。接下來，函數會繼續從字符'c'開始遍歷。
            // 同樣地，函數會將字符'c'與'a'和'b'交換，然後遞歸調用函數。

            // a b c d
            // 一開始會先進入Part B, start = 0, end = 4, " i = 0 "， Array[0] 和 Array[0]交換，接著 recursive 呼叫 Permutation，
            //                並傳入 Array, start + 1 == 1, end == 4，接著 Array[1] 和 Array[1]交換，再 recursive 呼叫 Permutation ... Array[2] 和 Array[2] 交換...，
            // 直到start == end 進入 Part A，並將此時的Array內容印出來，結果會是 a, b, c, d，因為都是自己跟自己交換。接著回到上一個呼叫做恢復原狀的Swap，接者 i++，這圈 loop 結束，回到上一個 stack call
            // 此時 start = 3 end 

            // 接著進入第2輪 start = 0, end = 4, " i = 1 "， Array[0] 和 Array[1] 交換
            #endregion
            // Part A
            if (start == end) // Output permutation
            {
                for (int i = 0; i < end; i++)
                {
                    Console.Write($"{charArray[i]} ");
                }
                Console.WriteLine();
            }
            // Part B
            else // Array[start], ...,Array[end] has more than one permutation
            {
                for (int i = start; i < end; i++)
                {
                    Swap(ref charArray[start], ref charArray[i]); // 交換
                    Permutation(charArray, start + 1, end);
                    Swap(ref charArray[start], ref charArray[i]); // 恢復原狀
                }
            } // end of else
        } // end of Permutation

        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}