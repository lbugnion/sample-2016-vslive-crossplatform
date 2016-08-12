using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using GalaSoft.MvvmLight.Helpers;
using XamBindingSample.ViewModel;

namespace XamBindingSample
{
    [Activity(Label = "Bindings sample")]
    public partial class BindingsActivity
    {
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private static bool _falseFlag = false;

        private Binding<bool, bool> _binding8;

        //private Binding<string, string> _binding9;

        // ReSharper disable once CollectionNeverQueried.Local
        private readonly List<Binding> _bindings = new List<Binding>();

        /// <summary>
        /// Gets a reference to the ViewModel from the ViewModelLocator.
        /// </summary>
        private BindingsViewModel Vm
        {
            get
            {
                return App.Locator.Bindings;
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Bindings);

            // Simple bindings ------------------------------------------------------------------------------

            #region Simple Bindings

            var binding1 = this.SetBinding(
                () => Vm.MyBoolProperty,     // This is a VM --> PropertyChanged event
                () => MyCheckBoxA1.Checked); // will be used.

            MyButtonA1.SetCommand(Vm.ToggleCommand);

            var binding2 = this.SetBinding(
                () => MyEditTextB1.Text,  // This is an EditText --> TextChanged event
                () => MyTextViewB1.Text); // will be used.

            var binding3 = this.SetBinding(
                () => MyCheckBoxC1.Checked,  // This is a CheckBox --> CheckedChange event
                () => MyCheckBoxC2.Checked); // will be used.

            #endregion

            // Bindings with custom events ------------------------------------------------------------------

            #region Bindings with custom events

            var binding4 = this.SetBinding(
                () => MyEditTextD1.Text,
                () => MyTextViewD1.Text)
                .ObserveSourceEvent("Click");

            var binding5 = this.SetBinding(
                () => MyEditTextE1.Text,
                () => MyTextViewE1.Text)
                .ObserveSourceEvent<View.FocusChangeEventArgs>("FocusChange");

            #endregion

            // Conversion back and forth --------------------------------------------------------------------

            #region Conversion back and forth

            var binding6 = this.SetBinding(
                () => MyCheckBoxF1.Checked,
                () => MyEditTextF1.Text,
                BindingMode.TwoWay);

            var binding7 = this.SetBinding(
                () => MyCheckBoxG1.Checked,
                () => MyEditTextG1.Text,
                BindingMode.TwoWay)
                .ConvertSourceToTarget(val => val ? "TTT" : "FFF")
                .ConvertTargetToSource(val => val == "TTT");

            #endregion

            // When Source Changes --------------------------------------------------------------------------

            #region When Source Changes

            _binding8 = this.SetBinding(() => MyCheckBoxH1.Checked)
                .WhenSourceChanges(
                    () =>
                    {
                        MyTextViewH1.Text = MyCheckBoxH1.Checked.ToString();

                        if (_binding8 == null)
                        {
                            MyCheckBoxH1.Text = "Binding is null";
                        }
                        else
                        {
                            MyCheckBoxH1.Text = "Binding value is " + _binding8.Value;
                        }
                    });

            #endregion

            // TargetNullValue and FallbackValue ------------------------------------------------------------

            #region Saving bindings

            _bindings.Add(binding1);
            _bindings.Add(binding2);
            _bindings.Add(binding3);
            _bindings.Add(binding4);
            _bindings.Add(binding5);
            _bindings.Add(binding6);
            _bindings.Add(binding7);
            _bindings.Add(_binding8);
            //_bindings.Add(_binding9);

            #endregion

            #region TargetNullValue and FallbackValue

            _bindings.Add(this.SetBinding(
                () => Vm.Model.MyModelProperty,
                () => MyTextViewJ1.Text,
                fallbackValue: "Model object is null",
                targetNullValue: "Value is null"));

            MyButtonJ1.SetCommand(Vm.SetModelPropertyCommand);

            #endregion

            // Subscribing to events to avoid linker issues in release mode ---------------------------------

            #region Subscribing to events to avoid linker issues in release mode

            // This "fools" the linker into believing that the events are used.
            // In fact we don't even subscribe to them.
            // See https://developer.xamarin.com/guides/android/advanced_topics/linking/

            if (_falseFlag)
            {
                MyCheckBoxA1.CheckedChange += (s, e) => { };
                MyCheckBoxC1.CheckedChange += (s, e) => { };
                MyCheckBoxF1.CheckedChange += (s, e) => { };
                MyCheckBoxG1.CheckedChange += (s, e) => { };
                MyCheckBoxH1.CheckedChange += (s, e) => { };

                MyEditTextB1.TextChanged += (s, e) => { };
                //MyEditTextI1.TextChanged += (s, e) => { };
                MyEditTextD1.Click += (s, e) => { };
                MyEditTextE1.FocusChange += (s, e) => { };

                MyButtonA1.Click += (s, e) => { };
            }

            #endregion
        }
    }
}