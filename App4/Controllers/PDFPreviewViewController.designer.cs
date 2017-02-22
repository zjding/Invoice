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
    [Register ("PDFPreviewViewController")]
    partial class PDFPreviewViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIWebView PDFPreview_wvPDF { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (PDFPreview_wvPDF != null) {
                PDFPreview_wvPDF.Dispose ();
                PDFPreview_wvPDF = null;
            }
        }
    }
}