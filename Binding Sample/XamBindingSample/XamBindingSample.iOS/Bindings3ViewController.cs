using System;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using XamBindingSample.ViewModel;

namespace XamBindingSample
{
    partial class Bindings3ViewController : UIViewController
    {
        // ReSharper disable once ConvertToConstant.Local
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private static bool _falseFlag = false;

        // Saving bindings to avoid garbage collection
        // ReSharper disable once NotAccessedField.Local
        private Binding _binding;

        public INavigationService Nav
        {
            get
            {
                return ServiceLocator.Current.GetInstance<INavigationService>();
            }
        }

        public BindingsViewModel Vm
        {
            get
            {
                return Application.Locator.Bindings;
            }
        }

        public Bindings3ViewController(IntPtr handle)
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
                    Nav.NavigateTo(AppDelegate.BindingsPage4Key);
                });

            NavigationItem.SetRightBarButtonItem(nextButton, false);

            View.AddGestureRecognizer(
                new UITapGestureRecognizer(
                    () =>
                    {
                        if (MyTextFieldA1.CanResignFirstResponder)
                        {
                            MyTextFieldA1.ResignFirstResponder();
                        }
                    }));

            // Bindings with custom events ------------------------------------------------------------------

            #region Bindings with custom events

            _binding = this.SetBinding(
                () => MyTextFieldA1.Text,
                () => MyLabelA1.Text)
                .ObserveSourceEvent("EditingDidEnd");

            #endregion

            #region Subscribing to events to avoid linker issues in release mode

            // This "fools" the linker into believing that the events are used.
            // In fact we don't even subscribe to them.
            // See https://developer.xamarin.com/guides/android/advanced_topics/linking/

            if (_falseFlag)
            {
                MyTextFieldA1.EditingChanged += (s, e) =>
                {
                };
            }

            #endregion
        }
    }
}