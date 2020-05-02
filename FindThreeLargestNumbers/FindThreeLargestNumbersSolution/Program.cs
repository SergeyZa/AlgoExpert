using System;

namespace FindThreeLargestNumbersSolution
{
    public class Program
    {
 	public static int[] FindThreeLargestNumbers(int[] array)
	{
		var ret = new [] {-1, -1, -1};
		for (var j = 2; j > -1; j--)
		{
			for (var i = 0; i < array.Length; i++)
			{
				if (( ret[j] == -1 || array[i] > array[ret[j]]) && (j == 2 || (array[i] <= array[ret[j + 1]] && i != ret[j + 1])))
					ret[j] = i;
			}
		}
		return new [] {array[ret[0]], array[ret[1]], array[ret[2]]};
	}
   }
}
