using Foundation;
using System;
using UIKit;
using SignaturePad;

namespace App4
{
    public partial class InvoiceSignatureViewController : UIViewController
    {
        public InvoiceSignatureViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			signaturePad.Layer.ShadowOpacity = 0f;

		}
    }
}