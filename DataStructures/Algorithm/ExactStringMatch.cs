//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataStructures.Algorithm
//{
//    public static class ExactStringMatch
//    {
//        // http://www-igm.univ-mlv.fr/~lecroq/string/ (EXACT STRING MATCHING ALGORITHMS)
//        // https://www.youtube.com/watch?v=af1oqpnH1vA&ab_channel=%E5%A5%87%E4%B9%90%E7%BC%96%E7%A8%8B%E5%AD%A6%E9%99%A2 (最浅显易懂的 KMP 算法讲解)
//        // https://www.youtube.com/watch?v=dgPabAsTFa8&ab_channel=%E9%BB%84%E6%B5%A9%E6%9D%B0 (KMP字符串匹配算法1)
//        // https://www.youtube.com/watch?v=3IFxpozBs2I&ab_channel=%E9%BB%84%E6%B5%A9%E6%9D%B0 (KMP字符串匹配算法02)

//        /// <summary>
//        /// 用於在文本字串中搜尋模式字串
//        /// </summary>
//        /// <param name="text">文本字串</param>
//        /// <param name="pattern">模式字串</param>
//        /// <returns>返回匹配字串在文本字串中的起始位置，若沒有找到匹配的字串，則返回 -1</returns>
//        public static int BruteForce(string text, string pattern)
//        {
//            #region Description
//            // 暴力搜尋演算法是一種簡單而有效的方法，它會在兩個字串之間逐一比對每個字元，找出完全相同的字串。它的基本概念如下：
//            // 1. 將搜尋的字串（又稱為「模式字串」）與要被搜尋的字串（又稱為「文本字串」）進行比對。
//            // 2. 從文本字串的第一個字元開始，將模式字串與文本字串中的對應字元逐一比對。
//            // 3. 如果所有字元都完全相同，則找到匹配的字串。否則，將文本字串中的指針向右移一位，再次進行比對。
//            // 4. 重複步驟 2 和 3，直到找到匹配的字串，或者搜尋完整個文本字串。
//            // 這個演算法的時間複雜度為 O(nm)，其中 n 是文本字串的長度，m 是模式字串的長度。暴力搜尋演算法是一種簡單且有效的方法，但是在處理大型字串時可能不夠快速。
//            #endregion
//            // 取得文本字串的長度
//            int textLength = text.Length;
//            // 取得模式字串的長度
//            int patternLength = pattern.Length;
//            // 從文本字串的第一個字元開始，逐一檢查每個子字串是否等於模式字串
//            for (int i = 0; i < textLength - patternLength; i++)
//            {
//                // 將指針 pointer 設為 0，用於記錄目前檢查到的字元位置
//                int pointer = 0;
//                // 在文本字串的子字串與模式字串中的對應字元逐一比對
//                while (pointer < patternLength && text[i + pointer] == pattern[pointer])
//                {
//                    // 如果字元相同，則將指針向右移一位
//                    pointer++;
//                }
//                // 如果檢查完整個模式字串後，所有字元都完全相同
//                if (pointer == patternLength)
//                {
//                    // 則返回匹配字串在文本字串中的起始位置
//                    return i;
//                }
//            }
//            // 如果在整個文本字串中都沒有找到匹配的字串，則返回 -1
//            return -1;
//        }

//        public static int KMPsearch(string text, string pattern)
//        {
//            #region Description
//            // KMP（Knuth - Morris - Pratt）演算法是一種用於在文本字串中搜尋模式字串的演算法。
//            // 它使用一個類似模式字串的預先比對表（又稱為「部分匹配表」）來加速字串匹配的速度。
//            // KMP 演算法的基本概念如下：
//            // 1. 將搜尋的字串（又稱為「模式字串」）與要被搜尋的字串（又稱為「文本字串」）進行比對。
//            // 2. 建立一個類似模式字串的預先比對表，用於記錄每個位置的最長相同前綴（prefix）和後綴（suffix）的長度。
//            // 3. 在比對時，如果遇到不匹配的字元，就使用預先比對表將模式字串的指針移動到下一個可能匹配的位置。
//            // 4. 重複上述步驟直到找到匹配的字串，或者在文本字串中沒有找到匹配的字串。

//            // 在這個程式碼中，函數 KMPsearch() 接收兩個參數：文本字串 text 和模式字串 pattern。
//            // 它首先會建立一個預先比對表（也稱為「部分匹配表」），用於記錄每個位置的最長相同前綴（prefix）和後綴（suffix）的長度。
//            // 然後，它會在文本字串 text 中逐一比對模式字串 pattern 的對應字元。
//            // 如果遇到不匹配的字元，就使用預先比對表將模式字串的指針移動到下一個可能匹配的位置。這樣可以大幅提高字串匹配的效率，避免暴力搜尋算法的低效率。
//            #endregion
//            // 取得文本字串的長度
//            int textLength = text.Length;
//            // 取得模式字串的長度
//            int patternLength = pattern.Length;

//            // 建立部分匹配表
//            int[] kmpNext = new int[patternLength];
//            kmpNext[0] = -1;
//            int pointer = 0;
//            int i = 1;
//            while (i < patternLength)
//            {
//                if (pattern[i] == pattern[pointer])
//                {
//                    pointer++;
//                    kmpNext[i] = pointer;
//                    i++;
//                }
//                else
//                {
//                    if (pointer > 0)
//                    {
//                        pointer = kmpNext[pointer - 1];
//                    }
//                    else
//                    {
//                        kmpNext[i] = pointer;
//                        i++;
//                    }
//                }
//            }
//            // 逐一比對文本字串與模式字串的對應字元
//            int k = 0;
//            pointer = 0;
//            while (k < textLength)
//            {
//                if (text[k] == pattern[pointer])
//                {
//                    k++;
//                    pointer++;
//                }
//                if (pointer == patternLength)
//                {
//                    return k - pointer;
//                }
//                else
//                {
//                    if (pointer != 0)
//                    {
//                        pointer = kmpNext[pointer - 1];
//                    }
//                    else
//                    {
//                        k++;
//                    }
//                }
//            }
//            return -1;
//        }
//    }
//}
