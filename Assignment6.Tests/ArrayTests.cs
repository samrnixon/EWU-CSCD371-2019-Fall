using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment6.Tests
{
    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        public void ArraySuccessfulInititalization_GoodCapacity()
        {
            var array = new Array<int>(5);
            Assert.AreEqual(5, array.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArrayInititalization_BadCapacity()
        {
            var array = new Array<int>(-2);
        }

        [DataTestMethod]
        [DataRow("Hello")]
        [DataRow("World")]
        public void ArrayAddItemString_Success(string addItem)
        {
            var array = new Array<string>(2)
            {
                addItem
            };

            Assert.IsTrue(array.Contains(addItem));
        }

        [DataTestMethod]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(7)]
        public void ArrayAddItemInt_Success(int addItem)
        {
            var array = new Array<int>(4)
            {
                addItem
            };
            Assert.IsTrue(array.Contains(addItem));
        }

        [TestMethod]
        public void ArrayAddMutipleItemsAtOnce_Success()
        {
            var array = new Array<int>(4)
            {
                1,
                2,
                3,
                4
            };

            Assert.AreEqual(4, array.Count);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArrayAddItemNull_Fail()
        {
            var array = new Array<string>(1);
            array.Add(null!);
        }

        [TestMethod]
        public void IndexOperator_Works()
        {
            string expected1 = "Hello World";
            string expected2 = "Hello Again";
            var array = new Array<string>(2)
            {
                "Hello World",
                "Hello Again"
            };

            Assert.AreEqual(expected1, array[0]);
            Assert.AreEqual(expected2, array[1]);
        }

        [TestMethod]
        public void ArrayForeach_Successful()
        {
            string mainString = "";
            string expected = "Hello World Hello Again C# is fun ";

            var array = new Array<string>(5)
            {
                "Hello World",
                "Hello Again",
                "C#",
                "is",
                "fun"
            };

            foreach(string s in array)
            {
                mainString += s + " ";
            }

            Assert.AreEqual(expected, mainString);
        }

        [TestMethod]
        public void ArrayForeach_Fail()
        {
            string mainString = "";
            string expected = "";

            var array = new Array<string>(5)
            {
                "Hello World",
                "Hello Again",
                "C#",
                "is",
                "fun"
            };

            foreach (string s in array)
            {
                mainString += s + " ";
            }

            Assert.AreNotEqual(expected, mainString);
        }

        [TestMethod]
        public void ArrayContainsAnInt_True_Success()
        {
            var array = new Array<int>(4)
            {
                1,
                2,
                3,
                4
            };

            bool testBoolGood = array.Contains(3);
            Assert.IsTrue(testBoolGood);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ArrayContainsValueDoesntExist_Throws()
        {
            var array = new Array<int>(4)
            {
                1,
                2,
                3,
                4
            };

            array.Contains(5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArrayContainsNull_False()
        {
            var array = new Array<string>(4)
            {
                "1",
                "2",
                "3",
                "4"
            };

            bool testBoolBad = array.Contains(null!);
        }

        [TestMethod]
        public void Array_ClearSuccessfully()
        {
            var array = new Array<string>(4)
            {
                "1",
                "2",
                "3",
                "4"
            };

            array.Clear();
            Assert.AreEqual(0, array.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArrayCopyTo_ArrayParameterPassedInIsNull_Fail()
        {
            var array = new Array<string>(4)
            {
                "Hello World",
                "Hello Again",
                "C#",
                "CSCD371"
            };

            array.CopyTo(null!, 0);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArrayCopyTo_IndexPassedInIsBad_Fail()
        {
            var array = new Array<string>(4)
            {
                "Hello World",
                "Hello Again",
                "C#",
                "CSCD371"
            };

            string[] arrayCopy = new string[4];

            array.CopyTo(arrayCopy, 7);
        }

        [TestMethod]
        public void ArrayCopyTo_GoodValuesEtc_Successful()
        {
            var array = new Array<string>(4)
            {
                "Hello World",
                "Hello Again",
                "C#",
                "CSCD371"
            };

            string[] arrayCopy = new string[4];

            array.CopyTo(arrayCopy, 0);

            Assert.IsTrue(arrayCopy.Contains("C#"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Array_RemoveValuePassedInIsNull_Fails()
        {
            var array = new Array<string>(4)
            {
                "Hello World",
                "Hello Again",
                "C#",
                "CSCD371"
            };

            array.Remove(null!);
        }

        [TestMethod]
        public void Array_RemoveValuePassedInIsDoesntExist_Fails()
        {
            var array = new Array<string>(4)
            {
                "Hello World",
                "Hello Again",
                "C#",
                "CSCD371"
            };

            Assert.IsFalse(array.Remove("Hello C#"));
        }

        [TestMethod]
        public void Array_RemoveValuePassedInIsGood_True()
        {
            var array = new Array<string>(4)
            {
                "Hello World",
                "Hello Again",
                "C#",
                "CSCD371"
            };

            Assert.IsTrue(array.Remove("Hello Again"));
        }
    }
}
