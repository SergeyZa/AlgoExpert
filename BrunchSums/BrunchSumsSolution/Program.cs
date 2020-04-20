using System;
using System.Collections.Generic;

namespace BrunchSumsSolution
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static void BranchSum(BinaryTree root, int sum, List<int> list)
        {
            sum += root.value;
            if (root.left != null)
                BranchSum(root.left, sum, list);
            if (root.right != null)
                BranchSum(root.right, sum, list);
            if (root.left == null && root.right == null)
                list.Add(sum);
        }

        public static List<int> BranchSums(BinaryTree root)
        {
            var list = new List<int>();
            BranchSum(root, 0, list);
            return list;
        }
    }
}
