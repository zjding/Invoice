using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
using Invoice_Model;
using System.Net.Http;
using Newtonsoft.Json;

namespace App4
{
	
    

    public partial class InvoiceDynamicDetailViewController : UITableViewController
    {
		public string InvoiceNameCellIdentifier = "InvoiceNameCellIdentifier";
		public string ClientNameCellIdentifier = "ClientNameCellIdentifier";
		public string ItemCellIdentifier = "ItemCellIdentifier";
		public string AddItemCellIdentifier = "AddItemCellIdentifier";
		public string InvoiceSignatureCellIdentifier = "InvoiceSignatureCellIdentifier";
		public string InvoiceAttachmentCellIdentifier = "InvoiceAttachmentCellIdentifier";

		public List<Item> items = new List<Item>();
		public Client client = new Client();
		public List<UIImage> images = new List<UIImage>();

		LoadingOverlay loadingOverlay;

		HttpClient httpClient = new HttpClient();

		//List<string> Items = new List<string>();

        public InvoiceDynamicDetailViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//items.Add("Item 1");

		}

		public override nint NumberOfSections(UITableView tableView)
		{
			return 5;
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
			else if (section == 3)
			{
				return 2;
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

				cell.TextLabel.Text = "Client";
				cell.DetailTextLabel.Text = client.FirstName + " " + client.LastName;

				return cell;
			}
			else if (indexPath.Section == 2)
			{
				if (indexPath.Row == items.Count)
				{
					InvoiceAddItemCell cell = this.TableView.DequeueReusableCell(AddItemCellIdentifier) as InvoiceAddItemCell;

					return cell;
				}
				else
				{
					InvoiceItemCell cell = this.TableView.DequeueReusableCell(ItemCellIdentifier) as InvoiceItemCell;
					cell.TextLabel.Text = items[indexPath.Row].Name;
					cell.DetailTextLabel.Text = (items[indexPath.Row].Price * items[indexPath.Row].Quantity).ToString();

					return cell;
				}
			}
			else
			{
				if (indexPath.Row == 0)
				{
					InvoiceSignatureCell cell = this.TableView.DequeueReusableCell(InvoiceSignatureCellIdentifier) as InvoiceSignatureCell;

					//cell.TextLabel.Text = "Client";
					//cell.DetailTextLabel.Text = client.FirstName + " " + client.LastName;

					return cell;
				}
				else
				{
					InvoiceAttachmentCell cell = this.TableView.DequeueReusableCell(InvoiceAttachmentCellIdentifier) as InvoiceAttachmentCell;

					//cell.TextLabel.Text = "Client";
					//cell.DetailTextLabel.Text = client.FirstName + " " + client.LastName;

					return cell;
				}
			}
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "Invoice_To_Item_Segue")
			{


				var destCtrl = segue.DestinationViewController as UINavigationController;

				((InvoiceItemDetailViewController)(destCtrl.ViewControllers[0])).callingController = this;

			}
			else if (segue.Identifier == "Invoice_To_Client_Segue")
			{
				var destCtrl = segue.DestinationViewController as ClientListTableViewController;

				destCtrl.bPickClientMode = true;

				destCtrl.invoiceViewController = this;
			}
			else if (segue.Identifier == "Invoice_To_Signature_Segue")
			{
				var destCtrl = segue.DestinationViewController as UINavigationController;

				((InvoiceSignatureViewController)(destCtrl.ViewControllers[0])).callingViewController = this;
			}
			else if (segue.Identifier == "Invoice_To_Attachment_Segue")
			{
				var destCtrl = segue.DestinationViewController as UINavigationController;

				((InvoiceAttachmentViewController)(destCtrl.ViewControllers[0])).callingController = this;
			}

			base.PrepareForSegue(segue, sender);
		}

		async public override void ViewWillAppear(Boolean animated)
		{
			base.ViewWillAppear(animated);

			var bounds = UIScreen.MainScreen.Bounds;

			loadingOverlay = new LoadingOverlay(bounds);
			this.View.Add(loadingOverlay);

			string result = await httpClient.GetStringAsync("http://webapitry120161228015023.azurewebsites.net/api/Item/GetItems");

			items = JsonConvert.DeserializeObject<List<Item>>(result);

			loadingOverlay.Hide();

			this.TableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;

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