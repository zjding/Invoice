// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace App4
{
    [Register ("InvoicePhotoViewController")]
    partial class InvoicePhotoViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgAttachment { get; set; }

        [Action ("btnImage_UpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnImage_UpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnImage != null) {
                btnImage.Dispose ();
                btnImage = null;
            }

            if (imgAttachment != null) {
                imgAttachment.Dispose ();
                imgAttachment = null;
            }
        }
    }
}