using Foundation;
using System;
using UIKit;
using SharpMobileCode.ModalPicker;
using System.Collections.Generic;

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

			UIToolbar toolbar = new UIToolbar();

			var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done);
			doneButton.Clicked += doneButtonClicked;

			var bbs = new UIBarButtonItem[] {
				new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
				doneButton
			};

			toolbar.SetItems(bbs, false);
			toolbar.SizeToFit();

			txtInvoiceNum.InputAccessoryView = toolbar;
		}

		void doneButtonClicked(object sender, EventArgs e)
		{
			txtInvoiceNum.ResignFirstResponder();


		}

		async partial void btnDue_UpInside(UIButton sender)
		{
			var dueDaysList = new List<string>();

			dueDaysList.Add("Due on receipt");
			dueDaysList.Add("1 day");
			dueDaysList.Add("7 days");
			dueDaysList.Add("14 days");
			dueDaysList.Add("21 days");
			dueDaysList.Add("30 days");
			dueDaysList.Add("60 days");
			dueDaysList.Add("90 days");
			dueDaysList.Add("180 days");
			dueDaysList.Add("365 days");

			var modalPicker = new ModalPickerViewController(ModalPickerType.Custom, "Select a Date", this)
			{
				HeaderBackgroundColor = new UIColor(red: 0.00f, green: 0.46f, blue: 0.98f, alpha: 1.0f),
				HeaderTextColor = UIColor.White,
				TransitioningDelegate = new ModalPickerTransitionDelegate(),
				ModalPresentationStyle = UIModalPresentationStyle.Custom
			};

			modalPicker.PickerView.Model = new CustomPickerModel(dueDaysList);

			modalPicker.OnModalPickerDismissed += (s, ea) =>
			{
				var index = modalPicker.PickerView.SelectedRowInComponent(0);

				btnDue.SetTitle(dueDaysList[(int)index], UIControlState.Normal);

				btnIssueDate_Change(null);
			};

			await PresentViewControllerAsync(modalPicker, true);
			                
		}

		async partial void btnIssueDate_UpInside(UIButton sender)
		{
			var modalPicker = new ModalPickerViewController(ModalPickerType.Date, "Select a Date", this)
			{
				HeaderBackgroundColor = new UIColor(red: .13f, green: .56f, blue: .99f, alpha: 1.0f),
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

				this.btnIssueDate.SetTitle(dateFormatter.ToString(modalPicker.DatePicker.Date), UIControlState.Normal);

				btnIssueDate_Change(null);
			};

			await PresentViewControllerAsync(modalPicker, true);
		}

		public NSDate ConvertDateTimeToNSDate(DateTime date)
		{
			DateTime newDate = TimeZone.CurrentTimeZone.ToLocalTime(
				new DateTime(2001, 1, 1, 0, 0, 0));
			return NSDate.FromTimeIntervalSinceReferenceDate(
				(date - newDate).TotalSeconds);
		}

		partial void btnIssueDate_Change(UIButton sender)
		{
			DateTime issueDT = Convert.ToDateTime(btnIssueDate.Title(UIControlState.Normal));

			string title = btnDue.Title(UIControlState.Normal);
			string dayNum = title.Replace("days", "").Replace("day", "").Trim();

			int dueDay = int.Parse(dayNum);
			DateTime dueDT = issueDT.AddDays(dueDay);

			var dateFormatter = new NSDateFormatter()
			{
				DateFormat = "MMMM dd, yyyy"
			};

			this.btnDueDate.SetTitle(dateFormatter.ToString(ConvertDateTimeToNSDate(dueDT)), UIControlState.Normal);
		}

		partial void btnCancel_UpInside(UIBarButtonItem sender)
		{
			throw new NotImplementedException();
		}

		partial void btnDone_UpInside(UIBarButtonItem sender)
		{
			throw new NotImplementedException();
		}
	}
}