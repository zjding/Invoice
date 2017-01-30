using Foundation;
using System;
using UIKit;
using SharpMobileCode.ModalPicker;

namespace App4
{
	public partial class InvoiceNameCell : UITableViewCell
	{
		public InvoiceDynamicDetailViewController viewController;

		public InvoiceNameCell(IntPtr handle) : base(handle)
		{
		}

		public InvoiceNameCell()
		{
			
		}

		async partial void OnBtnInvoiceDateUpInside(UIButton sender)
		{
			var modalPicker = new ModalPickerViewController(ModalPickerType.Date, "Select a Date", viewController)
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

				this.btnDate.SetTitle(dateFormatter.ToString(modalPicker.DatePicker.Date), UIControlState.Normal);
			};



			await viewController.PresentViewControllerAsync(modalPicker, true);
		}
	}
}