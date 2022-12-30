using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.AbstractDataType
{
    public class NaturalNumber
    {
        bool IsZero(int x)
        {
            if (x == 0) { return true; }
            else { return false; }
        }

        bool Equal(int x, int y)
        {
            return x == y;
        }

        int Add(int x, int y)
        {
            if (x + y <= int.MaxValue)
            {
                return x + y;
            }
            else
            {
                return int.MaxValue;
            }
        }

        int Successor(int x)
        {
            return x + 1;
        }
    }
}
