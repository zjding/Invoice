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
    [Register ("BusinessDetailsViewController")]
    partial class BusinessDetailsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem BusinessDetails_btnSave { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationItem BusinessDetails_NavigationItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField BusinessDetails_txtCompanyName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField BusinessDetails_txtOwnerName { get; set; }

        [Action ("BusinessDetails_btnSave_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BusinessDetails_btnSave_TouchUpInside (UIKit.UIBarButtonItem sender);

        [Action ("BusinessDetails_txtCompanyName_OnEditingDidBegin:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BusinessDetails_txtCompanyName_OnEditingDidBegin (UIKit.UITextField sender);

        void ReleaseDesignerOutlets ()
        {
            if (BusinessDetails_btnSave != null) {
                BusinessDetails_btnSave.Dispose ();
                BusinessDetails_btnSave = null;
            }

            if (BusinessDetails_NavigationItem != null) {
                BusinessDetails_NavigationItem.Dispose ();
                BusinessDetails_NavigationItem = null;
            }

            if (BusinessDetails_txtCompanyName != null) {
                BusinessDetails_txtCompanyName.Dispose ();
                BusinessDetails_txtCompanyName = null;
            }

            if (BusinessDetails_txtOwnerName != null) {
                BusinessDetails_txtOwnerName.Dispose ();
                BusinessDetails_txtOwnerName = null;
            }
        }
    }
}