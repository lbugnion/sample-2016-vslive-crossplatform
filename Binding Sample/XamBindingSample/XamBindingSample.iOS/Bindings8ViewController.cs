using System;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using XamBindingSample.ViewModel;

namespace XamBindingSample
{
	partial class Bindings8ViewController : UIViewController
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

        public Bindings8ViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // TargetNullValue and FallbackValue ------------------------------------------------------------

            #region TargetNullValue and FallbackValue

            _binding = this.SetBinding(
                () => Vm.Model.MyModelProperty,
                () => MyLabelA1.Text,
                fallbackValue: "Model object is null",
                targetNullValue: "Value is null");

            MyButtonA1.SetCommand(Vm.SetModelPropertyCommand);

            #endregion

            #region Subscribing to events to avoid linker issues in release mode

            // This "fools" the linker into believing that the events are used.
            // In fact we don't even subscribe to them.
            // See https://developer.xamarin.com/guides/android/advanced_topics/linking/

            if (_falseFlag)
            {
                MyButtonA1.TouchUpInside += (s, e) => { };
            }

            #endregion
        }
    }
}
