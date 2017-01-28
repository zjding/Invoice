using Foundation;
using System;
using UIKit;

namespace App4
{
	


    public partial class InvoiceDynamicDetailViewController : UITableViewController
    {
		public string InvoiceNameCellIdentifier = "InvoiceNameCellIdentifier";
		public string ClientNameCellIdentifier = "ClientNameCellIdentifier";
		public string ItemCellIdentifier = "ItemCellIdentifier";

		//List<string> Items = new List<string>();

        public InvoiceDynamicDetailViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
			return base.RowsInSection(tableView, section);
		}
    }
}