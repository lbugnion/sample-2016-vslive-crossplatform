using System;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using ObservableListApple.Layout;
using ObservableListApple.ViewModel;
using UIKit;

namespace ObservableListApple
{
    partial class MainViewController : UIViewController
    {
        public NavigationService Nav
        {
            get
            {
                return (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            }
        }

        public MainViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableSourceWithReuseIdButton.TouchUpInside += (s, e) =>
            {
                Nav.NavigateTo(ViewModelLocator.SecondPageKey, false);
            };

            CollectionViewGridButton.TouchUpInside += (s, e) =>
            {
                var controller = new CollectionViewController(new GridLayout());
                Nav.NavigationController.PushViewController(controller, true);
            };

            CollectionViewCircleButton.TouchUpInside += (s, e) =>
            {
                var controller = new CollectionViewController(new CircleLayout());
                Nav.NavigationController.PushViewController(controller, true);
            };
        }
    }
}
