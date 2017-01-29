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

				return nameCell;
			}
			else if (indexPath.Section == 1)
			{
				UITableViewCell cell = this.TableView.DequeueReusableCell(ClientNameCellIdentifier);

				if (cell == null)
				{
					cell = new UITableViewCell(UITableViewCellStyle.Default, ClientNameCellIdentifier);
				}

				cell.TextLabel.Text = "Section 2";

				return cell;
			}
			else 
			{
				UITableViewCell cell = this.TableView.DequeueReusableCell(ItemCellIdentifier);

				if (cell == null)
				{
					cell = new UITableViewCell(UITableViewCellStyle.Default, ItemCellIdentifier);
				}

				if (indexPath.Row == items.Count)
				{
					cell.TextLabel.Text = "Add Item";
				}
				else
				{
					cell.TextLabel.Text = items[indexPath.Row];
				}

				return cell;
			}
		}
    }
}