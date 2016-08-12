using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using XamBindingSample.ViewModel;

namespace XamBindingSample
{
    partial class BindingsViewController : UIViewController
    {
        // ReSharper disable once ConvertToConstant.Local
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private static bool _falseFlag = false;

        // Saving bindings to avoid garbage collection
        // ReSharper disable once CollectionNeverQueried.Local
        private readonly List<Binding> _bindings = new List<Binding>();

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

        public BindingsViewController(IntPtr handle)
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
                    Nav.NavigateTo(AppDelegate.BindingsPage2Key);
                });

            NavigationItem.SetRightBarButtonItem(nextButton, false);

            View.AddGestureRecognizer(
                new UITapGestureRecognizer(
                    () =>
                    {
                        if (MyTextFieldB1.CanResignFirstResponder)
                        {
                            MyTextFieldB1.ResignFirstResponder();
                        }
                    }));

            // Simple bindings ------------------------------------------------------------------------------

            #region Simple Bindings

            _bindings.Add(
                this.SetBinding(
                    () => Vm.MyBoolProperty,
                    // This is a VM --> PropertyChanged event
                    () => MySwitchA1.On)); // will be used.

            MyButtonA1.SetCommand(Vm.ToggleCommand);

            _bindings.Add(
                this.SetBinding(
                    () => MyTextFieldB1.Text,
                    // This is an TextField --> EditingChanged event
                    () => MyLabelB1.Text)); // will be used.

            _bindings.Add(
                this.SetBinding(
                    () => MySwitchC1.On,
                    // This is a CheckBox --> ValueChanged event
                    () => MySwitchC2.On)); // will be used.

            #endregion

            #region Subscribing to events to avoid linker issues in release mode

            // This "fools" the linker into believing that the events are used.
            // In fact we don't even subscribe to them.
            // See https://developer.xamarin.com/guides/android/advanced_topics/linking/

            if (_falseFlag)
            {
                MyTextFieldB1.EditingChanged += (s, e) =>
                {
                };
                MySwitchC1.ValueChanged += (s, e) =>
                {
                };
            }

            #endregion
        }
    }
}