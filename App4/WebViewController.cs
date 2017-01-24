using Foundation;
using System;
using UIKit;

namespace App4
{
    public partial class WebViewController : UIViewController
    {
        public WebViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var url = "https://zjdingstorage.blob.core.windows.net/container1/4.pdf";
            webView.LoadRequest(new NSUrlRequest(new NSUrl(url)));
        }
    }
}