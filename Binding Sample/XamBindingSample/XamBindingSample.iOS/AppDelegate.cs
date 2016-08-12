using Foundation;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using UIKit;
using XamBindingSample.ViewModel;

namespace XamBindingSample
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    // ReSharper disable once PartialTypeWithSinglePart
    public partial class AppDelegate : UIApplicationDelegate
    {
        // Additional pages specific to iOS
        public const string BindingsPage2Key = "BindingsPage2";
        public const string BindingsPage3Key = "BindingsPage3";
        public const string BindingsPage4Key = "BindingsPage4";
        public const string BindingsPage5Key = "BindingsPage5";
        public const string BindingsPage6Key = "BindingsPage6";
        public const string BindingsPage7Key = "BindingsPage7";
        public const string BindingsPage8Key = "BindingsPage8";
        public const string CommandsPage2Key = "CommandsPage2";
        public const string CommandsPage3Key = "CommandsPage3";

        public override UIWindow Window
        {
            get;
            set;
        }

        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            ViewModelLocator.Initialize();

            // MVVM Light's DispatcherHelper for cross-thread handling.
            DispatcherHelper.Initialize(app);

            // Configure and register the MVVM Light NavigationService
            var nav = new NavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => nav);

            nav.Initialize((UINavigationController)Window.RootViewController);

            // Register the MVVM Light DialogService
            SimpleIoc.Default.Register<IDialogService, DialogService>();

            return true;
        }
    }
}