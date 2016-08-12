using System;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using XamBindingSample.ViewModel;

namespace XamBindingSample
{
    partial class MainViewController : UIViewController
    {
        public INavigationService Nav
        {
            get
            {
                return ServiceLocator.Current.GetInstance<INavigationService>();
            }
        }

        public MainViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            BindingsButton.TouchUpInside += (s, e) =>
            {
                Nav.NavigateTo(ViewModelLocator.BindingsPageKey);
            };

            CommandsButton.TouchUpInside += (s, e) =>
            {
                Nav.NavigateTo(ViewModelLocator.CommandsPageKey);
            };
        }
    }
}