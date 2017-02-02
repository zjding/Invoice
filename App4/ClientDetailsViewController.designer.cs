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
    [Register ("ClientDetailsViewController")]
    partial class ClientDetailsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnImportFromContacts { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtClientAddress1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtClientAddress2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtClientAddress3 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtClientEmail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtClientName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtClientPhone { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnImportFromContacts != null) {
                btnImportFromContacts.Dispose ();
                btnImportFromContacts = null;
            }

            if (txtClientAddress1 != null) {
                txtClientAddress1.Dispose ();
                txtClientAddress1 = null;
            }

            if (txtClientAddress2 != null) {
                txtClientAddress2.Dispose ();
                txtClientAddress2 = null;
            }

            if (txtClientAddress3 != null) {
                txtClientAddress3.Dispose ();
                txtClientAddress3 = null;
            }

            if (txtClientEmail != null) {
                txtClientEmail.Dispose ();
                txtClientEmail = null;
            }

            if (txtClientName != null) {
                txtClientName.Dispose ();
                txtClientName = null;
            }

            if (txtClientPhone != null) {
                txtClientPhone.Dispose ();
                txtClientPhone = null;
            }
        }
    }
}