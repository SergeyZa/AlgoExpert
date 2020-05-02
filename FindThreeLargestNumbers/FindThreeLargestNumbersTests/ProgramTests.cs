using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindThreeLargestNumbersSolution;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FindThreeLargestNumbers.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void FindThreeLargestNumbersTest1()
        {
            var ret = Program.FindThreeLargestNumbers(new[] { 141, 1, 17, -7, -17, -27, 18, 541, 8, 7, 7 });

            Assert.IsTrue(ret.SequenceEqual(new[] { 18, 141, 541 }));
        }

        [TestMethod()]
        public void FindThreeLargestNumbersTest2()
        {
            var ret = Program.FindThreeLargestNumbers(new[] { 10, 5, 9, 10, 12 });

            Assert.IsTrue(ret.SequenceEqual(new[] { 10, 10, 12 }));
        }
    }
}