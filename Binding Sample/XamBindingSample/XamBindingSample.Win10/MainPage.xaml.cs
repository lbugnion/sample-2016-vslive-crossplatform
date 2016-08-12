using Windows.UI.Core;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using XamBindingSample.ViewModel;

namespace XamBindingSample
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += SystemNavigationManagerBackRequested;

            BindingsButton.Click += (s, e) =>
            {
                ServiceLocator.Current.GetInstance<INavigationService>().NavigateTo(ViewModelLocator.BindingsPageKey);
            };

            CommandsButton.Click += (s, e) =>
            {
                ServiceLocator.Current.GetInstance<INavigationService>().NavigateTo(ViewModelLocator.CommandsPageKey);
            };

            ListsButton.Click += (s, e) =>
            {
                ServiceLocator.Current.GetInstance<INavigationService>().NavigateTo(ViewModelLocator.ListsPageKey);
            };
        }

        private void SystemNavigationManagerBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }
    }
}
