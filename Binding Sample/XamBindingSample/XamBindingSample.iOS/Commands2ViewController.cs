using System;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using XamBindingSample.ViewModel;

namespace XamBindingSample
{
    partial class Commands2ViewController : UIViewController
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

        public Commands2ViewController(IntPtr handle)
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
                    Nav.NavigateTo(AppDelegate.CommandsPage3Key);
                });

            NavigationItem.SetRightBarButtonItem(nextButton, false);

            View.AddGestureRecognizer(
                new UITapGestureRecognizer(
                    () =>
                    {
                        if (MyTextField.CanResignFirstResponder)
                        {
                            MyTextField.ResignFirstResponder();
                        }
                    }));

            // Command and custom event -----------------------------

            MyTextField.SetCommand(
                "EditingDidEnd",
                Vm.ShowMessageCommand,
                MyTextField.Text);

            // Subscribing to events to avoid linker issues in release mode ---------------------------------

            // This "fools" the linker into believing that the events are used.
            // In fact we don't even subscribe to them.
            // See https://developer.xamarin.com/guides/android/advanced_topics/linking/

            if (_falseFlag)
            {
                MyTextField.EditingDidEnd += (s, e) =>
                {
                };
            }
        }
    }
}