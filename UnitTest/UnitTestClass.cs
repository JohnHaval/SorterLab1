using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SorterLab1;

namespace UnitTest
{
    [TestClass]
    public class UnitTestClass
    {
        [TestMethod]
        public void TestAll()
        {
            int[] mustMas = { -7, -6, -3, 0, 6 };
            int[] mas = {-6, 6, 0, -7, -3 };
            int[] sortedMas = SorterLib.Sorter.SortOnUp(mas);
            string text = "Нечет";
            Assert.Equal(mustMas, sortedMas);
        }
    }
}
