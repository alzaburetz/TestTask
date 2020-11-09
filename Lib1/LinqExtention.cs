using System;
using System.Collections.Generic;
using System.Text;

namespace System.Linq
{
    public static class LinqExtention
    {
        public static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            T[] result = new T[length];
            Array.Copy(array, offset, result, 0, length);
            return result;
        }

        public static int MultiplyInteger(this int[] array)
        {
            int result = 1;
            foreach (var item in array)
            {
                result *= item;
            }
            if (result > 1)
            {
                return result;
            }
            else
            {
                return -1;
            }
        }
    }
}
