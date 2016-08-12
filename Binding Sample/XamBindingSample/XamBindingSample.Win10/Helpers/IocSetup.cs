using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using XamBindingSample.ViewModel;

namespace XamBindingSample.Helpers
{
    public class IocSetup
    {
        public static void Initialize()
        {
            // Initialize the MVVM Light DispatcherHelper.
            // This needs to be called on the UI thread.
            DispatcherHelper.Initialize();

            // Configure and register the MVVM Light NavigationService
            var nav = new NavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => nav);
            nav.Configure(ViewModelLocator.BindingsPageKey, typeof(BindingPage));
            nav.Configure(ViewModelLocator.CommandsPageKey, typeof(CommandsPage));
            nav.Configure(ViewModelLocator.ListsPageKey, typeof(ListsPage));

            // Register the MVVM Light DialogService
            SimpleIoc.Default.Register<IDialogService, DialogService>();
        }
    }
}
