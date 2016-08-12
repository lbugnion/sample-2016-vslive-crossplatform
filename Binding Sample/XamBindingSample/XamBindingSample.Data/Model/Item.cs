using GalaSoft.MvvmLight;

namespace XamBindingSample.Model
{
    public class Item : ObservableObject
    {
        private bool _isToggled;

        public int Id
        {
            get;
            set;
        }

        public bool IsToggled
        {
            get
            {
                return _isToggled;
            }
            set
            {
                Set(ref _isToggled, value);
            }
        }

        public string Name
        {
            get
            {
                return $"This is item # {Id}";
            }
        }
    }
}