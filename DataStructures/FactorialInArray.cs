//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataStructures
//{
//    public static class FactorialInArray
//    {
//        #region Description
// https://www.includehelp.com/cpp-programs/find-factorial-of-large-numbers-using-array.aspx
//        // 題目：印出1到N之間所有整數之階乘(factorial)，N<=50
//        // 說明：
//        //      本題要求每一個N! 之值必須完全精確，不可以有誤差。換言之，資料儲存時，不可以使用浮點數(floating point)，只能使用整數(integer)。
//        //      由於資料型態為整數(integer)，受到位元個數之限制(可能為16 bits、32 bits或64bits)，存放的最大數值受到限制。
//        //      隨著N變大，N! 之值將無法放進單一整數變數中。例如32 bits整數，在無正負號的情形下，其最大值為232-1=4,294,967,295。當N>=13時，13!= 6,227,020,800已經無法存放。
//        //      故本題需使用整數的陣列(array) 來存放資料，並模擬整數乘法與加法運算。
//        //      例如，欲存放3264，以4個元素的陣列A來存放，結果如下：
//        //              |3	|2	|6	|4
//        //      此處，最右側的元素為陣列開頭元素A[0]，則上面的資料代表：
//        //              A[3]=3,  A[2]=2,  A[1]=6,  A[0]=4
//        //      事實上，此處的每個元素均可存放一個大於或等於10的整數資料 (16 bits、32 bits或64bits)。但是，我們只存放一個整數的某個位數 (即0至9)。
//        //      若欲進行乘法運算，如3264*25，其計算過程如下：
//        //      0      0      3      2      6      4
//        //    *                                       25
//        //      0	    0    75    50   150  100
//        //      個位數進位至十位數：
//        //      0	    0	  75	  50	 160	     0
//        //      十位數進位至百位數：
//        //      0	    0	  75	  66	     0	     0
//        //      百位數進位至千位數：
//        //      0	    0	  81	    6	     0	     0
//        //      千位數進位至萬位數：
//        //      0	    8	    1	    6       0      0

//        // 輸入格式：
//        // 共有數組測試資料，每一組在一行輸入一個整數N之值，0N50。最後一組N之值為0，不必列印輸出資料，代表測試資料結束。
//        // 輸出格式：
//        // 對於每一個N，印出1到N之間所有整數之階乘(共有N列)，每列印出一個階乘。所有印出的資料均需靠左置放。不同的N之間，以一個空白列隔開。
//        // 輸入範例：
//        // 6
//        // 10
//        // 0

//        // 輸出範例：
//        // 1!=1
//        // 2!=2
//        // 3!=6
//        // 4!=24
//        // 5!=120
//        // 6!=720

//        // 1!=1
//        // 2!=2
//        // 3!=6
//        // 4!=24
//        // 5!=120
//        // 6!=720
//        // 7!=5040
//        // 8!=40320
//        // 9!=362880
//        // 10!=3628800
//        #endregion

//        private static readonly int arraySize = 100;
//        public static void CaculateFactorial(int n)
//        {
//            int[] result = new int[arraySize];
//            result[0] = 1;
//            int pointer = 1;
//            for (int i = 2; i <= n; i++)
//            {
//                pointer = Fact(i, result, pointer);
//            }

//            for (int i = pointer - 1; i >= 0; i--)
//            {
//                Console.Write(result[i]);
//            }
//        }

//        private static int Fact(int x, int[] arrays, int pointer)
//        {
//            int c = 0;
//            for (int i = 0; i < pointer; i++)
//            {
//                int p = arrays[i] * x + c;
//                arrays[i] = p % 10;
//                c = p / 10;
//            }

//            while (c != 0)
//            {
//                arrays[pointer] = c % 10;
//                c = c / 10;
//                pointer++;
//            }

//            return pointer;
//        }
//    }
//}
