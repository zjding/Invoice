using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
using Invoice_Model;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Globalization;

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
		public string AddAttachmentCellIdentifier = "AddAttachmentCellIdentifier";
		public string InvoiceItemDisplayCellIdentifier = "InvoiceItemDisplayCellIdentifier";
		public string InvoiceSubtotalCellIdentifier = "InvoiceSubtotalCellIdentifier";
		public string InvoiceTaxCellIdentifier = "InvoiceTaxCellIdentifier";

		public List<Item> items = new List<Item>();
		public Client client = new Client();
		public List<UIImage> images = new List<UIImage>();
		public List<Attachment> attachments = new List<Attachment>();
		public Attachment selectedAttachment;

		LoadingOverlay loadingOverlay;

		HttpClient httpClient = new HttpClient();

		//List<string> Items = new List<string>();

        public InvoiceDynamicDetailViewController (IntPtr handle) : base (handle)
        {
        }

		async public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//items.Add("Item 1");
			this.NavigationItem.Title = "Invoice #1";

			var bounds = UIScreen.MainScreen.Bounds;

			loadingOverlay = new LoadingOverlay(bounds);
			this.View.Add(loadingOverlay);

			string result = await httpClient.GetStringAsync("http://webapitry120161228015023.azurewebsites.net/api/Item/GetItems");

			items = JsonConvert.DeserializeObject<List<Item>>(result);

			result = await httpClient.GetStringAsync("http://webapitry120161228015023.azurewebsites.net/api/Attachment/GetAttachments");

			List<Invoice_Model.Attachment> atts = JsonConvert.DeserializeObject<List<Invoice_Model.Attachment>>(result);

			foreach (Invoice_Model.Attachment att in atts)
			{
				Attachment attachment = new Attachment();
				attachment.id = att.id;
				attachment.imageName = att.imageName;

				var bytes = Task.Run(() => ImageManager.GetImage(att.imageName)).Result;
				var data = NSData.FromArray(bytes);
				attachment.image = UIImage.LoadFromData(data);

				attachment.description = att.description;
				attachments.Add(attachment);
			}

			loadingOverlay.Hide();

			this.TableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;

			this.TableView.ReloadData();

		}

		public override nint NumberOfSections(UITableView tableView)
		{
			return 6;
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
			if (section == 0) // invoice name
			{
				return 1;
			}
			else if (section == 1) // client name
			{
				return 1;
			}
			else if (section == 2) // items
			{
				return items.Count + 1;
			}
			else if (section == 3) // total
			{
				return 2;
			}
			else if (section == 4) // attachments
			{
				return attachments.Count + 1;
			}
			else if (section == 5) // signature
			{
				return 1;
			}

			return 0;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			if (indexPath.Section == 0)
			{
				InvoiceNameCell nameCell = this.TableView.DequeueReusableCell(InvoiceNameCellIdentifier) as InvoiceNameCell;

				//nameCell.lblInvoiceName.Text = "INVOICE-00001";

				var dateFormatter = new NSDateFormatter()
				{
					DateFormat = "MMMM dd, yyyy"
				};

				var curDate = new NSDate();

				//nameCell.btnDate.SetTitle(dateFormatter.ToString(curDate), UIControlState.Normal);
				nameCell.viewController = this;

				return nameCell;
			}
			else if (indexPath.Section == 1)
			{
				InvoiceClientNameCell cell = this.TableView.DequeueReusableCell(ClientNameCellIdentifier) as InvoiceClientNameCell;

				//cell.TextLabel.Text = "Client";
				//cell.DetailTextLabel.Text = client.FirstName + " " + client.LastName;

				return cell;
			}
			else if (indexPath.Section == 2) // item
			{
				if (indexPath.Row == 0)
				{
					InvoiceAddItemCell cell = this.TableView.DequeueReusableCell(AddItemCellIdentifier) as InvoiceAddItemCell;

					return cell;
				}
				else
				{
					//InvoiceItemCell cell = this.TableView.DequeueReusableCell(ItemCellIdentifier) as InvoiceItemCell;
					InvoiceItemDisplayCell cell = this.TableView.DequeueReusableCell(InvoiceItemDisplayCellIdentifier) as InvoiceItemDisplayCell;
					cell.lblName.Text = items[indexPath.Row-1].Name;
					cell.lblUnitPrice.Text = items[indexPath.Row-1].Price.ToString("C", CultureInfo.CurrentCulture) + " x " + items[indexPath.Row-1].Quantity.ToString();
					cell.lblPrice.Text = (items[indexPath.Row-1].Price * items[indexPath.Row-1].Quantity).ToString("C", CultureInfo.CurrentCulture);
					cell.lblNumber.Text = (indexPath.Row).ToString();

					return cell;
				}
			}
			else if (indexPath.Section == 3) // total
			{
				if (indexPath.Row == 0)
				{
					InvoiceSubtotalCell cell = this.TableView.DequeueReusableCell(InvoiceSubtotalCellIdentifier) as InvoiceSubtotalCell;
					return cell;
				}
				else 
				{
					InvoiceTaxCell cell = this.TableView.DequeueReusableCell(InvoiceTaxCellIdentifier) as InvoiceTaxCell;
					return cell;
				}


			}
			else if (indexPath.Section == 4) // attachment
			{
				if (indexPath.Row == attachments.Count)
				{
					InvoiceAddAttachmentCell cell = this.TableView.DequeueReusableCell(AddAttachmentCellIdentifier) as InvoiceAddAttachmentCell;

					return cell;
				}
				else
				{
					InvoiceAttachmentCell cell = this.TableView.DequeueReusableCell(InvoiceAttachmentCellIdentifier) as InvoiceAttachmentCell;

					cell.imgAttachment.Image = attachments[indexPath.Row].image;
					cell.lblDescription.Text = attachments[indexPath.Row].description;

					return cell;
				}
			}
			else
			{
				InvoiceSignatureCell cell = this.TableView.DequeueReusableCell(InvoiceSignatureCellIdentifier) as InvoiceSignatureCell;

				return cell;
			}
		}

		public override NSIndexPath WillSelectRow(UITableView tableView, NSIndexPath indexPath)
		{
			if (indexPath.Section == 3 && indexPath.Row < attachments.Count) // attachment
			{
				selectedAttachment = attachments[indexPath.Row];
			}

			return indexPath;
		}

		public override void WillDisplayHeaderView(UITableView tableView, UIView headerView, nint section)
		{

			var header = headerView as UITableViewHeaderFooterView;

			header.TextLabel.TextColor = UIColor.DarkGray;
			header.TextLabel.Font = UIFont.BoldSystemFontOfSize(12);

		}

		public override string TitleForHeader(UITableView tableView, nint section)
		{
			if (section == 0)
				return " ";
			//if (section == 1)
			//	return "Client";
			if (section == 2)
				return "Items";

			return base.TitleForHeader(tableView, section);
		}

		public override string TitleForFooter(UITableView tableView, nint section)
		{
			if (section == 1)
				return " ";

			return base.TitleForFooter(tableView, section);
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
			//else if (segue.Identifier == "Invoice_To_Attachment_Segue")
			//{
			//	var destCtrl = segue.DestinationViewController as UINavigationController;

			//	((InvoiceAttachmentViewController)(destCtrl.ViewControllers[0])).callingController = this;
			//}
			else if (segue.Identifier == "Invoice_To_Attachment_Segue")
			{
				var destCtrl = segue.DestinationViewController as UINavigationController;

				((InvoicePhotoViewController)(destCtrl.ViewControllers[0])).callingController = this;
				((InvoicePhotoViewController)(destCtrl.ViewControllers[0])).bNew = true;
			}
			else if (segue.Identifier == "Invoice_To_ExistingAttachment_Segue")
			{
				var destCtrl = segue.DestinationViewController as InvoicePhotoViewController;

				destCtrl.callingController = this;
				destCtrl.bNew = false;
				destCtrl.attachment = selectedAttachment;
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