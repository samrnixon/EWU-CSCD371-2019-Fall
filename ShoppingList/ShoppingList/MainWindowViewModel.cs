using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace ShoppingList
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private string _ItemAdd = "";
        public string ItemAdd
        {
            get => _ItemAdd;
            set => SetProperty(ref _ItemAdd, value);
        }

        private ShoppingListItem _SelectedItem = null!;
        public ShoppingListItem SelectedItem
        {
            get => _SelectedItem;
            set => SetProperty(ref _SelectedItem, value);
        }

        public ObservableCollection<ShoppingListItem> ShoppingItems { get; } = new ObservableCollection<ShoppingListItem>();

        private void SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null!)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ICommand AddItemCommand { get; }
        public ICommand RemoveItemCommand { get; }

        private bool CanExecute { get; set; }

        public MainWindowViewModel()
        {
            RemoveItemCommand = new Command(OnRemoveItem);
            AddItemCommand = new Command(OnAddItem);

            ShoppingItems.Add(new ShoppingListItem("Milk"));
            ShoppingItems.Add(new ShoppingListItem("Bread"));
            ShoppingItems.Add(new ShoppingListItem("Eggs"));
        }

        private void OnAddItem()
        {
            if (!(_ItemAdd.Length == 0))
            {
                ShoppingListItem newItem = new ShoppingListItem(_ItemAdd);
                ShoppingItems.Add(newItem);
            }
        }

        private void OnRemoveItem()
        {
            if(!(ShoppingItems is null))
            {
                ShoppingItems.Remove(SelectedItem);
                CanExecute = true;
            }
        }
    }
}
