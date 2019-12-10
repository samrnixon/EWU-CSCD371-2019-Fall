using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass]
    public class VisibilityConverterTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void VisibilityConverter_CovertBackThrowsException()
        {
            var visibility = new VisibilityConverter().ConvertBack(null,null,null,null);
        }

        [TestMethod]
        public void VisibilityConverter_ConvertVisibility_VisibleSuccess()
        {
            ShoppingListItem shoppingListItem = new ShoppingListItem("");

            Assert.AreEqual("Visible", new VisibilityConverter().Convert(shoppingListItem,null,null,null));
        }

        [TestMethod]
        public void VisibilityConverter_ConvertVisibility_HiddenSuccess()
        {
            object notShoppingListItem = new object();

            Assert.AreEqual("Hidden", new VisibilityConverter().Convert(notShoppingListItem, null, null, null));
        }
    }
}
