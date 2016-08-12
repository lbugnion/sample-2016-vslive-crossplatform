using System;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using XamBindingSample.ViewModel;

namespace XamBindingSample
{
    partial class Bindings7ViewController : UIViewController
    {
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private static bool _falseFlag = false;

        // Saving bindings to avoid garbage collection
        private Binding<string, string> _binding9;

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

        public Bindings7ViewController(IntPtr handle)
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
                    Nav.NavigateTo(AppDelegate.BindingsPage8Key);
                });

            NavigationItem.SetRightBarButtonItem(nextButton, false);

            View.AddGestureRecognizer(
                new UITapGestureRecognizer(
                    () =>
                    {
                        if (MyTextViewA1.CanResignFirstResponder)
                        {
                            MyTextViewA1.ResignFirstResponder();
                        }
                    }));

            // Value and ValueChanged -----------------------------------------------------------------------

            #region Value and ValueChanged

            _binding9 = this.SetBinding(
                () => MyTextViewA1.Text); // No target here, though we could add one

            _binding9.ValueChanged += (s, e) =>
            {
                MyLabelA1.Text = "Binding value is " + _binding9.Value;
            };

            #endregion

            #region Subscribing to events to avoid linker issues in release mode

            // This "fools" the linker into believing that the events are used.
            // In fact we don't even subscribe to them.
            // See https://developer.xamarin.com/guides/android/advanced_topics/linking/

            if (_falseFlag)
            {
                MyTextViewA1.Changed += (s, e) =>
                {
                };
            }

            #endregion
        }
    }
}