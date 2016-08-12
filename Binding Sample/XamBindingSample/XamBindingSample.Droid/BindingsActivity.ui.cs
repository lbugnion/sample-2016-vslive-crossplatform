using Android.Widget;
using GalaSoft.MvvmLight.Views;

namespace XamBindingSample
{
    public partial class BindingsActivity : ActivityBase
    {
        private CheckBox _myCheckBoxA1;

        public CheckBox MyCheckBoxA1
        {
            get
            {
                return _myCheckBoxA1
                       ?? (_myCheckBoxA1 = FindViewById<CheckBox>(Resource.Id.MyCheckBoxA1));
            }
        }

        private Button _myButtonA1;

        public Button MyButtonA1
        {
            get
            {
                return _myButtonA1
                       ?? (_myButtonA1 = FindViewById<Button>(Resource.Id.MyButtonA1));
            }
        }

        private EditText _myEditTextB1;

        public EditText MyEditTextB1
        {
            get
            {
                return _myEditTextB1
                       ?? (_myEditTextB1 = FindViewById<EditText>(Resource.Id.MyEditTextB1));
            }
        }

        private TextView _myTextViewB1;

        public TextView MyTextViewB1
        {
            get
            {
                return _myTextViewB1
                       ?? (_myTextViewB1 = FindViewById<TextView>(Resource.Id.MyTextViewB1));
            }
        }

        private CheckBox _myCheckBoxC1;

        public CheckBox MyCheckBoxC1
        {
            get
            {
                return _myCheckBoxC1
                       ?? (_myCheckBoxC1 = FindViewById<CheckBox>(Resource.Id.MyCheckBoxC1));
            }
        }

        private CheckBox _myCheckBoxC2;

        public CheckBox MyCheckBoxC2
        {
            get
            {
                return _myCheckBoxC2
                       ?? (_myCheckBoxC2 = FindViewById<CheckBox>(Resource.Id.MyCheckBoxC2));
            }
        }

        private EditText _myEditTextD1;

        public EditText MyEditTextD1
        {
            get
            {
                return _myEditTextD1
                       ?? (_myEditTextD1 = FindViewById<EditText>(Resource.Id.MyEditTextD1));
            }
        }

        private TextView _myTextViewD1;

        public TextView MyTextViewD1
        {
            get
            {
                return _myTextViewD1
                       ?? (_myTextViewD1 = FindViewById<TextView>(Resource.Id.MyTextViewD1));
            }
        }

        private EditText _myEditTextE1;

        public EditText MyEditTextE1
        {
            get
            {
                return _myEditTextE1
                       ?? (_myEditTextE1 = FindViewById<EditText>(Resource.Id.MyEditTextE1));
            }
        }

        private TextView _myTextViewE1;

        public TextView MyTextViewE1
        {
            get
            {
                return _myTextViewE1
                       ?? (_myTextViewE1 = FindViewById<TextView>(Resource.Id.MyTextViewE1));
            }
        }

        private CheckBox _myCheckBoxF1;

        public CheckBox MyCheckBoxF1
        {
            get
            {
                return _myCheckBoxF1
                       ?? (_myCheckBoxF1 = FindViewById<CheckBox>(Resource.Id.MyCheckBoxF1));
            }
        }

        private EditText _myEditTextF1;

        public EditText MyEditTextF1
        {
            get
            {
                return _myEditTextF1
                       ?? (_myEditTextF1 = FindViewById<EditText>(Resource.Id.MyEditTextF1));
            }
        }

        private CheckBox _myCheckBoxG1;

        public CheckBox MyCheckBoxG1
        {
            get
            {
                return _myCheckBoxG1
                       ?? (_myCheckBoxG1 = FindViewById<CheckBox>(Resource.Id.MyCheckBoxG1));
            }
        }

        private EditText _myEditTextG1;

        public EditText MyEditTextG1
        {
            get
            {
                return _myEditTextG1
                       ?? (_myEditTextG1 = FindViewById<EditText>(Resource.Id.MyEditTextG1));
            }
        }

        private TextView _myTextViewH1;

        public TextView MyTextViewH1
        {
            get
            {
                return _myTextViewH1
                       ?? (_myTextViewH1 = FindViewById<TextView>(Resource.Id.MyTextViewH1));
            }
        }

        private CheckBox _myCheckBoxH1;

        public CheckBox MyCheckBoxH1
        {
            get
            {
                return _myCheckBoxH1
                       ?? (_myCheckBoxH1 = FindViewById<CheckBox>(Resource.Id.MyCheckBoxH1));
            }
        }

        //private TextView _myTextViewI1;

        //public TextView MyTextViewI1
        //{
        //    get
        //    {
        //        return _myTextViewI1
        //               ?? (_myTextViewI1 = FindViewById<TextView>(Resource.Id.MyTextViewI1));
        //    }
        //}

        //private EditText _myEditTextI1;

        //public EditText MyEditTextI1
        //{
        //    get
        //    {
        //        return _myEditTextI1
        //               ?? (_myEditTextI1 = FindViewById<EditText>(Resource.Id.MyEditTextI1));
        //    }
        //}

        private TextView _myTextViewJ1;

        public TextView MyTextViewJ1
        {
            get
            {
                return _myTextViewJ1
                       ?? (_myTextViewJ1 = FindViewById<TextView>(Resource.Id.MyTextViewJ1));
            }
        }

        private Button _myButtonJ1;

        public Button MyButtonJ1
        {
            get
            {
                return _myButtonJ1
                       ?? (_myButtonJ1 = FindViewById<Button>(Resource.Id.MyButtonJ1));
            }
        }
    }
}