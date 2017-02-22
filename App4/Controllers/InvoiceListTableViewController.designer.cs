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
    [Register ("InvoiceListTableViewController")]
    partial class InvoiceListTableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnAddInvoice { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl segPaidUnpaid { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnAddInvoice != null) {
                btnAddInvoice.Dispose ();
                btnAddInvoice = null;
            }

            if (segPaidUnpaid != null) {
                segPaidUnpaid.Dispose ();
                segPaidUnpaid = null;
            }
        }
    }
}