using Foundation;
using System;
using UIKit;

namespace App4
{
    public partial class testController : UIViewController
    {
        public testController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			this.NavigationController.SetNavigationBarHidden(false, false);
		}
    }
}