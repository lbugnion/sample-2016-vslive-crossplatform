using System;
using CoreGraphics;
using GalaSoft.MvvmLight.Helpers;
using UIKit;

namespace ObservableListApple.Layout
{
    public class TestTableViewCell : UITableViewCell
    {
        public UILabel TitleLabel
        {
            get;
            set;
        }

        public UISwitch OnSwitch
        {
            get;
            set;
        }

        public Binding SwitchBinding
        {
            get;
            set;
        }

        public TestTableViewCell(IntPtr handle)
            : base(handle)
        {
            BackgroundView = new UIView
            {
                BackgroundColor = UIColor.Orange
            };

            SelectedBackgroundView = new UIView
            {
                BackgroundColor = UIColor.Green
            };

            ContentView.BackgroundColor = UIColor.White;

            TitleLabel = new UILabel
            {
                Frame = new CGRect(71, 8, ContentView.Frame.Width - 81, ContentView.Frame.Height - 16),
                BackgroundColor = UIColor.FromRGBA(0, 0, 0, 0)
            };

            OnSwitch = new UISwitch
            {
                Frame = new CGRect(10, 5, 51, 27)
            };

            ContentView.AddSubview(OnSwitch);
            ContentView.AddSubview(TitleLabel);
        }
    }
}