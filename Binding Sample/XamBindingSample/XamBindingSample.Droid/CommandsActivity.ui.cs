using Android.Widget;
using GalaSoft.MvvmLight.Views;

namespace XamBindingSample
{
    public partial class CommandsActivity : ActivityBase
    {
        private Button _simpleCommandButton;

        public Button SimpleCommandButton
        {
            get
            {
                return _simpleCommandButton
                       ?? (_simpleCommandButton = FindViewById<Button>(Resource.Id.SimpleCommandButton));
            }
        }

        private CheckBox _myCheckBox;

        public CheckBox MyCheckBox
        {
            get
            {
                return _myCheckBox
                       ?? (_myCheckBox = FindViewById<CheckBox>(Resource.Id.MyCheckBox));
            }
        }

        private EditText _myEditText;

        public EditText MyEditText
        {
            get
            {
                return _myEditText
                       ?? (_myEditText = FindViewById<EditText>(Resource.Id.MyEditText));
            }
        }

        private Button _staticParameterButton;

        public Button StaticParameterButton
        {
            get
            {
                return _staticParameterButton
                       ?? (_staticParameterButton = FindViewById<Button>(Resource.Id.StaticParameterButton));
            }
        }

        private EditText _customEventEditText;

        public EditText CustomEventEditText
        {
            get
            {
                return _customEventEditText
                       ?? (_customEventEditText = FindViewById<EditText>(Resource.Id.CustomEventEditText));
            }
        }

        private Button _dynamicParameterButton;

        public Button DynamicParameterButton
        {
            get
            {
                return _dynamicParameterButton
                       ?? (_dynamicParameterButton = FindViewById<Button>(Resource.Id.DynamicParameterButton));
            }
        }
    }
}