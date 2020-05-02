using System;
using System.Collections.Generic;

namespace MoveElementToEndSolution
{
    public class Program
    {
        public static List<int> MoveElementToEnd(List<int> array, int toMove)
        {
            if (array.Count < 1)
                return array;
            var start = 0;
            var end = array.Count - 1;
            while (start < end)
            {
                while (start < end && array[end] == toMove)
                    end--;
                if (array[start] == toMove)
                {
                    var t = array[end];
                    array[end] = array[start];
                    array[start] = t;
                }
                start++;
            }
            return array;
        }
    }
}
