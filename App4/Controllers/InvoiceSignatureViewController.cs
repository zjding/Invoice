using Foundation;
using System;
using UIKit;
using SignaturePad;

namespace App4
{
    public partial class InvoiceSignatureViewController : UIViewController
    {
		public InvoiceDynamicDetailViewController callingViewController;

        public InvoiceSignatureViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			signaturePad.Layer.ShadowOpacity = 0f;

			UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)UIInterfaceOrientation.LandscapeLeft), new NSString("orientation"));

			AttemptRotationToDeviceOrientation(); 

		}

		partial void btnDone_TouchUpInside(UIBarButtonItem sender)
		{
			var signitureImage = signaturePad.GetImage();

			var documentsDirectory = Environment.GetFolderPath
						 (Environment.SpecialFolder.Personal);
			string jpgFilename = System.IO.Path.Combine(documentsDirectory, "Photo.jpg"); // hardcoded filename, overwritten each time
			NSData imgData = signitureImage.AsJPEG();
			NSError err = null;
			if (imgData.Save(jpgFilename, false, out err))
			{
				Console.WriteLine("saved as " + jpgFilename);
			}
			else
			{
				Console.WriteLine("NOT saved as " + jpgFilename + " because" + err.LocalizedDescription);
			}

			UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)UIInterfaceOrientation.Portrait), new NSString("orientation"));
			AttemptRotationToDeviceOrientation();

			callingViewController.DismissViewController(true, null);
		}

		partial void btnCancel_TouchUpInside(UIBarButtonItem sender)
		{
			UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)UIInterfaceOrientation.Portrait), new NSString("orientation"));
			AttemptRotationToDeviceOrientation();

			callingViewController.DismissViewController(true, null);
		}
	}
}