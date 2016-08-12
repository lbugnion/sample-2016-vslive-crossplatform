using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using XamBindingSample.Model;
using XamBindingSample.ViewModel;

namespace XamBindingSample
{
    [Activity(Label = "RecyclerView example", Icon = "@drawable/icon")]
    public partial class ListsActivity
    {
        // ReSharper disable once ConvertToConstant.Local
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private static bool _falseFlag = false;

        // ReSharper disable once CollectionNeverQueried.Local
        private readonly List<Binding> _bindings = new List<Binding>();

        private ObservableRecyclerAdapter<Item, CachingViewHolder> _adapter;

        public ListsViewModel Vm
        {
            get
            {
                return App.Locator.Lists;
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Lists);

            // Create the adapter using the default CachingViewHolder
            _adapter = Vm.Items.GetRecyclerAdapter(
                BindViewHolder,
                Resource.Layout.ItemTemplate,
                OnItemClick);

            MyRecycler.SetLayoutManager(new LinearLayoutManager(this));
            MyRecycler.SetAdapter(_adapter);

            _bindings.Add(
                this.SetBinding(
                    () => _adapter.SelectedItem.Name,
                    () => SelectedItemNameText.Text,
                    fallbackValue: "Nothing selected"));

            _bindings.Add(
                this.SetBinding(
                    () => Vm.ToggledItems,
                    () => ToggledItemsText.Text));

            AddButton.SetCommand(Vm.AddCommand);

            var selectedItemBinding = this.SetBinding(() => _adapter.SelectedItem);
            _bindings.Add(selectedItemBinding);
            RemoveButton.SetCommand(Vm.DeleteCommand, selectedItemBinding);

            // Subscribing to events to avoid linker issues in release mode ---------------------------------
            // This "fools" the linker into believing that the events are used.
            // In fact we don't even subscribe to them.
            // See https://developer.xamarin.com/guides/android/advanced_topics/linking/

            if (_falseFlag)
            {
                AddButton.Click += (s, e) =>
                {
                };
                RemoveButton.Click += (s, e) =>
                {
                };
            }
        }

        private void BindViewHolder(CachingViewHolder holder, Item item, int position)
        {
            var root = holder.FindCachedViewById<LinearLayout>(Resource.Id.LayoutRoot);

            if (item == _adapter.SelectedItem)
            {
                root.SetBackgroundColor(Color.Yellow);
            }
            else
            {
                root.SetBackgroundColor(Color.Transparent);
            }

            var text = holder.FindCachedViewById<TextView>(Resource.Id.ItemText);
            text.Text = item.Name;

            var check = holder.FindCachedViewById<CheckBox>(Resource.Id.ItemCheck);
            holder.DeleteBinding(check);

            var binding = new Binding<bool, bool>(
                item,
                () => item.IsToggled,
                check,
                () => check.Checked,
                BindingMode.TwoWay);

            holder.SaveBinding(check, binding);
        }

        private void OnItemClick(int oldPosition, View oldView, int newPosition, View newView)
        {
            if (oldView != null)
            {
                oldView.SetBackgroundColor(Color.Transparent);
            }

            newView.SetBackgroundColor(Color.Yellow);
        }
    }
}