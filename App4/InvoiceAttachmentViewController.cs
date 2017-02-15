using Foundation;
using System;
using UIKit;

namespace App4
{
    public partial class InvoiceAttachmentViewController : UICollectionViewController
    {
        public InvoiceAttachmentViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
		}

		public override nint NumberOfSections(UICollectionView collectionView)
		{
			return 1;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return 10;
		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
			var _cell = (InvoiceAttachmentCollectionViewCell)collectionView.DequeueReusableCell("collectionCellIdentifier", indexPath);



			//var img = UIImage.FromFile("Images/Add.png");



			return _cell;
		}
    }
}