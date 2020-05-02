using System;
using System.Collections.Generic;

namespace ProductSum
{
    public class Program
    {
        public static int ProductSum(List<object> array)
        {
            return ProductSum(array, 0, 1);
        }
        public static int ProductSum(List<object> array, int sum, int depth)
        {
            var s = 0;
            foreach (var item in array)
            {
                switch (item)
                {
                    case int n:
                        s += depth * n;
                        break;
                    default:
                        s += depth * ProductSum((List<object>)item, sum, depth + 1);
                        break;
                }
            }
            return sum + s;
        }
    }
}