using Foundation;
using System;
using UIKit;

namespace App4
{
    public partial class InvoiceDetailViewController : UITableViewController
    {
		public InvoiceListTableViewController callingController;

        public InvoiceDetailViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			this.btnInvoiceCancel.Clicked += BtnInvoiceCancel_Clicked; ;
		}

		void BtnInvoiceCancel_Clicked (object sender, EventArgs e)
		{
			callingController.DismissViewController(true, null);
			//callingController.DismissModalViewController(true);
		}


    }
}