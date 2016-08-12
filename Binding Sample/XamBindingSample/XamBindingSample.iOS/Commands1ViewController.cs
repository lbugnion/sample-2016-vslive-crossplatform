using System;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using XamBindingSample.ViewModel;

namespace XamBindingSample
{
    partial class Commands1ViewController : UIViewController
    {
        private static readonly bool _falseFlag = false;

        public INavigationService Nav
        {
            get
            {
                return ServiceLocator.Current.GetInstance<INavigationService>();
            }
        }

        public CommandsViewModel Vm
        {
            get
            {
                return Application.Locator.Commands;
            }
        }

        public Commands1ViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var nextButton = new UIBarButtonItem(
                "Next",
                UIBarButtonItemStyle.Plain,
                (s, e) =>
                {
                    Nav.NavigateTo(AppDelegate.CommandsPage2Key);
                });

            NavigationItem.SetRightBarButtonItem(nextButton, false);

            // Simple command -------------------------------------------

            SimpleCommandButton.SetCommand(Vm.SayHelloCommand);

            // Command and checkbox ---------------------------------

            MySwitch.SetCommand(Vm.SayHelloCommand);

            // Command and static parameter -----------------------------

            StaticParameterButton.SetCommand(
                Vm.ShowMessageCommand,
                "Hello Evolve, this is a static message!");

            // Subscribing to events to avoid linker issues in release mode ---------------------------------

            // This "fools" the linker into believing that the events are used.
            // In fact we don't even subscribe to them.
            // See https://developer.xamarin.com/guides/android/advanced_topics/linking/

            if (_falseFlag)
            {
                SimpleCommandButton.TouchUpInside += (s, e) =>
                {
                };
                StaticParameterButton.TouchUpInside += (s, e) =>
                {
                };
                MySwitch.ValueChanged += (s, e) =>
                {
                };
            }
        }
    }
}