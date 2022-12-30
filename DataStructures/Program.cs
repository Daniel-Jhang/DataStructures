using DataStructures.AbstractDataType;
using DataStructures.Algorithm;

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

            #region TODO: FactorialInArray

            #endregion

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
            //FibonacciSequence.GetFibonacciNumber(20);
            //Console.WriteLine();
            //Console.WriteLine(FibonacciSequence.RecursionFibonacci(20));
            #endregion

            #region HanoiTowers
            //HanoiTowers.Towers(3, 'A', 'B', 'C');
            #endregion

            #region SelectionSort
            //List<int> numbers = new List<int> { 56, 1, 99, 67, 89, 23, 44, 12, 78, 34 };
            //var result = SelectionSort.DoSelectionSort(numbers).ToList();
            //foreach (var item in result)
            //{
            //    Console.Write(item + " ");
            //}

            //SelectionSort.DoSelectionSort_V2(numbers);
            //foreach (var item in numbers)
            //{
            //    Console.Write(item + " ");
            //}
            #endregion

            #region TODO: TSet

            #endregion

            #region SparseMatrix
            //SparseMatrix sparseMatrixA = new SparseMatrix(6, 6, 6);
            //sparseMatrixA.SparseMatrixArray[0].Row = 1;
            //sparseMatrixA.SparseMatrixArray[0].Column = 3;
            //sparseMatrixA.SparseMatrixArray[0].Value = 3;
            //sparseMatrixA.SparseMatrixArray[1].Row = 1;
            //sparseMatrixA.SparseMatrixArray[1].Column = 5;
            //sparseMatrixA.SparseMatrixArray[1].Value = 4;
            //sparseMatrixA.SparseMatrixArray[2].Row = 2;
            //sparseMatrixA.SparseMatrixArray[2].Column = 3;
            //sparseMatrixA.SparseMatrixArray[2].Value = 5;
            //sparseMatrixA.SparseMatrixArray[3].Row = 2;
            //sparseMatrixA.SparseMatrixArray[3].Column = 4;
            //sparseMatrixA.SparseMatrixArray[3].Value = 7;
            //sparseMatrixA.SparseMatrixArray[4].Row = 4;
            //sparseMatrixA.SparseMatrixArray[4].Column = 2;
            //sparseMatrixA.SparseMatrixArray[4].Value = 2;
            //sparseMatrixA.SparseMatrixArray[5].Row = 4;
            //sparseMatrixA.SparseMatrixArray[5].Column = 3;
            //sparseMatrixA.SparseMatrixArray[5].Value = 6;

            //SparseMatrix sparseMatrixB = new SparseMatrix(6, 3, 5);
            //sparseMatrixB.SparseMatrixArray[0].Row = 1;
            //sparseMatrixB.SparseMatrixArray[0].Column = 1;
            //sparseMatrixB.SparseMatrixArray[0].Value = 2;
            //sparseMatrixB.SparseMatrixArray[1].Row = 3;
            //sparseMatrixB.SparseMatrixArray[1].Column = 1;
            //sparseMatrixB.SparseMatrixArray[1].Value = 3;
            //sparseMatrixB.SparseMatrixArray[2].Row = 4;
            //sparseMatrixB.SparseMatrixArray[2].Column = 1;
            //sparseMatrixB.SparseMatrixArray[2].Value = 4;
            //sparseMatrixB.SparseMatrixArray[3].Row = 4;
            //sparseMatrixB.SparseMatrixArray[3].Column = 2;
            //sparseMatrixB.SparseMatrixArray[3].Value = 7;
            //sparseMatrixB.SparseMatrixArray[4].Row = 5;
            //sparseMatrixB.SparseMatrixArray[4].Column = 1;
            //sparseMatrixB.SparseMatrixArray[4].Value = 1;
            //Console.WriteLine("Matrix before Transpose");
            //sparseMatrixA.PrintMatrix();
            //var result = sparseMatrixA.TypicalTranspose();
            //Console.WriteLine("Matrix after Transpose");
            //result.PrintMatrix();

            //Console.WriteLine("Matrix before FasterTranspose");
            //sparseMatrixA.PrintMatrix();
            //var fasterResult = sparseMatrixA.FasterTranspose_v1();
            //Console.WriteLine("Matrix after FasterTranspose");
            //fasterResult.PrintMatrix();

            //Console.WriteLine("Matrix before Multiplication");
            //sparseMatrixA.PrintMatrix();
            //var multiplyResult = sparseMatrixA.SparseMatrixMultiply_v1(sparseMatrixB);
            //Console.WriteLine("Matrix after Multiplication");
            //multiplyResult.PrintMatrix();
            #endregion

            #region TODO: ExactStringMatch
            //string template = "GCATCGCAGAGAGTATACAGTACG";
            //string primer = "GCAGAGAG";
            //var bruteForceResult = ExactStringMatch.BruteForce(template, primer);
            //if (bruteForceResult > 0)
            //{
            //    Console.WriteLine($"設計的Primer({primer})，在Template: {template} 中，找到符合的Binding site，在第 {bruteForceResult + 1} 到 {bruteForceResult + primer.Length} 的位置");
            //}
            //else
            //{
            //    Console.WriteLine("Primer找不到Binding site");
            //}
            #endregion

            #region KnightTour
            //Console.WriteLine("使用 Recursive 來解 KnightTour 問題");
            //KnightTour.KnightTourByRecursive();
            //Console.WriteLine("\n使用 Stack     來解 KnightTour 問題");
            //KnightTour.KnightTourByStack();
            #endregion
        }
    }
}