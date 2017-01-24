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
    [Register ("LogoImageViewController")]
    partial class LogoImageViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Logo_btnLogo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Logo_btnUpload { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView Logo_imgLogo { get; set; }

        [Action ("Logo_btnLogo_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Logo_btnLogo_TouchUpInside (UIKit.UIButton sender);

        [Action ("Logo_btnUpload_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Logo_btnUpload_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (Logo_btnLogo != null) {
                Logo_btnLogo.Dispose ();
                Logo_btnLogo = null;
            }

            if (Logo_btnUpload != null) {
                Logo_btnUpload.Dispose ();
                Logo_btnUpload = null;
            }

            if (Logo_imgLogo != null) {
                Logo_imgLogo.Dispose ();
                Logo_imgLogo = null;
            }
        }
    }
}