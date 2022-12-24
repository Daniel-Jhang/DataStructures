using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Algorithm
{
    public class SelectionSort
    {
        // 用Selection Sort演算法對List的元素做排序
        public static List<int> DoSelectionSort(List<int> list)
        {
            List<int> newList = new List<int> { }; // 建立新List
            int counter = list.Count;
            for (int i = 0; i < counter; i++) // 走訪原串列
            {
                int smallest = FindSmallest(list); // 找出最小值
                newList.Add(smallest); // 把找到的最小值加到新List中
                list.Remove(smallest); // 把該值從原串列移除
            }
            return newList; // 回傳結果
        }

        // 在List中找出最小值
        private static int FindSmallest(List<int> list)
        {
            // 預設第0個element是最小值
            int smallest = list[0];

            // 歷遍整個List
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < smallest) // 如果遇到更小的值
                {
                    smallest = list[i]; // 記下目前的最小值
                }
            }
            return smallest; // 跑完for loop後，回傳最小值
        }

        public static void DoSelectionSort_V2(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] > list[j])
                    {
                        // swap
                        var temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }
    }
}
