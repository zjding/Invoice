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
    [Register ("InvoiceNameCell")]
    partial class InvoiceNameCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblDueTerm { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblInvoiceName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblDueTerm != null) {
                lblDueTerm.Dispose ();
                lblDueTerm = null;
            }

            if (lblInvoiceName != null) {
                lblInvoiceName.Dispose ();
                lblInvoiceName = null;
            }
        }
    }
}