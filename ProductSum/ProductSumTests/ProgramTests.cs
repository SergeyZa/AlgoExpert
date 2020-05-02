using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductSum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductSum.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void ProductSumTest()
        {
            var array = new List<object>
            {
                5,
                2,
                new List<object>
                {
                    7,
                    -1,
                },
                3,
                new List<object>
                {
                    6,
                    new List<object>
                    {
                        -13,
                        8
                    },
                    4
                }
            };
            Assert.AreEqual(12, Program.ProductSum(array));
        }
    }
}