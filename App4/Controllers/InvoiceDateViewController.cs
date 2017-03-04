using Foundation;
using System;
using UIKit;

namespace App4
{
    public partial class InvoiceDateViewController : UITableViewController
    {
        public InvoiceDateViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			TableView.TableFooterView = new UIView();
		}


    }
}