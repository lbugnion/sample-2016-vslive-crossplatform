using System;
using GalaSoft.MvvmLight.Helpers;
using UIKit;
using XamBindingSample.ViewModel;

namespace XamBindingSample
{
    partial class Commands3ViewController : UIViewController
    {
        private static readonly bool _falseFlag = false;

        public CommandsViewModel Vm
        {
            get
            {
                return Application.Locator.Commands;
            }
        }

        public Commands3ViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.AddGestureRecognizer(
                new UITapGestureRecognizer(
                    () =>
                    {
                        if (MyTextField.CanResignFirstResponder)
                        {
                            MyTextField.ResignFirstResponder();
                        }
                    }));

            // Command and dynamic parameter ----------------------------

            var parameterBinding = this.SetBinding(() => MyTextField.Text);
            DynamicParameterButton.SetCommand(Vm.ShowMessageCommand, parameterBinding);

            // Subscribing to events to avoid linker issues in release mode ---------------------------------

            // This "fools" the linker into believing that the events are used.
            // In fact we don't even subscribe to them.
            // See https://developer.xamarin.com/guides/android/advanced_topics/linking/

            if (_falseFlag)
            {
                DynamicParameterButton.TouchUpInside += (s, e) =>
                {
                };
                MyTextField.EditingChanged += (s, e) =>
                {
                };
            }
        }
    }
}