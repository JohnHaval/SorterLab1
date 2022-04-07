using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SorterLab1;
using SorterLib;

namespace UnitTest
{
    [TestClass]
    public class UnitTestClass
    {
        [TestMethod]
        public void TestSort()
        {
            int[] mustMas = { -7, -6, -3, 0, 6 };
            int[] mas = {-6, 6, 0, -7, -3 };
            int[] sortedMas = Sorter.SortOnUp(mas);
            CollectionAssert.AreEqual(mustMas, sortedMas);
        }
        [TestMethod]
        public void TestEven()
        {
            string text = "Нечет";
            Assert.AreEqual(text, MainWindow.CheckEven(-7, 6));
        }
    }
}
