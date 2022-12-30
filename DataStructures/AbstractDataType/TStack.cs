
namespace DataStructures.AbstractDataType
{
    public class TStack<T>
    {
        // Data 是一個泛型 Array，用來儲存 Stack 中的資料
        private T[] Data { get; set; }
        // Top 是一個整數，用來追蹤 Stack 最後加入元素的位置
        private int Top { get; set; }
        // Size 是一個整數，用來追蹤 Stack 的大小
        private int Size { get; set; }

        /// <summary>
        /// TStack 的建構函式，接受一個整數 size 為參數，它會建立一個大小為 size 的泛型 Aarray，並將 Stack Top 的位置初始化為 -1
        /// </summary>
        /// <param name="size">設定 Stack 的大小</param>
        public TStack(int size)
        {
            Data = new T[size];
            Top = -1;
            Size = size;
        }
        /// <summary>
        /// 向 Stack 中添加新元素，它接受一個泛型參數 item，表示要加入 Stack 中的元素
        /// </summary>
        /// <param name="item">要添加到 Stack 的元素</param>
        /// <exception cref="StackOverflowException">已達到 Stack 的設定的空間上限</exception>
        public void Push(T item)
        {
            // 如果 Stack Top 的位置已經到了 Stack 的最大大小，就拋出 StackOverflowException 例外
            if (Top == Size - 1)
            {
                throw new StackOverflowException();
            }
            // 將 Stack Top 的位置加 1，並將新元素加入 Stack 中
            Top++;
            Data[Top] = item;
        }
        /// <summary>
        /// 從 Stack 中取出元素
        /// </summary>
        /// <returns>返回 Stack 中最後添加的元素</returns>
        /// <exception cref="InvalidOperationException">Stack 已不包含任何元素，無法再取出元素</exception>
        public T Pop()
        {
            // 如果 Stack Top 的位置為 -1，就拋出 InvalidOperationException 例外，表示 Stack 已經為空
            if (Top == -1)
            {
                throw new InvalidOperationException("The stack is empty.");
            }
            // 將 Stack Top 的元素存入變數 item 中，再將 Stack Top 的位置減 1
            T item = Data[Top];
            Top--;
            // 回傳變數 item。
            return item;
        }
        /// <summary>
        /// 查看 Stack 中最後添加的元素，不取出元素
        /// </summary>
        /// <returns>返回 Stack 中最後添加的元素</returns>
        /// <exception cref="InvalidOperationException">Stack 已不包含任何元素，無法再取出元素</exception>
        public T Peek()
        {
            // 如果 Stack Top 的位置為 -1，就拋出 InvalidOperationException 例外，表示 Stack 已經為空
            if (Top == -1)
            {
                throw new InvalidOperationException("The stack is empty");
            }
            // 回傳最後加入的元素
            return Data[Top];
        }
        /// <summary>
        /// 清空當前 Stack
        /// </summary>
        public void Clear()
        {
            // 將 Stack Top 的位置設為 -1
            Top = -1;
        }
        /// <summary>
        /// 檢查 Stack 是否含有元素
        /// </summary>
        /// <returns>返回 True 代表 Stack 含有元素，反之返回 False 代表 Stack 不為空</returns>
        public bool IsEmpty()
        {
            // 如果 Stack Top 的位置為 -1，則回傳 true；否則回傳 false。
            return Top == -1;
        }
    }
}
