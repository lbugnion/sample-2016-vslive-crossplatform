using System;
using System.Collections.Generic;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using ObservableListApple.Layout;
using ObservableListApple.Model;
using ObservableListApple.ViewModel;
using UIKit;

namespace ObservableListApple
{
    // ReSharper disable once InconsistentNaming
	partial class UITableViewTableSourceController : UITableViewController
	{
	    private const string ReuseId = "SampleID";

        private readonly List<Binding> _bindings = new List<Binding>();
        private ObservableTableViewSource<Item> _source;
        private HeaderForTableView _headerView;

        private MainViewModel Vm
        {
            get
            {
                return Application.Locator.Main;
            }
        }

        public UITableViewTableSourceController (IntPtr handle) : base (handle)
		{
		}

	    public override void ViewDidLoad()
	    {
            base.ViewDidLoad();

            _source = Vm.Items.GetTableViewSource(
                BindTestTableViewCell,
                ReuseId,
                factory: () => new TableViewSourceEx());

            TableView.RegisterClassForCellReuse(typeof(TestTableViewCell), new NSString(ReuseId));

            _source.GetHeightForHeaderDelegate = () => 50;
            _source.GetViewForHeaderDelegate = () =>
            {
                _headerView = new HeaderForTableView();

                _bindings.Add(
                    this.SetBinding(
                        () => _source.SelectedItem.Name,
                        () => _headerView.SelectedItemLabel.Text,
                        fallbackValue: "Nothing yet"));

                _bindings.Add(
                    this.SetBinding(
                        () => Vm.ToggledItems,
                        () => _headerView.ToggledItemsLabel.Text));

                return _headerView;
            };

            TableView.Source = _source;

            var addButton = new UIBarButtonItem
            {
                Title = "Add"
            };
            addButton.SetCommand(Vm.AddCommand);

            var delButton = new UIBarButtonItem
            {
                Title = "Del"
            };

            var selectedItemBinding = this.SetBinding(() => _source.SelectedItem);
            _bindings.Add(selectedItemBinding);
            delButton.SetCommand(Vm.DeleteCommand, selectedItemBinding);

            NavigationItem.RightBarButtonItems = new[]
            {
                delButton,
                addButton,
            };
        }

        private void BindTestTableViewCell(UITableViewCell cell, Item item, NSIndexPath path)
        {
            var castedCell = (TestTableViewCell)cell;
            castedCell.TitleLabel.Text = item.Name;

            castedCell.SwitchBinding?.Detach();

            castedCell.SwitchBinding = new Binding<bool, bool>(
                item,
                () => item.IsToggled,
                castedCell,
                () => castedCell.OnSwitch.On,
                BindingMode.TwoWay);
        }
    }
}
