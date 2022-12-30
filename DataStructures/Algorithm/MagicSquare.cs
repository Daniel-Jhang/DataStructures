using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Algorithm
{
    public static class MagicSquare
    {
        #region Description
        // 題目：製作N階(N為奇數)的魔方陣(magic squar)
        // 說明：
        //      三階魔方陣如下：
        //      6 1 8
        //      7 5 3
        //      2 9 4
        //      五階魔方陣如下：
        //      15    8   1   24   17
        //      16  14   7     5   23
        //      22  20 13     6     4
        //      3    21 19   12   10
        //      9      2 25   18   11

        // 魔方陣之定義為，方陣中的各個橫列(row)，直行(column)，對角斜線(diagonal)上之數字，加起來的和均相等。
        // N階(N為奇數)的魔方陣有個簡單的製作方法如下：
        // (1) 在最上面的row最中間處放1。設定k=2。
        // (2) 假設k-1放在(i, j)位置，則k應該放在(i-1, j-1)，亦即k-1的左上角。想像中，方陣的上下環狀相連，左右亦環狀相連。
        // (3) 若欲擺放處(i-1, j-1)先前已經放入資料，則將k放在(i+1, j)，亦即k-1之下方。
        // (4) 設定k=k+1。
        // (5) 重複步驟(2)至(4)，直到N^2個數字均已經放入魔方陣。
        // 請注意：魔方陣之製作方式為上下對稱，左右對稱，亦可整個方陣旋轉90度、180度、或270度。

        // 輸出：請印出一階、三階、五階、七階、九階的魔方陣。
        #endregion
        public static void DrowMagicSquare(int n)
        {
            if (n % 2 == 0)
            {
                Console.WriteLine("請輸入奇數");
                return;
            }

            int[][] magicSquare = new int[n][];
            for (int i = 0; i < n; i++)
            {
                magicSquare[i] = new int[n];
            }
            int x = n / 2;
            int y = n - 1;

            int count = 1;
            while (count <= n * n)
            {
                if (x == -1 && y == n) // x, y 的位置超出最右上角(因為是一直向上和向右移動，所以只需要考慮位置移動到最右上角)
                {
                    // 教學的寫法: (不太理解)
                    //x = 0;
                    //y = n - 2;

                    // 我的寫法:
                    // 先回到上一個位置，再向左移一格
                    x++; // (向下移動一格)
                    y--; // (向左移動一格)

                    y--; // (向左移動一格)
                }
                else
                {
                    if (y == n)
                    {
                        y = 0; // 重設 y，從最左(n)移動到最右(0)，相當於向右移一格 >
                    }
                    else if (x < 0) // x超出界(因為x是一直向上移動一格，因此只會向上超出界，來到 x = -1的位置)
                    {
                        x = n - 1; // 重設 x，使 x 的位置來到最下層 
                    }
                }

                if (magicSquare[x][y] != 0) // 這個格子已經填過數字了
                {
                    // 先回到上一個位置，再向左移一格
                    x++; // (向下移動一格)
                    y--; // (向左移動一格)

                    y--; // (向左移動一格)
                }
                else if (magicSquare[x][y] == 0) // 這一格還沒填過
                {
                    magicSquare[x][y] = count; // 把當前的數字填上
                    count++;
                    x--; // 向上移一格 ^
                    y++; // 向右移一格 >
                }
            }

            var flag = IsMagicSqure(magicSquare);
            if (flag)
            {
                PrintMatrix(magicSquare);
            }
            else
            {
                Console.WriteLine("這不符合MagicSquare的條件");
            }


        }

        public static bool IsMagicSqure(int[][] matrix)
        {
            bool result = IsMatrix(matrix);
            if (!result) { return false; }

            var sums = new List<int>();
            int sum;

            // 斜線 \
            sum = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                sum += matrix[i][i];
            }
            sums.Add(sum);

            // 斜線 /
            sum = 0;
            for (int i = 0, j = matrix.Length - 1; i < matrix.Length; i++, j--)
            {
                sum += matrix[i][j];
            }
            sums.Add(sum);

            // 橫列 _
            sum = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    sum += matrix[i][j];
                }
                sums.Add(sum);
                sum = 0;
            }

            // 直行 |
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    sum += matrix[j][i];
                }
                sums.Add(sum);
                sum = 0;
            }

            // 檢查是否全部相同
            for (int i = 0; i < sums.Count; i++)
            {
                if (sums[i] != sums[0])
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private static bool IsMatrix(int[][] matrix)
        {
            var result = true;
            var size = matrix.Length;
            foreach (var line in matrix)
            {
                if (line.Length != size)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                foreach (var item in row)
                {
                    var toPrint = item + " ";
                    if (item < 10)
                    {
                        toPrint = "0" + toPrint;
                    }
                    Console.Write(toPrint);
                }
                Console.WriteLine();
            }
        }
    }
}
