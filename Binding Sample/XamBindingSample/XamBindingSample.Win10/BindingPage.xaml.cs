using Windows.UI.Core;

namespace XamBindingSample
{
    public sealed partial class BindingPage
    {
        public BindingPage()
        {
            InitializeComponent();

            var manager = SystemNavigationManager.GetForCurrentView();
            manager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            manager.BackRequested += SystemNavigationManagerBackRequested;
        }

        private void SystemNavigationManagerBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }
    }
}
