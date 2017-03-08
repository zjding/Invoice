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
        UIKit.UIBarButtonItem btnDone { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnDue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnDueDate { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnIssueDate { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtInvoiceNum { get; set; }

        [Action ("btnDone_UpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnDone_UpInside (UIKit.UIBarButtonItem sender);

        [Action ("btnDue_UpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnDue_UpInside (UIKit.UIButton sender);

        [Action ("btnIssueDate_Change:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnIssueDate_Change (UIKit.UIButton sender);

        [Action ("btnIssueDate_UpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnIssueDate_UpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnDone != null) {
                btnDone.Dispose ();
                btnDone = null;
            }

            if (btnDue != null) {
                btnDue.Dispose ();
                btnDue = null;
            }

            if (btnDueDate != null) {
                btnDueDate.Dispose ();
                btnDueDate = null;
            }

            if (btnIssueDate != null) {
                btnIssueDate.Dispose ();
                btnIssueDate = null;
            }

            if (txtInvoiceNum != null) {
                txtInvoiceNum.Dispose ();
                txtInvoiceNum = null;
            }
        }
    }
}