using Foundation;
using System;
using UIKit;

namespace App4
{
	public partial class InvoiceTabBarController : RaisedTabBarController
    {

		public InvoiceTabBarController(IntPtr handle) : base (handle)
        {

		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			this.InsertEmptyTabItem("", 2);

			var img = UIImage.FromFile("Images/Add.png");
			this.AddRaisedButton(img, null);
		}

		public override void onRaisedButton_TouchUpInside(object sender, EventArgs e)
		{
			// Create a new Alert Controller
			UIAlertController actionSheetAlert = UIAlertController.Create("Create a new item", "Select an type from below", UIAlertControllerStyle.ActionSheet);

			// Add Actions
			actionSheetAlert.AddAction(UIAlertAction.Create("New Invoice", UIAlertActionStyle.Default, (action) => Console.WriteLine("Item One pressed.")));

			actionSheetAlert.AddAction(UIAlertAction.Create("New Estimate", UIAlertActionStyle.Default, (action) => Console.WriteLine("Item Two pressed.")));

			actionSheetAlert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (action) => Console.WriteLine("Cancel button pressed.")));

			// Required for iPad - You must specify a source for the Action Sheet since it is
			// displayed as a popover
			//UIPopoverPresentationController presentationPopover = actionSheetAlert.PopoverPresentationController;
			//if (presentationPopover != null)
			//{
			//	presentationPopover.SourceView = this.View;
			//	presentationPopover.PermittedArrowDirections = UIPopoverArrowDirection.Up;
			//}

			// Display the alert
			this.PresentViewController(actionSheetAlert, true, null);
		}
    }
}