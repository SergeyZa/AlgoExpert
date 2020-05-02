using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoveElementToEndSolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoveElementToEnd.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MoveElementToEndEmptyTest()
        {
            var res = Program.MoveElementToEnd(new List<int>(), 3);
            Assert.IsTrue(res.Count == 0);
        }

        [TestMethod()]
        public void MoveElementToEndTest()
        {
            var data = new List<int>() { 2, 1, 2, 2, 2, 3, 4, 2 };
            var toMove = 2;
            var res = Program.MoveElementToEnd(data, toMove);
            Assert.IsTrue(res.TakeLast(data.Count(n => n == toMove)).All(n => n == toMove));
        }

        [TestMethod()]
        public void MoveElementToEndAbsentTest()
        {
            var data = new List<int>() { 1, 2, 4, 5, 6 };
            var toMove = 3;
            Program.MoveElementToEnd(data, toMove);
        }

        [TestMethod()]
        public void MoveElementToEndSameTest()
        {
            var data = new List<int>() { 3, 3, 3, 3, 3 };
            var toMove = 3;
            var res = Program.MoveElementToEnd(data, toMove);
            Assert.IsTrue(res.SequenceEqual(data));
        }

        [TestMethod()]
        public void MoveElementToEnd10Test()
        {
            var data = new List<int>() { 5, 1, 2, 5, 5, 3, 4, 6, 7, 5, 8, 9, 10, 11, 5, 5, 12 };
            var toMove = 5;
            var res = Program.MoveElementToEnd(data, toMove);
            Assert.IsTrue(res.TakeLast(data.Count(n => n == toMove)).All(n => n == toMove));
        }
    }
}