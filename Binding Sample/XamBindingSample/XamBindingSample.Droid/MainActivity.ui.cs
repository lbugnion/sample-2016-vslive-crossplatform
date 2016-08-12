using Android.Widget;
using GalaSoft.MvvmLight.Views;

namespace XamBindingSample
{
    // In this partial Activity, we provide access to the UI elements.
    // This file is partial to keep things cleaner in the MainActivity.cs
    // See http://blog.galasoft.ch/posts/2014/11/structuring-your-android-activities/
    public partial class MainActivity : ActivityBase
    {
        private Button _bindingsButton;

        public Button BindingsButton
        {
            get
            {
                return _bindingsButton
                       ?? (_bindingsButton = FindViewById<Button>(Resource.Id.BindingsButton));
            }
        }

        private Button _commandsButton;

        public Button CommandsButton
        {
            get
            {
                return _commandsButton
                       ?? (_commandsButton = FindViewById<Button>(Resource.Id.CommandsButton));
            }
        }

        private Button _listsButton;

        public Button ListsButton
        {
            get
            {
                return _listsButton
                       ?? (_listsButton = FindViewById<Button>(Resource.Id.ListsButton));
            }
        }
    }
}