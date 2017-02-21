using Foundation;
using System;
using UIKit;
using CoreGraphics;
using System.Drawing;

namespace App4
{
    public partial class InvoicePhotoViewController : UITableViewController
    {
		UIImagePickerController cameraPicker;
		UIImagePickerController photoPicker;

		public InvoiceDynamicDetailViewController callingController;

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
			var imageStream = this.imgAttachment.Image.AsJPEG().AsStream();

			var name = await ImageManager.UploadImage(imageStream);

			Attachment attachment = new Attachment();
			attachment.imageName = name;
			attachment.image = this.imgAttachment.Image;
			attachment.description = this.txtDescription.Text;

			this.callingController.attachments.Add(attachment);

			this.callingController.DismissViewController(true, null);
		}

		partial void btnCancel_UpInside(UIBarButtonItem sender)
		{
			this.callingController.DismissViewController(true, null);
		}
	}
}