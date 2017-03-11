using Foundation;
using System;
using UIKit;

namespace App4
{
    public partial class InvoiceNameViewController : UITableViewController
    {
		public string name;
		public InvoiceDynamicDetailViewController callingController;

        public InvoiceNameViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			txtName.Text = name;
		}

		partial void btnBack_UpInside(UIBarButtonItem sender)
		{
			this.NavigationController.PopViewController(true);
		}

		partial void btnSave_UpInside(UIBarButtonItem sender)
		{
			callingController.NavigationItem.Title = txtName.Text; 
			this.NavigationController.PopViewController(true);
		}
	}
}