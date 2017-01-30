using Foundation;
using System;
using UIKit;

namespace App4
{
    public partial class InvoiceItemDetailViewController : UITableViewController
    {
		public InvoiceDynamicDetailViewController callingController;

        public InvoiceItemDetailViewController (IntPtr handle) : base (handle)
        {
        }

		public override void DidMoveToParentViewController(UIViewController parent)
		{

		}

		public override void ViewWillDisappear(Boolean animated)
		{
			callingController.items.Add("Item " + (callingController.items.Count + 1).ToString());
		}
    }
}