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
    [Register ("InvoiceItemDetailViewController")]
    partial class InvoiceItemDetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch swTaxable { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCost { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtDescription { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtNote { get; set; }

        [Action ("btnClose_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnClose_TouchUpInside (UIKit.UIBarButtonItem sender);

        [Action ("btnSave_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnSave_TouchUpInside (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (swTaxable != null) {
                swTaxable.Dispose ();
                swTaxable = null;
            }

            if (txtCost != null) {
                txtCost.Dispose ();
                txtCost = null;
            }

            if (txtDescription != null) {
                txtDescription.Dispose ();
                txtDescription = null;
            }

            if (txtNote != null) {
                txtNote.Dispose ();
                txtNote = null;
            }
        }
    }
}