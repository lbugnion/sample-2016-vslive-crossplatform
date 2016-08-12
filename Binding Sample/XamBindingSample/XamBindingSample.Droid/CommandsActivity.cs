using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using GalaSoft.MvvmLight.Helpers;
using XamBindingSample.ViewModel;

namespace XamBindingSample
{
    [Activity(Label = "Commands sample")]
    public partial class CommandsActivity
    {
        // ReSharper disable once ConvertToConstant.Local
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private static bool _falseFlag = false;

        // ReSharper disable once CollectionNeverQueried.Local
        private readonly List<Binding> _bindings = new List<Binding>();

        /// <summary>
        /// Gets a reference to the ViewModel from the ViewModelLocator.
        /// </summary>
        private CommandsViewModel Vm
        {
            get
            {
                return App.Locator.Commands;
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Commands);

            // Simple command -------------------------------------------

            SimpleCommandButton.SetCommand(Vm.SayHelloCommand);

            // Command and checkbox ---------------------------------

            MyCheckBox.SetCommand(Vm.SayHelloCommand);

            // Command and custom event -----------------------------

            CustomEventEditText.SetCommand<string, View.FocusChangeEventArgs>(
                "FocusChange",
                Vm.ShowMessageCommand,
                "This message shows on FocusChange");

            // Command and static parameter -----------------------------

            StaticParameterButton.SetCommand(
                Vm.ShowMessageCommand,
                "Hello Evolve, this is a static message!");

            // Command and dynamic parameter ----------------------------

            var parameterBinding = this.SetBinding(() => MyEditText.Text);
            _bindings.Add(parameterBinding);
            DynamicParameterButton.SetCommand(Vm.ShowMessageCommand, parameterBinding);

            // Subscribing to events to avoid linker issues in release mode ---------------------------------
            // This "fools" the linker into believing that the events are used.
            // In fact we don't even subscribe to them.
            // See https://developer.xamarin.com/guides/android/advanced_topics/linking/

            if (_falseFlag)
            {
                SimpleCommandButton.Click += (s, e) =>
                {
                };
                StaticParameterButton.Click += (s, e) =>
                {
                };
                DynamicParameterButton.Click += (s, e) =>
                {
                };

                MyCheckBox.CheckedChange += (s, e) =>
                {
                };
                CustomEventEditText.FocusChange += (s, e) =>
                {
                };
            }
        }
    }
}