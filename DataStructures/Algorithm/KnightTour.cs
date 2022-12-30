using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Algorithm
{
    public static class KnightTour
    {
        // https://www.geeksforgeeks.org/the-knights-tour-problem-backtracking-1/

        /// <summary>
        /// 使用 Recursive 的方式處理 KnightTour 問題
        /// </summary>
        public static void KnightTourByRecursive()
        {
            #region Description
            // Backtracking Algorithm for Knight’s tour
            // If all squares are visited
            //      print the solution
            // Else
            //      A) Add one of the next moves to solution vector and recursively check if this move leads to a solution.
            //          (A Knight can make maximum eight moves.We choose one of the 8 moves in this step).
            //      B) If the move chosen in the above step doesn't lead to a solution then remove this move from the solution vector and try other alternative moves.
            //      C) If none of the alternatives work then return false
            //          (Returning false will remove the previously added item in recursion and if false is returned by the initial call of recursion then "no solution exists" )

            // This function solves the Knight Tour problem using Backtracking.
            // This function mainly uses solveKnightTour() to solve the problem.
            // It returns false if no complete tour is possible, otherwise return true and prints the tour.
            // Please note that there may be more than one solutions, this function prints one of the feasible solutions.

            // 這段代碼實現了騎士巡迴(Knight Tour)問題的解決方案。
            // 這個問題是給定一個棋盤，要讓騎士按照規則移動，使得騎士能夠遍歷所有棋盤上的格子，且每個格子只能經過一次。
            // 解決方案使用了回溯法(Backtracking)。首先，建立一個棋盤並初始化。接著，定義騎士的 8 種移動方向，並設定起始位置。
            // 接著，使用遞迴函數solveKnightTour()來搜尋可行的解法。如果找不到解法，則輸出"Solution does not exist"；否則，輸出解法。
            #endregion
            // 定義棋盤大小
            const int BOARD_SIZE = 8;

            // 初始化棋盤
            int[,] board = new int[BOARD_SIZE, BOARD_SIZE];
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    board[i, j] = -1; // -1 當作騎士還沒走過
                }
            }

            // 定義騎士的下一步行動(可移動的方向，騎士有 8 種移動方向)
            //directionX[] 用於 x 坐標的下一個值
            //directionY[] 用於 y 坐標的下一個值
            int[] directionX = { 2, 1, -1, -2, -2, -1, 1, 2 };
            int[] directionY = { 1, 2, 2, 1, -1, -2, -2, -1 };

            // 定義起始位置，預設為棋盤的最左上角 [0, 0]的位置
            int startX = 0;
            int startY = 0;
            board[startX, startY] = 1; // 從 01 號開始數

            // 設定移動計數器
            int moveCounter = 2; // 接著 02 號，故設定為 2

            // 使用 Recursive 搜尋解法
            if (!solveKnightTour(startX, startY, moveCounter, board, directionX, directionY))
            {
                Console.WriteLine("Solution does not exist");
            }
            else
            {
                // 輸出結果
                PrintTheTour(board);
            }
        }
        /// <summary>
        /// KnightTourByRecursive 使用的的遞迴函數，用來搜尋 KnightTour 可行的解法
        /// </summary>
        /// <param name="startX">X 軸的起始位置</param>
        /// <param name="startY">Y 軸的起始位置</param>
        /// <param name="moveCounter">移動計數器</param>
        /// <param name="board">要處理的棋盤</param>
        /// <param name="directionX">定義騎士可移動的 X軸 方向</param>
        /// <param name="directionY">定義騎士可移動的 Y軸 方向</param>
        /// <returns></returns>
        public static bool solveKnightTour(int startX, int startY, int moveCounter, int[,] board, int[] directionX, int[] directionY)
        {
            #region Description
            //這段代碼實現了在棋盤上找尋騎士巡迴的解法的過程。首先，檢查是否已經找到了解法，如果是，則返回 true。
            //接著，取得棋盤的大小。然後，使用迴圈來枚舉所有可能的下一步(移動方向)。
            //接著，檢查下一步是否有效，也就是檢查下一步是否超出棋盤的範圍，且是否還沒有走過。如果是，則將騎士移動到新的位置，並以新的位置繼續搜尋。
            //如果不是，則返回 false。如果找到了解法，則返回 true；否則，回到上一個位置，並繼續搜尋。
            #endregion
            // 如果移動計數器等於棋盤大小，則找到解法
            // 註: 此處的 +1 是為配合起始號碼從原先的 00 改成 01 而加
            if (moveCounter == board.Length + 1)
            {
                return true;
            }

            // 取得棋盤大小
            int boardSize = board.GetLength(0);
            int nextX;
            int nextY;

            // 嘗試從當前坐標(NextX, NextY)開始的所有下一步(加上 directionX[i] 和 directionY[i] 的值)動作(移動方向)
            for (int i = 0; i < 8; i++)
            {
                nextX = startX + directionX[i];
                nextY = startY + directionY[i];

                // 檢查 NextX, NextY 是否是 N*N 棋盤的有效 indexes 
                if (nextX >= 0 && nextX < boardSize &&
                        nextY >= 0 && nextY < boardSize &&
                            board[nextX, nextY] == -1)
                {
                    // 將騎士移動到新位置，
                    board[nextX, nextY] = moveCounter;
                    // 並以新位置繼續搜尋
                    if (solveKnightTour(nextX, nextY, moveCounter + 1, board, directionX, directionY))
                    {
                        return true;
                    }
                    else
                    {
                        // 回溯 (backtracking)
                        // 回復到上一個位置，將當前的位置設定成 尚未走過(-1)
                        board[nextX, nextY] = -1;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 使用 Stack 來模擬 Recursive 的效果處理 KnightTour 問題
        /// </summary>
        public static void KnightTourByStack()
        {
            #region Description
            // 這段程式碼是使用 Stack 的 Knight Tour 程式，主要是透過模擬遞迴的方式，來尋找 Knight Tour 的解法。
            // 首先，宣告了一個大小為 8 x 8 的棋盤，並設定每個格子的初始值為 - 1，表示尚未走過。
            // 接著宣告了一個陣列 directionX 和 directionY，表示騎士可能移動的方向。
            // 接下來，建立一個 Stack stepStack，並將起始位置（0, 0）加入 Stack 中。接著，使用一個迴圈，循環直到 Stack 為空。
            // 在每次迴圈中，從 Stack 中取出最上面的位置（即目前要處理的位置），檢查它是否已經走過。如果尚未走過，則將騎士移動到新位置，並將所有可能的下一步位置加入 Stack 中。
            // 最後，判斷是否移動的次數等於棋盤的大小，如果是，則表示找到解法，並呼叫 PrintTheTour 函式印出解法；否則，輸出 "Solution does not exist" 的訊息。

            // 這段程式碼並沒有直接使用遞迴的方式，而是使用了 Stack 來實現相似的效果。
            // 在程式中，我們將所有可能的下一步位置加入 Stack 中，並在每次迴圈中取出最上面的位置，對它進行處理。
            // 這個過程類似於遞迴，因為我們不斷地重複處理目前的位置，直到完成整個 Knight Tour 為止。
            // 不過，這段程式碼並沒有直接使用遞迴，而是使用了 Stack 來模擬遞迴的過程。這種做法的優點在於，可以避免遞迴的問題，例如遞迴深度過深或是遞迴呼叫過多等問題。
            #endregion
            // 定義棋盤大小
            const int BOARD_SIZE = 8;

            // 初始化棋盤
            int[,] board = new int[BOARD_SIZE, BOARD_SIZE];
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    board[i, j] = -1; // -1 當作騎士還沒走過
                }
            }

            // 定義騎士的下一步行動(可移動的方向，騎士有 8 種移動方向)
            //directionX[] 用於 x 坐標的下一個值
            //directionY[] 用於 y 坐標的下一個值
            int[] directionX = { 2, 1, -1, -2, -2, -1, 1, 2 };
            int[] directionY = { 1, 2, 2, 1, -1, -2, -2, -1 };

            // 定義起始位置，預設為棋盤的最左上角 [0, 0]的位置
            int startX = 0;
            int startY = 0;

            // 設定移動計數器
            int moveCounter = 1; // 從 01 號開始數

            // 使用 Stack 實現非遞歸搜尋
            // 建立 Stack 物件
            Stack<BoardCell> stepStack = new Stack<BoardCell>();
            // 將起始位置加入 Stack 中
            stepStack.Push(new BoardCell(startX, startY));

            // 循環直到 Stack 為空
            while (stepStack.Count > 0)
            {
                // 取得目前的位置
                BoardCell currentPosition = stepStack.Pop();
                startX = currentPosition.x;
                startY = currentPosition.y;

                // 檢查目前的位置是否已經走過
                if (board[startX, startY] == -1)
                {
                    // 將騎士移動到新位置
                    board[startX, startY] = moveCounter;
                    moveCounter++;

                    // 將所有可能的下一步位置加入 Stack 中
                    for (int i = 0; i < 8; i++)
                    {
                        int nextX = startX + directionX[i];
                        int nextY = startY + directionY[i];

                        // 檢查下一步位置是否是 N*N 棋盤的有效 indexes 
                        if (nextX >= 0 && nextX < board.GetLength(0) &&
                                nextY >= 0 && nextY < board.GetLength(1))
                        {
                            stepStack.Push(new BoardCell(nextX, nextY));
                        }
                    }
                }
                //Console.WriteLine(stepStack.Count);
            }

            // 檢查是否找到解法
            if (moveCounter == BOARD_SIZE * BOARD_SIZE+1)
            {
                PrintTheTour(board);
            }
            else
            {
                Console.WriteLine("Solution does not exist");
            }
        }
        /// <summary>
        /// 印出 KnightTour 的結果
        /// </summary>
        /// <param name="tourMap">KnightTour 的結果</param>
        public static void PrintTheTour(int[,] tourMap)
        {
            // Print the tour
            for (int i = 0; i < tourMap.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < tourMap.GetUpperBound(1) + 1; j++)
                {
                    var toPrint = tourMap[i, j] + " ";
                    if (tourMap[i, j] < 10)
                    {
                        toPrint = "0" + toPrint;
                    }
                    Console.Write(toPrint);
                }
                Console.WriteLine();
            }
        }
    }

    public class BoardCell
    {
        public int x { get; set; }
        public int y { get; set; }
        public BoardCell(int X, int Y)
        {
            this.x = X;
            this.y = Y;
        }
    }
}
