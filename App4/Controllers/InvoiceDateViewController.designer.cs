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
        UIKit.UITextField txtIssueDate { get; set; }

        [Action ("txtIssueDate_EditingDidBegin:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void txtIssueDate_EditingDidBegin (UIKit.UITextField sender);

        [Action ("txtIssueDate_UpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void txtIssueDate_UpInside (UIKit.UITextField sender);

        void ReleaseDesignerOutlets ()
        {
            if (txtIssueDate != null) {
                txtIssueDate.Dispose ();
                txtIssueDate = null;
            }
        }
    }
}