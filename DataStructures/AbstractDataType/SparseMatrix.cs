namespace DataStructures.AbstractDataType
{
    /// <summary>
    /// 稀疏矩陣的資料結構
    /// </summary>
    public class SparseMatrix
    {
        // https://www.geeksforgeeks.org/operations-sparse-matrices/
        // https://blog.onemid.net/blog/ds_fast_transpose/ (Faster Matrix Transpose)
        // https://blog.onemid.net/blog/ds_sparse_matrix_mul/ (SPARSE MATRIX MULTIPLICATION)

        /// <summary>
        /// 屬性
        /// </summary>
        private static int MaxTerms = 20;
        private int Rows { get; set; } // 矩陣中的 Row 數
        private int Cols { get; set; } // 矩陣中的 Column 數
        private int Terms { get; set; } // 矩陣中的非零 element 數
        private int Capacity { get; set; } = MaxTerms; // 稀疏矩陣數組的大小
        public MatrixTerm[] SparseMatrixArray { get; set; } // 存放稀疏矩陣中非零元素的 Array


        /// <summary>
        /// Constructor of Class SparseMatrix
        /// </summary>
        /// <param name="rows">矩陣中的 Row 數</param>
        /// <param name="cols">矩陣中的 Column 數</param>
        /// <param name="terms">矩陣中的非零 element 數</param>
        public SparseMatrix(int rows, int cols, int terms)
        {
            Rows = rows;
            Cols = cols;
            Terms = terms;
            SparseMatrixArray = new MatrixTerm[Capacity];
            for (int i = 0; i < Capacity; i++)
            {
                SparseMatrixArray[i] = new MatrixTerm();
            }
        }


        /// <summary>
        /// 轉置(Transpose)矩陣
        /// </summary>
        /// <returns>回傳轉置(Transpose)後的矩陣</returns>
        public SparseMatrix TypicalTranspose()
        {
            #region Description
            // 關於第一層迴圈：
            // 歷遍原始稀疏矩陣的 Column，目的是填完 b(result) 的每一個 Row
            // 其實就是我現在要讀取哪一個原始矩陣 column 當成我的轉置後矩陣的 row；
            // 比如說 i 就是我現在要瞄準 this.SparseMatrix 第 i 個 column 要寫進 b(result) 的第 i 個 row。

            // 關於第二層迴圈：
            // 歷遍每一個非 0 的 element
            // 就是說我每一個值都要看過，為啥要看過，要看下面的 if 在幹嘛：
            // 就是說，因為我要保證我轉置出來的 b 的資料 b.row 都是以遞增形式增長，所以我必須要從 b.row == 0 的時候開始看起，
            // 而 b.row 又是 a.col 轉置後的結果，所以會先去看 a data row 裡面所有（第二層迴圈的功用） a.col 等於 0 的情況（也就是 if (SparseMatrixArray[j].Column == i) 的功用了）先寫進去 b 裡面，
            // 隨時記錄 b 寫到哪一條了（也就是 currentRecord 的功用），以此類推。

            //就好比說，我今天有五種水果，香蕉、鳳梨、芭樂、蘋果和西瓜，全部混在一起要做分類，香蕉要放在香蕉區、鳳梨要放在鳳梨區等等，
            //典型的方法就好像是我今天先分香蕉，水果一顆一顆挑起來看，是香蕉的就挑出來放在香蕉區，其他不是香蕉的先不要管。
            #endregion
            SparseMatrix result = new SparseMatrix(Rows, Cols, Terms);
            result.Rows = Cols;
            result.Cols = Rows;
            result.Terms = Terms;
            if (Terms > 0)
            {
                int currentRecord = 0;
                for (int i = 0; i < Cols; i++) // 第一層迴圈，我們記作 first_loop
                {
                    for (int j = 0; j < Terms; j++) // 第二層迴圈裡面，我們記作 second_loop_inside
                    {
                        if (SparseMatrixArray[j].Column == i)
                        {
                            result.SparseMatrixArray[currentRecord].Row = i;
                            result.SparseMatrixArray[currentRecord].Column = SparseMatrixArray[j].Row;
                            result.SparseMatrixArray[currentRecord].Value = SparseMatrixArray[j].Value;
                            currentRecord++;
                        }
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// 以空間換取時間的方式，壓縮本來 Typical Sparse Matrix Transpose 方法所需時平方項次的時間複雜度
        /// </summary>
        /// <returns>回傳轉置(Transpose)後的矩陣</returns>
        public SparseMatrix FasterTranspose_v1()
        {
            #region Description
            // 演算法   | b[] 行為模式   | a[] 行為模式
            // Typical   | 按照順序寫    | 鎖定第 i 個 a.col，逐條挑出 a[].col == i 者，轉置，寫入 b[] 內。
            // Fast       | 跳著寫            | 逐條看，看了之後轉置，去看看要寫去 b[] 的哪邊

            // 這個演算法利用以空間換取時間的方式，壓縮本來 Typical Sparse Matrix Transpose 方法所需時平方項次的時間複雜度。
            // 簡單來說，在這個演算法裡面，我們利用額外的註記，去加速我們的運算。
            // 在 Fast 演算法時，我看完 a[] 其實就已經寫完 b[] 了；而 Typical 我還不知道要看幾遍 a[] 才能寫完 b[]。
            // 再以水果的例子說明，我今天也是有五種水果，香蕉、鳳梨、芭樂、蘋果和西瓜，全部混在一起要做分類，香蕉要放在香蕉區、鳳梨要放在鳳梨區等等，
            // 快速的方法就是我今天挑到啥水果就放到對應的區域裡就行了

            // 要如何實現「跳著寫」這個問題，我們就必須額外開一張表去註記「我們這個東西究竟要寫去哪裡」。
            // 所以說，在此，我們開兩個矩陣去註記一些東西：nonZeroRow和startingPos
            // nonZeroRow是註記每一個原始稀疏矩陣 col 裡面，有幾個 row 是有非零值的。
            // startingPos是註記這個原始稀疏矩陣 col 轉置後變成新的稀疏矩陣 row 後要從哪一個 b（新稀疏矩陣） index 開始寫起。
            #endregion
            SparseMatrix result = new SparseMatrix(Rows, Cols, Terms);
            int[] nonZeroRow = new int[Terms];
            int[] startingPosition = new int[Terms];

            result.Rows = Cols;
            result.Cols = Rows;
            result.Terms = Terms;

            // Step 1: nonZero element in row i of transpose(nonZero in column i of original matrix)
            // 計算原始稀疏矩陣每個 Column 中，所有非 0 element
            for (int i = 0; i < Terms; i++)
            {
                nonZeroRow[SparseMatrixArray[i].Column]++;
            }

            // Step 2
            // 每一個 startingPosition 都是由上一個 startingPosition 位置 和 上一個 nonZeroRow 的個數加總起來的新位置；
            // 因為我們有記錄每一條 col 所擁有的非 0 值元素個數，
            // 每一條 col 起始第一個非 0 元素值都會有一個 startingPosition 再加上該 col 擁有的非 0 值元素個數就是下一個 col 的startingPos位置。
            for (int i = 0; i < nonZeroRow.Length; i++)
            {
                if (i < nonZeroRow.Length - 1)
                {
                    startingPosition[i + 1] = startingPosition[i] + nonZeroRow[i];
                }
            }

            for (int i = 0; i < Terms; i++)
            {
                int j = startingPosition[SparseMatrixArray[i].Column]++;
                result.SparseMatrixArray[j].Row = SparseMatrixArray[i].Column;
                result.SparseMatrixArray[j].Column = SparseMatrixArray[i].Row;
                result.SparseMatrixArray[j].Value = SparseMatrixArray[i].Value;
            }
            return result;
        }
        public SparseMatrix FasterTranspose_v2()
        {

            SparseMatrix result = new SparseMatrix(Rows, Cols, Terms);
            int[] nonZeroRow = new int[Terms];
            int[] startingPosition = new int[Terms];

            result.Rows = Cols;
            result.Cols = Rows;
            result.Terms = Terms;
            for (int i = 0; i < Terms; i++)
            {
                nonZeroRow[SparseMatrixArray[i].Column]++;
            }

            // 和 v1 的差異在這
            startingPosition[0] = 0;
            for (int i = 1; i < Terms; i++)
            {
                startingPosition[i] = startingPosition[i - 1] + nonZeroRow[i - 1];
            }

            for (int i = 0; i < Terms; i++)
            {
                int j = startingPosition[SparseMatrixArray[i].Column]++;
                result.SparseMatrixArray[j].Row = SparseMatrixArray[i].Column;
                result.SparseMatrixArray[j].Column = SparseMatrixArray[i].Row;
                result.SparseMatrixArray[j].Value = SparseMatrixArray[i].Value;
            }
            return result;
        }


        /// <summary>
        /// 稀疏矩陣乘法(Sparse Matrix Multiplication)
        /// </summary>
        /// <param name="matrixB">要相乘的稀疏矩陣</param>
        /// <returns>回傳相乘後的稀疏矩陣</returns>
        public SparseMatrix? SparseMatrixMultiply_v1(SparseMatrix matrixB)
        {
            #region Description
            //            Matrix                   Row      Col          Val
            //                a                          i            k       該元素值  
            //                b                          k           j        該元素值
            // b的 transpose: newB          j           k       該元素值

            // Pseudocode
            //for (int i = 0; i < ATotalRows; i++)
            //{
            //    for (int j = 0; j < BTotalCols; j++)
            //    {
            //        int sum = 0;
            //        for (int k = 0; k < BTotalRows; k++)
            //        {
            //            sum += (A[i][k] + B[k][j]);
            //        }
            //        AB[i][j] = sum;
            //    }
            //}

            // 在列表式記法下，每列資料都記載一個三元資料集 < Row, Column, Value >，而這個列表遵循著 Row index 遞增排列，而若是在相同的 Row index 下，Column index 進行遞增排列的方式
            // 而因為我們矩陣乘法是 Matrix A 的 Rows 乘上 MatrixB 的 Cols，在這種稀疏矩陣記法中的 data row 都是採 row index 優先遞增排序方式可能會造成一些撰寫程式上的麻煩，
            // 不如我們就把 MatrixB 做一次的 transpose 把他的 col 轉成 row，這樣我們在乘法上雙方就都可以逐 data row 看（B 已經 transpose 完了，所以他的 row 基本上是先前未轉置前的 col），
            // 而不是一邊看 row 一邊看 col。
            #endregion
            if (Cols != matrixB.Rows)
            {
                Console.WriteLine("Can not multiply, invalid dimensions");
                return null;
            }

            int counter = 0;

            // Transpose matrixB 以比較 row 和 column 值
            matrixB = matrixB.FasterTranspose_v1();

            SparseMatrix result = new SparseMatrix(Rows, matrixB.Cols, Capacity);

            // 遍歷結果矩陣的所有 elements
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < matrixB.Cols; j++)
                {
                    // 計算乘積的 element value
                    int element = 0;
                    for (int k = 0; k < Cols; k++)
                    {
                        element += GetElement(i, k) * matrixB.GetElement(j, k);
                    }

                    // 如果 element value 不為 0，則將其加入到結果矩陣中
                    if (element != 0)
                    {
                        result.SetElement(i, j, element, counter);
                        counter++;
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// 取得矩陣中給定位置的元素
        /// </summary>
        /// <param name="row">目標矩陣的列</param>
        /// <param name="col">目標矩陣的行</param>
        /// <returns>回傳給定位置元素的值</returns>
        public int GetElement(int row, int col)
        {
            for (int i = 0; i < Terms; i++)
            {
                if (SparseMatrixArray[i].Row == row && SparseMatrixArray[i].Column == col)
                {
                    return SparseMatrixArray[i].Value;
                }
            }
            return 0;
        }


        /// <summary>
        /// 設定矩陣中給定位置的元素
        /// </summary>
        /// <param name="row">目標矩陣的列</param>
        /// <param name="col">目標矩陣的行</param>
        /// <param name="value">要設定的元素值</param>
        /// <param name="counter">Index</param>
        public void SetElement(int row, int col, int value, int counter)
        {
            // 初始化 MatrixTerm
            MatrixTerm[] tempArray = new MatrixTerm[Terms];
            for (int i = 0; i < Capacity; i++)
            {
                tempArray[i] = new MatrixTerm();
            }

            Array.Copy(SparseMatrixArray, tempArray, Terms);
            // 使用 Array.Resize()方法對新的 MatrixTerm Array 重新分配空間
            Array.Resize(ref tempArray, ++Terms);

            // 將新的 MatrixTerm Array 的值賦給 SparseMatrixArray 屬性
            SparseMatrixArray = tempArray;

            // 最後，我們在賦值的語句中，可以將要插入的元素的值赋给新的 MatrixTerm Array 的第 n 個元素
            tempArray[counter].Row = row;
            tempArray[counter].Column = col;
            tempArray[counter].Value = value;
            Terms--;
        }


        public SparseMatrix? SparseMatrixMultiply_v2(SparseMatrix matrixB)
        {
            if (Cols != matrixB.Rows)
            {
                Console.WriteLine("Can not multiply, invalid dimensions");
                return null;
            }

            // Transpose matrixB 以比較 row 和 column 值並在末尾添加它們
            matrixB = matrixB.FasterTranspose_v2();

            int aPos = 0;
            int bPos = 0;
            int counter = 0;

            // Rows X b.Cols 的結果矩陣但是 matrixB 已經被轉置(Transpose)，因此為 Rows X b.Rows
            SparseMatrix result = new SparseMatrix(Rows, matrixB.Rows, Capacity);

            // 遍歷 A 的所有元素
            for (aPos = 0; aPos < Terms;)
            {
                // 結果矩陣的當前 Rows
                int resultRow = SparseMatrixArray[aPos].Row;

                // 遍歷B的所有元素
                for (bPos = 0; bPos < matrixB.Terms;)
                {
                    // 結果矩陣的當前 Cols，matrixB 已經被轉置(Transpose)，因此用 matrixB 的 Row
                    int resultColumn = matrixB.SparseMatrixArray[bPos].Row;

                    // temporary pointers created to add all multiplied values to obtain current element of result matrix
                    int tempA = aPos;
                    int tempB = bPos;

                    int sum = 0;

                    // 遍歷具有相同行和列值的所有元素以計算結果[r]
                    while (tempA < Terms && SparseMatrixArray[tempA].Row == resultRow &&
                               tempB < matrixB.Terms && matrixB.SparseMatrixArray[tempB].Row == resultColumn)
                    {
                        if (SparseMatrixArray[tempA].Column < matrixB.SparseMatrixArray[tempB].Column)
                        {
                            // skip a
                            tempA++;
                        }
                        else if (SparseMatrixArray[tempA].Column > matrixB.SparseMatrixArray[tempB].Column)
                        {
                            // skip b
                            tempB++;
                        }
                        else
                        {
                            // same col, so multiply and increment
                            sum += SparseMatrixArray[tempA].Value * matrixB.SparseMatrixArray[tempB].Value;
                            tempA++;
                            tempB++;
                        }
                    }
                    // 插入在 result[r] 中獲得的總和
                    // 如果它不等於 0
                    if (sum != 0)
                    {
                        result.Insert(resultRow, resultColumn, sum, counter);
                        counter++;
                        Console.WriteLine(counter.ToString());
                    }

                    while (bPos < matrixB.Terms && matrixB.SparseMatrixArray[bPos].Row == resultColumn)
                    {
                        // jump to next column
                        bPos++;
                    }

                    while (aPos < Terms && SparseMatrixArray[aPos].Row == resultRow)
                    {
                        // jump to next row
                        aPos++;
                    }
                }
            }
            return result;
        }
        private void Insert(int r, int c, int val, int counter)
        {
            // invalid entry
            if (r > Rows || c > Cols)
            {
                Console.WriteLine("Wrong Entry");
            }
            else
            {
                // insert row value
                SparseMatrixArray[counter].Row = r;

                // insert col value
                SparseMatrixArray[counter].Column = c;

                // insert element's value
                SparseMatrixArray[counter].Value = val;

                //increment number of data in matrix
                //Terms++;
            }
        }


        /// <summary>
        /// 輸出稀疏矩陣
        /// </summary>
        public void PrintMatrix()
        {
            Console.WriteLine("Dimension: " + Rows + "x" + Cols);
            Console.WriteLine("Sparse Matrix: \nRow Column Value");
            var data = SparseMatrixArray;
            for (int i = 0; i < Terms; i++)
            {
                if (data[i].Row == 0)
                {
                    continue; // 如果 MatrixTerm 為空，則不印
                }
                Console.WriteLine(data[i].Row + "   " + data[i].Column + "      " + data[i].Value);
            }
        }
    }

    /// <summary>
    /// 紀載稀疏矩陣中非零元素 <Row, Column, Value> 的類別
    /// </summary>
    public class MatrixTerm
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int Value { get; set; }
    }
}
