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

        void ReleaseDesignerOutlets ()
        {
            if (btnImportFromContacts != null) {
                btnImportFromContacts.Dispose ();
                btnImportFromContacts = null;
            }
        }
    }
}