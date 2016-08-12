using XamBindingSample.Helpers;
using XamBindingSample.ViewModel;

namespace XamBindingSample
{
    public static class App
    {
        private static ViewModelLocator _locator;
        private static bool _isInitialized;

        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }

        public static void Initialize()
        {
            if (_isInitialized)
            {
                return;
            }

            IocSetup.Initialize();
            ViewModelLocator.Initialize();
            _isInitialized = true;
        }
    }
}