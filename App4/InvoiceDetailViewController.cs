using Foundation;
using System;
using UIKit;
using SharpMobileCode.ModalPicker;
using CoreGraphics;

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

			var dateFormatter = new NSDateFormatter()
			{
				DateFormat = "MMMM dd, yyyy"
			};

			var curDate = new NSDate();

			this.btnInvoiceDate.SetTitle(dateFormatter.ToString(curDate), UIControlState.Normal);

			this.btnInvoiceCancel.Clicked += BtnInvoiceCancel_Clicked; 
		}

		void BtnInvoiceCancel_Clicked (object sender, EventArgs e)
		{
			callingController.DismissViewController(true, null);
			//callingController.DismissModalViewController(true);
		}


		async partial void OnBtnInvoiceDateUpInside(UIButton sender)
		{
			var modalPicker = new ModalPickerViewController(ModalPickerType.Date, "Select a Date", this)
			{
				HeaderBackgroundColor = new UIColor(red: 0.00f, green: 0.46f, blue: 0.98f, alpha: 1.0f),
				HeaderTextColor = UIColor.White,
				TransitioningDelegate = new ModalPickerTransitionDelegate(),
				ModalPresentationStyle = UIModalPresentationStyle.Custom
			};

			modalPicker.DatePicker.Mode = UIDatePickerMode.Date;

			modalPicker.OnModalPickerDismissed += (s, ea) =>
			{
				var dateFormatter = new NSDateFormatter()
				{
					DateFormat = "MMMM dd, yyyy"
				};

				this.btnInvoiceDate.SetTitle(dateFormatter.ToString(modalPicker.DatePicker.Date), UIControlState.Normal);
			};

			await PresentViewControllerAsync(modalPicker, true);
		}

		public override UIView GetViewForHeader(UITableView tableView, nint section)
		{
			//return base.GetViewForHeader(tableView, section);

			CGRect frame = new CGRect(0, 0, this.TableView.Frame.Size.Width, 40.0);
			UIView header = new UIView(frame);
			header.BackgroundColor = new UIColor(red: 0.92f, green: 0.92f, blue: 0.92f, alpha: 1.0f);

			return header;
		}
	}
}