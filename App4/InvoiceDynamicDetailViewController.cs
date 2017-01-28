using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace App4
{
	
    

    public partial class InvoiceDynamicDetailViewController : UITableViewController
    {
		public string InvoiceNameCellIdentifier = "InvoiceNameCellIdentifier";
		public string ClientNameCellIdentifier = "ClientNameCellIdentifier";
		public string ItemCellIdentifier = "ItemCellIdentifier";

        public List<String> items = new List<string>();

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