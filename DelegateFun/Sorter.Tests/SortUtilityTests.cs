using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static Sorter.SortUtility;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtilNullArray_Fail()
        {
            SortUtility sortUtility = new SortUtility();
            sortUtility.SelectionSortUtil(null!, null!);
        }

        [TestMethod]
        public void SortUtil_SortAscending_UsingAnAnonymousMethod()
        {
            int[] array = new int[] { 3, 34, 7, 45, 8, 99, 21 };
            int[] expected = new int[] { 3, 7, 8, 21, 34, 45, 99 };

            Analyze analyze = delegate (int x, int y)
            {
                return x < y;
            };

            SortUtility sortUtility = new SortUtility();

            array = sortUtility.SelectionSortUtil(array, analyze);

            CollectionAssert.AreEqual(array, expected);
        }

        [TestMethod]
        public void SortUtil_SortDescending_UsingALambdaExpression()
        {
            int[] array = new int[] { 78, 4, 9, 77, 23, 100 };
            int[] expected = new int[] { 100, 78, 77, 23, 9, 4 };

            SortUtility sortUtility = new SortUtility();

            array = sortUtility.SelectionSortUtil(array, ((int x, int y) => x > y));

            CollectionAssert.AreEqual(array, expected);
        }

        [TestMethod]
        public void SortUtil_SortAscending_UsingALambdaStatement()
        {
            int[] array = new int[] { 20, 1, 765, 888, 999, 234, 453 };
            int[] expected = new int[] { 1, 20, 765, 888, 999, 234, 453 };

            SortUtility sortUtility = new SortUtility();

            array = sortUtility.SelectionSortUtil(array, (x, y) => 
            {
                return x < 50;
            });

            CollectionAssert.AreEqual(array, expected);
        }
    }
}
