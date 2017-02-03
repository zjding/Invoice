using Foundation;
using System;
using UIKit;

namespace App4
{
    public partial class ClientAddViewController : UITableViewController
    {
        public ClientAddViewController (IntPtr handle) : base (handle)
        {
        }



		public override void WillDisplayHeaderView(UITableView tableView, UIView headerView, nint section)
		{
			if (section == 2)
			{
				var header = headerView as UITableViewHeaderFooterView;

				header.TextLabel.TextColor = UIColor.DarkGray;
				header.TextLabel.Font = UIFont.BoldSystemFontOfSize(12);
			}
		}
    }
}