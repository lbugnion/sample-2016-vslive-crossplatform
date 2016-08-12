using System;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using XamBindingSample.ViewModel;

namespace XamBindingSample
{
    partial class Bindings6ViewController : UIViewController
    {
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        // ReSharper disable once ConvertToConstant.Local
        private static bool _falseFlag = false;

        // Saving bindings to avoid garbage collection
        private Binding<bool, bool> _binding8;

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

        public Bindings6ViewController(IntPtr handle)
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
                    Nav.NavigateTo(AppDelegate.BindingsPage7Key);
                });

            NavigationItem.SetRightBarButtonItem(nextButton, false);

            // When Source Changes --------------------------------------------------------------------------

            #region When Source Changes

            _binding8 = this.SetBinding(() => MySwitchA1.On)
                .WhenSourceChanges(
                    () =>
                    {
                        if (_binding8 == null)
                        {
                            MyLabelA1.Text = "Binding is null";
                        }
                        else
                        {
                            MyLabelA1.Text = "Binding value is " + _binding8.Value;
                        }
                    });

            #endregion

            #region Subscribing to events to avoid linker issues in release mode

            // This "fools" the linker into believing that the events are used.
            // In fact we don't even subscribe to them.
            // See https://developer.xamarin.com/guides/android/advanced_topics/linking/

            if (_falseFlag)
            {
                MySwitchA1.ValueChanged += (s, e) =>
                {
                };
            }

            #endregion
        }
    }
}