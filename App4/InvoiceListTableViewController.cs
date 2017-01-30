using Foundation;
using System;
using UIKit;

namespace App4
{
    public partial class InvoiceListTableViewController : UITableViewController
    {
        public InvoiceListTableViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//this.btnAddInvoice.Clicked += BtnAddInvoice_Clicked;
		}

		void BtnAddInvoice_Clicked (object sender, EventArgs e)
		{
			//UIAlertView alert = new UIAlertView()
			//{
			//	Title = "alert title",
			//	Message = "this is a simple alert"
			//};
			//alert.AddButton("OK");
			//alert.Show();
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			//if (segue.Identifier == "Invoice_List_To_ItemDetail_Segue")
			//{
			//	var destCtrl = segue.DestinationViewController as UINavigationController;

			//	((InvoiceItemDetailViewController)(destCtrl.ViewControllers[0])).callingController = this;
			//}

			base.PrepareForSegue(segue, sender);
		}


	}
}