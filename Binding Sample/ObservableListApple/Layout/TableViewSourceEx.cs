using Foundation;
using GalaSoft.MvvmLight.Helpers;
using ObservableListApple.Model;
using UIKit;

namespace ObservableListApple.Layout
{
    public class TableViewSourceEx : ObservableTableViewSource<Item>
    {
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            base.RowSelected(tableView, indexPath);
            var cell = tableView.CellAt(indexPath);
            cell.ContentView.BackgroundColor = UIColor.Green;
        }

        public override void RowDeselected(UITableView tableView, NSIndexPath indexPath)
        {
            base.RowDeselected(tableView, indexPath);
            var cell = tableView.CellAt(indexPath);

            if (cell != null)
            {
                cell.ContentView.BackgroundColor = UIColor.White;
            }
        }

        public override UITableViewCell GetCell(UITableView view, NSIndexPath indexPath)
        {
            var cell = base.GetCell(view, indexPath);
            cell.ContentView.BackgroundColor = UIColor.White;
            return cell;
        }
    }
}