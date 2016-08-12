using System;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using XamBindingSample.ViewModel;

namespace XamBindingSample
{
    partial class Bindings4ViewController : UIViewController
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

        public Bindings4ViewController(IntPtr handle)
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
                    Nav.NavigateTo(AppDelegate.BindingsPage5Key);
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

            // Conversion back and forth --------------------------------------------------------------------

            #region Conversion back and forth

            _binding = this.SetBinding(
                () => MySwitchA1.On,
                () => MyTextFieldA1.Text,
                BindingMode.TwoWay);

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
                MyTextFieldA1.EditingChanged += (s, e) =>
                {
                };
            }

            #endregion
        }
    }
}