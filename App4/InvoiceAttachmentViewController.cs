using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace App4
{
    public partial class InvoiceAttachmentViewController : UICollectionViewController
    {
		public List<UIImage> images = new List<UIImage>();

		UIImagePickerController imagePicker;

        public InvoiceAttachmentViewController (IntPtr handle) : base (handle)
		{
			//for (int i = 0; i < 10; i++)
			//{
			//	images.Add(UIImage.FromFile("Images/Settings-25.png"));
			//}
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			imagePicker = new UIImagePickerController();

			imagePicker.FinishedPickingMedia += ImagePicker_FinishedPickingMedia;
			imagePicker.Canceled += ImagePicker_Cancelled;

			imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;

			var layout = new UICollectionViewFlowLayout();
			layout.ItemSize = new CoreGraphics.CGSize((UIScreen.MainScreen.Bounds.Width - 15) / 4, (UIScreen.MainScreen.Bounds.Width - 15) / 4);
			layout.MinimumLineSpacing = 5;
			layout.MinimumInteritemSpacing = 5;
			CollectionView.CollectionViewLayout = layout;
		}

		public override nint NumberOfSections(UICollectionView collectionView)
		{
			return 1;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return images.Count + 1;
		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
            InvoiceAttachmentCollectionViewCell _cell = (InvoiceAttachmentCollectionViewCell)collectionView.DequeueReusableCell("collectionCellIdentifier", indexPath);

			if (indexPath.Item == images.Count)
            	_cell.cellImage.Image = UIImage.FromFile("Images/AddImage.png");
			else 
				_cell.cellImage.Image = images[(int)indexPath.Item];
			
			return _cell;
		}
	

		async public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
		{

			if (indexPath.Item == images.Count)
			{
				await this.PresentViewControllerAsync(this.imagePicker, true);
			}
		}

		private async void ImagePicker_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
		{
			UIImage pickedImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
			images.Add(pickedImage);
			await this.imagePicker.DismissViewControllerAsync(true);
			CollectionView.ReloadData();

		}

		async private void ImagePicker_Cancelled(object sender, EventArgs e)
		{
			await this.imagePicker.DismissViewControllerAsync(true);
		}



    }
}