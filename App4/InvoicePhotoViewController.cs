using Foundation;
using System;
using UIKit;
using CoreGraphics;
using System.Drawing;

namespace App4
{
    public partial class InvoicePhotoViewController : UITableViewController
    {
        public InvoicePhotoViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//btnCamera.Frame = new RectangleF(0, 0, (float)UIScreen.MainScreen.Bounds.Width / 2, (float)viewButtons.Bounds.Height);
			//btnPhotos.Frame = new RectangleF((float)UIScreen.MainScreen.Bounds.Width / 2, 0, (float)UIScreen.MainScreen.Bounds.Width / 2, (float)viewButtons.Bounds.Height);


		}
    }
}