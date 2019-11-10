using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Assignment6.Tests
{
    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        public void ArraySuccessfulInititalizationGoodCapacity()
        {
            var array = new Array<int>(5);
            Assert.AreEqual(5, array.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArrayInititalizationBadCapacity()
        {
            var array = new Array<int>(-2);
        }

        [DataTestMethod]
        [DataRow("Hello")]
        [DataRow("World")]
        public void ArrayAddItemStringSuccess(string addItem)
        {
            var array = new Array<string>(2);
            array.Add(addItem);

            Assert.IsTrue(array.Contains(addItem));
        }

        [DataTestMethod]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(7)]
        public void ArrayAddItemIntSuccess(int addItem)
        {
            var array = new Array<int>(4);
            array.Add(addItem);
            Assert.IsTrue(array.Contains(addItem));
        }

        [TestMethod]
        public void ArrayAddMutipleItemsAtOnce()
        {
            var array = new Array<int>(4);
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);

            Assert.AreEqual(4, array.Count);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArrayAddItemNullFail()
        {
            var array = new Array<string>(1);
            array.Add(null);
        }
    }
}
