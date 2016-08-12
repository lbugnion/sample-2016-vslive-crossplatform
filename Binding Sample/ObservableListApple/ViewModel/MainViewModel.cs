using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ObservableListApple.Model;

namespace ObservableListApple.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Item> Items
        {
            get;
            private set;
        }

        public MainViewModel()
        {
            Items = new ObservableCollection<Item>();
            _random = new Random();

            for (var index = 0; index < 8; index++)
            {
                var item = new Item
                {
                    Id = index,
                    IsToggled = index % 2 == 0
                };

                item.PropertyChanged += ItemPropertyChanged;
                Items.Add(item);
            }

            DisplayToggledItems();
        }

        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            DisplayToggledItems();
        }

        private void DisplayToggledItems()
        {
            var toggledItems = Items.Where(i => i.IsToggled);
            var result = toggledItems.Aggregate(string.Empty, (current, item) => current + (item.Id + " "));
            ToggledItems = result.Trim();
        }

        private RelayCommand _addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand
                    ?? (_addCommand = new RelayCommand(
                    () =>
                    {
                        lock (Items)
                        {
                            var item = new Item
                            {
                                Id = _random.Next(0, 1000),
                            };

                            item.PropertyChanged += ItemPropertyChanged;
                            Items.Add(item);
                        }
                    }));
            }
        }

        private RelayCommand<Item> _deleteCommand;

        public RelayCommand<Item> DeleteCommand
        {
            get
            {
                return _deleteCommand
                    ?? (_deleteCommand = new RelayCommand<Item>(
                    item =>
                    {
                        lock (Items)
                        {
                            if (Items.Contains(item))
                            {
                                item.PropertyChanged -= ItemPropertyChanged;
                                Items.Remove(item);
                                DisplayToggledItems();
                            }
                        }
                    },
                    item => item != null));
            }
        }


        private string _toggledItems;
        private Random _random;

        public string ToggledItems
        {
            get
            {
                if (string.IsNullOrEmpty(_toggledItems))
                {
                    return "No toggled items";
                }

                return _toggledItems;
            }
            set
            {
                Set(ref _toggledItems, value);
            }
        }
    }
}
