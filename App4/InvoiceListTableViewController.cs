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

			//this.NavigationItem.SetRightBarButtonItem(
			//	new UIBarButtonItem(UIBarButtonSystemItem.Add, (sender, args) =>
			//{

			//}),
			//true);

			this.btnAddInvoice.Clicked += BtnAddInvoice_Clicked;
		}

		void BtnAddInvoice_Clicked (object sender, EventArgs e)
		{
			UIAlertView alert = new UIAlertView()
			{
				Title = "alert title",
				Message = "this is a simple alert"
			};
			alert.AddButton("OK");
			alert.Show();
		}
	}
}