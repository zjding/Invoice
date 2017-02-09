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

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			UIToolbar toolbar = new UIToolbar();


			var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done);
			doneButton.Clicked += doneButtonClicked;

			var bbs = new UIBarButtonItem[] {
				new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
				doneButton
			};

			toolbar.SetItems(bbs, false);
			toolbar.SizeToFit();	

			txtCost.InputAccessoryView = toolbar;
		}

		void doneButtonClicked(object sender, EventArgs e)
		{
			txtCost.ResignFirstResponder();
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