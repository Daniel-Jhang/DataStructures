namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region MagicSquare
            //Console.WriteLine("Magic Square");
            //MagicSquare.DrowMagicSquare(1);
            //Console.WriteLine();
            //MagicSquare.DrowMagicSquare(3);
            //Console.WriteLine();
            //MagicSquare.DrowMagicSquare(5);
            //Console.WriteLine();
            //MagicSquare.DrowMagicSquare(7);
            //Console.WriteLine();
            //MagicSquare.DrowMagicSquare(9);
            //Console.WriteLine();
            #endregion

            // TODO: 
            //FactorialInArray.CaculateFactorial(5);

            #region BinarySearch
            //Console.WriteLine("Binary Search");
            //int[] numbers = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21 }; // 必須先經過排序
            //Console.Write("Initial array is: ");
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    Console.Write(numbers[i] + " ");
            //}
            //Console.Write("\n請輸入想找的數字: ");
            //var inputNumber = Console.ReadLine();
            //var isInteger = int.TryParse(inputNumber, out int numberToFind);
            //if (isInteger)
            //{
            //    var position = BinarySearch.DoBinarySearch(numbers, numberToFind);
            //    if (position > 0)
            //    {
            //        Console.Write($"想找的數字在第{position + 1}個位置");
            //    }
            //    else
            //    {
            //        Console.Write($"找不到該數字");
            //    }
            //}
            #endregion

            #region Permutation
            //char[] charArray = new char[] { 'a', 'b', 'c', 'd' };
            //int start = 0;
            //int end = charArray.Length;
            //RecursivePermutation.Permutation(charArray, start, end);
            #endregion

            #region FibonacciSequence
            FibonacciSequence.GetFibonacciNumber(20);
            Console.WriteLine();
            Console.WriteLine(FibonacciSequence.RecursionFibonacci(20));
            #endregion
        }
    }
}