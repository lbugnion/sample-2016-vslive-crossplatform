using GalaSoft.MvvmLight;

namespace XamBindingSample.Model
{
    public class MainModel : ObservableObject
    {
        private string _myModelProperty = null;

        public string MyModelProperty
        {
            get
            {
                return _myModelProperty;
            }
            set
            {
                Set(ref _myModelProperty, value);
            }
        }
    }
}