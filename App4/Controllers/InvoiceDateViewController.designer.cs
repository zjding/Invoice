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
    [Register ("InvoiceDateViewController")]
    partial class InvoiceDateViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnDue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtInvoiceNum { get; set; }

        [Action ("btnDue_UpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnDue_UpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnDue != null) {
                btnDue.Dispose ();
                btnDue = null;
            }

            if (txtInvoiceNum != null) {
                txtInvoiceNum.Dispose ();
                txtInvoiceNum = null;
            }
        }
    }
}