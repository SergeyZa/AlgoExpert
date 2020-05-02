using Microsoft.VisualStudio.TestTools.UnitTesting;
using CeasarCipherEncryptorSolution;
using System;
using System.Collections.Generic;
using System.Text;

namespace CeasarCipherEncryptor.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void CaesarCypherEncryptorTest()
        {
            Assert.AreEqual("zab", Program.CaesarCypherEncryptor("xyz", 2));
        }
    }
}