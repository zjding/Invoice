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
    [Register ("InvoiceDetailViewController")]
    partial class InvoiceDetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnInvoiceCancel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnInvoiceDone { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnInvoiceCancel != null) {
                btnInvoiceCancel.Dispose ();
                btnInvoiceCancel = null;
            }

            if (btnInvoiceDone != null) {
                btnInvoiceDone.Dispose ();
                btnInvoiceDone = null;
            }
        }
    }
}