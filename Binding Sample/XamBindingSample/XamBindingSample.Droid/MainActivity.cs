using Android.App;
using Android.OS;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using XamBindingSample.ViewModel;

namespace XamBindingSample
{
    [Activity(Label = "Bindings Sample MVVM Light", MainLauncher = true, Icon = "@drawable/icon")]
    public partial class MainActivity
    {
        public INavigationService Nav
        {
            get
            {
                return ServiceLocator.Current.GetInstance<INavigationService>();
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            App.Initialize();

            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            BindingsButton.Click += (s, e) =>
            {
                Nav.NavigateTo(ViewModelLocator.BindingsPageKey);
            };

            CommandsButton.Click += (s, e) =>
            {
                Nav.NavigateTo(ViewModelLocator.CommandsPageKey);
            };

            ListsButton.Click += (s, e) =>
            {
                Nav.NavigateTo(ViewModelLocator.ListsPageKey);
            };
        }
    }
}