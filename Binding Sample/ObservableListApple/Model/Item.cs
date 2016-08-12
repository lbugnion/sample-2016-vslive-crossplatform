using GalaSoft.MvvmLight;

namespace ObservableListApple.Model
{
    public class Item : ObservableObject
    {
        public string Name
        {
            get
            {
                return $"This is item # {Id}";
            }
        }

        public int Id
        {
            get;
            set;
        }

        private bool _isToggled;

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
    }
}