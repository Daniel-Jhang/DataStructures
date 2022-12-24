using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Algorithm
{
    public class HanoiTowers
    {
        #region Description
        // 這段程式碼是在實現漢諾塔遊戲（Towers of Hanoi）的解決方案。漢諾塔遊戲是一個經典的 Recursive 算法題目。
        // 遊戲中有三根柱子( peg），每根柱子上有若干個圓盤（disk），每個圓盤都有一個大小，並且大小由下至上遞減。
        // 目標是將所有圓盤從一根柱子移到另一根柱子，且每次移動時必須遵守下列規則：
        //      1. 一次只能移動一個圓盤
        //      2. 不能將大圓盤放在小圓盤上面
        // 這段程式碼中的方法 Towers 定義了一個 Recursive函數，用於解決漢諾塔遊戲。它有四個參數：
        //      disksToMove：表示需要移動的圓盤數量。
        //      source：表示原始圓盤所在的柱子。
        //      auxiliary：表示輔助柱子。
        //      destination：表示目的地柱子。
        // 首先，如果 disksToMove 等於 1，則只有一個圓盤需要移動，這樣就可以直接進行移動，並 return。
        // 否則，先將除了最下面一個圓盤以外的所有圓盤（也就是 disksToMove - 1 個圓盤）從 source 移到 auxiliary，使用 destination 作為輔助柱子。
        // 然後將剩餘的最下面一個圓盤從 source 移到 destination。最後，再將先前移到 auxiliary 的 disksToMove - 1 個圓盤從 auxiliary 移到 destination，使用 source 作為輔助柱子。
        // 這樣的話，通過重複以上步驟，不斷地進行 Recursive，直到只剩下一個圓盤需要移動，然後再逐層返回。我們最終就可以將所有的圓盤從 source 移到 destination。
        // 這段程式碼的運作方式是利用了 Recursive 的概念。它首先將問題分解成較小的子問題，然後再求解這些子問題，最終合併成最終的解決方案。

        // 例如，假設原始狀態有三個圓盤，且分別在柱子 A、B 和 C 上。此時，disksToMove 為 3，source 為 A，auxiliary 為 B，destination 為 C。
        // 首先，將除了最下面一個圓盤以外的所有圓盤（也就是 2 個圓盤）從 A 移到 B，使用 C 作為輔助柱子。這樣會再次呼叫 Towers 方法，此次的參數是 disksToMove 為 2、source 為 A、auxiliary 為 C、destination 為 B。
        // 再將除了最下面一個圓盤以外的所有圓盤（也就是 1 個圓盤）從 A 移到 C，使用 B 作為輔助柱子。這樣會再次呼叫 Towers 方法，此次的參數是 disksToMove 為 1、source 為 A、auxiliary 為 B、destination 為 C。
        // 因為只剩下一個圓盤，所以直接將圓盤從 A 移到 C，並返回。
        // 將先前移到 B 的 1 個圓盤從 B 移到 C，使用 A 作為輔助柱子。這樣會再次呼叫 Towers 方法，此次的參數是 disksToMove 為 1、source 為 B、auxiliary 為 A、destination 為 C。
        // 因為只剩下一個圓盤，所以直接將圓盤從 B 移到 C，並返回。
        // 最終，三個圓盤就會被移到目的地柱子 C 上。

        // 公式解析:
        // How to move 2 disks? (n == 2)
        // A --1-> C        1
        // A --2-> B        2
        // C --1-> B        1

        // How to move 3 disks?
        // A --1-> C
        // A --2-> B         A --2-> B      2
        // C --1-> B
        // A --3-> C         A --3-> C      3
        // B --1-> A
        // B --2-> C        B --2-> C       2
        // A --1-> C

        // Recursion formula
        // A --(n-1)--> B
        // A --  (n)  --> C
        // B --(n-1)--> C
        #endregion
        /// <summary>
        /// Recursive program for the Tower of Hanoi Problem
        /// </summary>
        /// <param name="disksToMove">表示需要移動的圓盤數量</param>
        /// <param name="source">表示原始圓盤所在的柱子</param>
        /// <param name="auxiliary">表示輔助柱子</param>
        /// <param name="destination">表示目的地柱子</param>
        public static void Towers(int disksToMove, char source, char auxiliary, char destination)
        {
            // If only one disk, make the move and return
            if (disksToMove == 1)
            {
                Console.WriteLine($"Move disk No.1 from peg {source} to peg {destination}");
                return;
            }
            // Move top n-1 disks from A to B, using C as auxiliary
            Towers(disksToMove - 1, source, destination, auxiliary);
            // Move remaining disk from A to C
            Console.WriteLine($"Move disk No.{disksToMove} form peg {source} to peg {destination}");
            // Move n-1 disk from B to C, using A as auxiliary
            Towers(disksToMove - 1, auxiliary, source, destination);
        }
    }
}
