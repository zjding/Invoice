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
    [Register ("ClientAddViewController")]
    partial class ClientAddViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnImportContact { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCity { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCountry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtEmail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtPhone { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtPostCode { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtState { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtStreet1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtStreet2 { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnImportContact != null) {
                btnImportContact.Dispose ();
                btnImportContact = null;
            }

            if (txtCity != null) {
                txtCity.Dispose ();
                txtCity = null;
            }

            if (txtCountry != null) {
                txtCountry.Dispose ();
                txtCountry = null;
            }

            if (txtEmail != null) {
                txtEmail.Dispose ();
                txtEmail = null;
            }

            if (txtName != null) {
                txtName.Dispose ();
                txtName = null;
            }

            if (txtPhone != null) {
                txtPhone.Dispose ();
                txtPhone = null;
            }

            if (txtPostCode != null) {
                txtPostCode.Dispose ();
                txtPostCode = null;
            }

            if (txtState != null) {
                txtState.Dispose ();
                txtState = null;
            }

            if (txtStreet1 != null) {
                txtStreet1.Dispose ();
                txtStreet1 = null;
            }

            if (txtStreet2 != null) {
                txtStreet2.Dispose ();
                txtStreet2 = null;
            }
        }
    }
}