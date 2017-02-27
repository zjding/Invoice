using Foundation;
using System;
using UIKit;
using CoreGraphics;
using System.Drawing;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace App4
{
    public partial class InvoicePhotoViewController : UITableViewController
    {
		UIImagePickerController cameraPicker;
		UIImagePickerController photoPicker;

		public bool bNew;

		public Attachment attachment;

		public InvoiceDynamicDetailViewController callingController;

		LoadingOverlay loadingOverlay;

        public InvoicePhotoViewController (IntPtr handle) : base (handle)
        {
			
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//btnCamera.Frame = new RectangleF(0, 0, (float)UIScreen.MainScreen.Bounds.Width / 2, (float)viewButtons.Bounds.Height);
			//btnPhotos.Frame = new RectangleF((float)UIScreen.MainScreen.Bounds.Width / 2, 0, (float)UIScreen.MainScreen.Bounds.Width / 2, (float)viewButtons.Bounds.Height);

			TableView.TableFooterView = new UIView();

			cameraPicker = new UIImagePickerController();
			//picker.FinishedPickingMedia += picker_FinishedPickingMedia;
			//picker.Canceled += picker_Cancelled;
			cameraPicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;

			photoPicker = new UIImagePickerController();
			photoPicker.FinishedPickingMedia += picker_FinishedPickingMedia;
			photoPicker.Canceled += picker_Cancelled;
			photoPicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;

			if (!bNew)
			{
				imgAttachment.Image = attachment.image;
				imgAttachment.ContentMode = UIViewContentMode.ScaleToFill;
				txtDescription.Text = attachment.description;
			}
			else
			{
				//TableView.BeginUpdates();
				//TableView.DeleteSections(new NSIndexSet(1), UITableViewRowAnimation.None);
				//TableView.EndUpdates();
			}
		}

		public override nint NumberOfSections(UITableView tableView)
		{
			if (!bNew)
				return 3;
			else
				return 2;
		}

		partial void btnImage_UpInside(UIButton sender)
		{
			// Create a new Alert Controller
			UIAlertController actionSheetAlert = UIAlertController.Create(null, null, UIAlertControllerStyle.ActionSheet);

			// Add Actions
			actionSheetAlert.AddAction(UIAlertAction.Create("From Camera", UIAlertActionStyle.Default, (action) => { LaunchCamera(); Console.WriteLine("Item One pressed.");}));

			actionSheetAlert.AddAction(UIAlertAction.Create("From Photos", UIAlertActionStyle.Default, (action) => { LaunchPhotoLibrary(); Console.WriteLine("Item Two pressed."); }));

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

		public void LaunchCamera()
		{
			this.PresentViewController(cameraPicker, true, null);
		}

		public void LaunchPhotoLibrary()
		{
			this.PresentViewController(photoPicker, true, null);
		}

		private async void picker_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
		{
			UIImage pickedImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
			this.imgAttachment.Image = pickedImage;
			this.imgAttachment.ContentMode = UIViewContentMode.ScaleToFill;
			await this.photoPicker.DismissViewControllerAsync(true);
		}

		async private void picker_Cancelled(object sender, EventArgs e)
		{
			await this.photoPicker.DismissViewControllerAsync(true);
		}

		async partial void btnSave_UpInside(UIBarButtonItem sender)
		{
			var resizedImage = ImageManager.ResizeImage(this.imgAttachment.Image, 1000, 1000);

			var imageStream = resizedImage.AsJPEG((System.nfloat)0.75).AsStream();

			var bounds = UIScreen.MainScreen.Bounds;

			loadingOverlay = new LoadingOverlay(bounds);
			this.View.Add(loadingOverlay);

			if (bNew)
			{
				var name = await ImageManager.UploadImage(imageStream);

				Attachment attachment = new Attachment();
				attachment.imageName = name;
				attachment.image = this.imgAttachment.Image;
				attachment.description = this.txtDescription.Text;

				/////
				string jsonString = JsonConvert.SerializeObject(attachment);

				HttpClient httpClient = new HttpClient();

				var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

				var result = await httpClient.PostAsync("http://webapitry120161228015023.azurewebsites.net/api/Attachment/AddAttachment", content);

				var contents = await result.Content.ReadAsStringAsync();

				string returnMessage = contents.ToString();

				loadingOverlay.Hide();

				if (returnMessage == "\"Added attachment successfully\"")
				{
					this.callingController.attachments.Add(attachment);
					callingController.DismissViewController(true, null);
				}
			}
			else
			{
				await ImageManager.DeleteImage(attachment.imageName);

				var name = await ImageManager.UploadImage(imageStream);

				Invoice_Model.Attachment att = new Invoice_Model.Attachment();
				att.id = attachment.id;
				att.imageName = name;
				att.description = txtDescription.Text;

				attachment.imageName = name;
				attachment.image = this.imgAttachment.Image;
				attachment.description = this.txtDescription.Text;

				string jsonString = JsonConvert.SerializeObject(att);

				HttpClient httpClient = new HttpClient();

				var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

				var result = await httpClient.PutAsync("http://webapitry120161228015023.azurewebsites.net/api/Attachment/PutAttachment", content);

				var contents = await result.Content.ReadAsStringAsync();

				string returnMessage = contents.ToString();

				loadingOverlay.Hide();

				if (returnMessage == "\"Updated attachment successfully\"")
				{
					int i = callingController.attachments.FindIndex(a => a.id == att.id);
					callingController.attachments.RemoveAt(i);
					callingController.attachments.Insert(i, attachment);
					this.NavigationController.PopViewController(true);
				}

			}
		}

		partial void btnCancel_UpInside(UIBarButtonItem sender)
		{
			if (!bNew)
				this.NavigationController.PopViewController(true);
			else
				callingController.DismissViewController(true, null);
		}

		public override void WillDisplayHeaderView(UITableView tableView, UIView headerView, nint section)
		{

			var header = headerView as UITableViewHeaderFooterView;

			header.TextLabel.TextColor = UIColor.DarkGray;
			header.TextLabel.Font = UIFont.BoldSystemFontOfSize(12);

		}

		async partial void btnDelete_UpInside(UIButton sender)
		{
			var bounds = UIScreen.MainScreen.Bounds;
			loadingOverlay = new LoadingOverlay(bounds);
			this.View.Add(loadingOverlay);

			////
			HttpClient httpClient = new HttpClient();

			var result = await httpClient.DeleteAsync("http://webapitry120161228015023.azurewebsites.net/api/Attachment/Delete/" + attachment.id.ToString());

			result.EnsureSuccessStatusCode();

			await ImageManager.DeleteImage(attachment.imageName);

			loadingOverlay.Hide();

			if (result.IsSuccessStatusCode)
			{
				int i = callingController.attachments.FindIndex(a => a.id == attachment.id);
				callingController.attachments.RemoveAt(i);
				this.NavigationController.PopViewController(true);
			}
		}
	}
}