using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using XamBindingSample.Model;

namespace XamBindingSample.ViewModel
{
    public class ListsViewModel : ViewModelBase
    {
        private RelayCommand _addCommand;
        private RelayCommand<Item> _deleteCommand;
        private readonly Random _random;
        private string _toggledItems;

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

        public ObservableCollection<Item> Items
        {
            get;
            private set;
        }

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

        public ListsViewModel()
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

        private void DisplayToggledItems()
        {
            var toggledItems = Items.Where(i => i.IsToggled);
            var result = toggledItems.Aggregate(string.Empty, (current, item) => current + (item.Id + " "));
            ToggledItems = result.Trim();
        }

        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            DisplayToggledItems();
        }
    }
}