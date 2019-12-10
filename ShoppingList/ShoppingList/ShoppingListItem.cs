using System;

namespace ShoppingList
{
    public class ShoppingListItem
    {
        public ShoppingListItem(string itemName)
        {
            ItemName = itemName ?? throw new ArgumentNullException(nameof(itemName));
        }

        public string ItemName { get; set; }
    }
}