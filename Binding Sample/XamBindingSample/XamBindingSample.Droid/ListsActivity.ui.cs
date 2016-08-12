using Android.Support.V7.Widget;
using Android.Widget;
using GalaSoft.MvvmLight.Views;

namespace XamBindingSample
{
    // In this partial Activity, we provide access to the UI elements.
    // This file is partial to keep things cleaner in the MainActivity.cs
    // See http://blog.galasoft.ch/posts/2014/11/structuring-your-android-activities/
    public partial class ListsActivity : ActivityBase
    {
        private RecyclerView _myRecycler;

        public RecyclerView MyRecycler
        {
            get
            {
                return _myRecycler
                       ?? (_myRecycler = FindViewById<RecyclerView>(Resource.Id.MyRecycler));
            }
        }

        private TextView _selectedItemNameText;

        public TextView SelectedItemNameText
        {
            get
            {
                return _selectedItemNameText
                       ?? (_selectedItemNameText = FindViewById<TextView>(Resource.Id.SelectedItemNameText));
            }
        }

        private TextView _toggledItemsText;

        public TextView ToggledItemsText
        {
            get
            {
                return _toggledItemsText
                       ?? (_toggledItemsText = FindViewById<TextView>(Resource.Id.ToggledItemsText));
            }
        }

        private Button _addButton;

        public Button AddButton
        {
            get
            {
                return _addButton
                       ?? (_addButton = FindViewById<Button>(Resource.Id.AddButton));
            }
        }

        private Button _removeButton;

        public Button RemoveButton
        {
            get
            {
                return _removeButton
                       ?? (_removeButton = FindViewById<Button>(Resource.Id.RemoveButton));
            }
        }
    }
}