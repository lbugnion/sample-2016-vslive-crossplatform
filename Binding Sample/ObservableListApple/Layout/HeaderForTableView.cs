using CoreGraphics;
using UIKit;

namespace ObservableListApple.Layout
{
    public class HeaderForTableView : UICollectionReusableView
    {
        public UILabel SelectedItemLabel
        {
            get;
            private set;
        }

        public UILabel ToggledItemsLabel
        {
            get;
            private set;
        }

        public HeaderForTableView()
        {
            BackgroundColor = UIColor.Red;

            SelectedItemLabel = new UILabel
            {
                Frame = new CGRect(10, -10, 300, 50),
            };

            ToggledItemsLabel = new UILabel
            {
                Frame = new CGRect(10, 10, 300, 50),
            };

            AddSubview(SelectedItemLabel);
            AddSubview(ToggledItemsLabel);
        }
    }
}