using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void MainWindowViewModel_GoodShoppingItemAdded_CountSuccess()
        {
            var mainWindowViewModel = new MainWindowViewModel();
            int initialListCount = mainWindowViewModel.ShoppingItems.Count; 
            mainWindowViewModel.ShoppingItems.Add(new ShoppingListItem("Chocolate Chips"));
            int afterListCount = mainWindowViewModel.ShoppingItems.Count;

            Assert.AreEqual(initialListCount + 1, afterListCount);
        }

        [TestMethod]
        public void MainWindowViewModel_GoodShoppingItemAdded_ContainsSuccess()
        {
            var mainWindowViewModel = new MainWindowViewModel();
            ShoppingListItem item = new ShoppingListItem("Pumpkin Pie");
            mainWindowViewModel.ShoppingItems.Add(item);

            var listTest = mainWindowViewModel.ShoppingItems;

            Assert.IsTrue(listTest.Contains(item));
        }

        [TestMethod]
        public void MainWindowViewModel_EmptySpaceItemAdded_AddsNothing()
        {
            var mainWindowViewModel = new MainWindowViewModel();
            ShoppingListItem item = new ShoppingListItem("");

            mainWindowViewModel.AddItemCommand.Execute(item);

            var listTest = mainWindowViewModel.ShoppingItems;

            Assert.IsTrue(!(listTest.Contains(item)));
        }

        [TestMethod]
        public void MainWindowViewModel_RemoveItem_Success()
        {
            var mainWindowViewModel = new MainWindowViewModel();
            var itemToRemove = new ShoppingListItem("Milk");
            mainWindowViewModel.SelectedItem = itemToRemove;
            mainWindowViewModel.RemoveItemCommand.Execute(itemToRemove);
            var listTest = mainWindowViewModel.ShoppingItems;

            Assert.IsFalse(listTest.Contains(itemToRemove));
        }
    }
}
