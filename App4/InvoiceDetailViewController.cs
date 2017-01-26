using Foundation;
using System;
using UIKit;

namespace App4
{
    public partial class InvoiceDetailViewController : UITableViewController
    {
        public InvoiceDetailViewController (IntPtr handle) : base (handle)
        {
        }

		[Action("UnwindToInvoiceListViewController:")]
		public void UnwindToInvoiceListViewController(UIStoryboardSegue segue)
		{
			Console.WriteLine("We've unwinded to Pink!");
		}
    }
}