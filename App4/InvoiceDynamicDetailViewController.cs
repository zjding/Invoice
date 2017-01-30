using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace App4
{
	
    

    public partial class InvoiceDynamicDetailViewController : UITableViewController
    {
		public string InvoiceNameCellIdentifier = "InvoiceNameCellIdentifier";
		public string ClientNameCellIdentifier = "ClientNameCellIdentifier";
		public string ItemCellIdentifier = "ItemCellIdentifier";
		public string AddItemCellIdentifier = "AddItemCellIdentifier";

        public List<String> items = new List<string>();

		//List<string> Items = new List<string>();

        public InvoiceDynamicDetailViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			items.Add("Item 1");

		}

		public override nint NumberOfSections(UITableView tableView)
		{
			return 4;
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
			if (section == 0)
			{
				return 1;
			}
			else if (section == 1)
			{
				return 1;
			}
			else if (section == 2)
			{
				return items.Count + 1;
			}

			return 0;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			if (indexPath.Section == 0)
			{
				InvoiceNameCell nameCell = this.TableView.DequeueReusableCell(InvoiceNameCellIdentifier) as InvoiceNameCell;

				nameCell.lblInvoiceName.Text = "INVOICE-00001";

				var dateFormatter = new NSDateFormatter()
				{
					DateFormat = "MMMM dd, yyyy"
				};

				var curDate = new NSDate();

				nameCell.btnDate.SetTitle(dateFormatter.ToString(curDate), UIControlState.Normal);
				nameCell.viewController = this;

				return nameCell;
			}
			else if (indexPath.Section == 1)
			{
				InvoiceClientNameCell cell = this.TableView.DequeueReusableCell(ClientNameCellIdentifier) as InvoiceClientNameCell;

				cell.TextLabel.Text = "Jason Ding";

				return cell;
			}
			else 
			{
				if (indexPath.Row == items.Count)
				{
					InvoiceAddItemCell cell = this.TableView.DequeueReusableCell(AddItemCellIdentifier) as InvoiceAddItemCell;

					return cell;
				}
				else
				{
					InvoiceItemCell cell = this.TableView.DequeueReusableCell(ItemCellIdentifier) as InvoiceItemCell;
					cell.TextLabel.Text = items[indexPath.Row];
					cell.DetailTextLabel.Text = "$20,00";

					return cell;
				}
			}
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "Invoice_List_To_ItemDetail_Segue")
			{
				var destCtrl = segue.DestinationViewController as InvoiceItemDetailViewController;

				destCtrl.callingController = this;
			}

			base.PrepareForSegue(segue, sender);
		}

		public override void ViewWillAppear(Boolean animated)
		{
			base.ViewWillAppear(animated);

			this.TableView.ReloadData();
		}

		//async partial void OnBtnInvoiceDateUpInside(UIButton sender)
		//{
		//	var modalPicker = new ModalPickerViewController(ModalPickerType.Date, "Select a Date", this)
		//	{
		//		HeaderBackgroundColor = new UIColor(red: 0.00f, green: 0.46f, blue: 0.98f, alpha: 1.0f),
		//		HeaderTextColor = UIColor.White,
		//		TransitioningDelegate = new ModalPickerTransitionDelegate(),
		//		ModalPresentationStyle = UIModalPresentationStyle.Custom
		//	};

		//	modalPicker.DatePicker.Mode = UIDatePickerMode.Date;

		//	modalPicker.OnModalPickerDismissed += (s, ea) =>
		//	{
		//		var dateFormatter = new NSDateFormatter()
		//		{
		//			DateFormat = "MMMM dd, yyyy"
		//		};

		//		this.btnInvoiceDate.SetTitle(dateFormatter.ToString(modalPicker.DatePicker.Date), UIControlState.Normal);
		//	};

		//	await PresentViewControllerAsync(modalPicker, true);
		//}
    }
}