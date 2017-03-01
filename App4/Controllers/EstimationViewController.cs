using Foundation;
using System;
using UIKit;
using BLKFlexibleHeightBarDemo;

namespace App4
{
    public partial class EstimationViewController : UIViewController
    {
		SquareCashStyleBar _headerBar;

        public EstimationViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			SetNeedsStatusBarAppearanceUpdate();

			_headerBar = new SquareCashStyleBar(new CoreGraphics.CGRect(0f, 0f, View.Frame.Width, 100f));

			var behaviorDefiner = new SquareCashStyleBehaviorDefiner();
			behaviorDefiner.AddSnappingPositionProgress(0f, 0f, .5f);
			behaviorDefiner.AddSnappingPositionProgress(1f, .5f, 1f);
			behaviorDefiner.IsSnappingEnabled = true;
			behaviorDefiner.IsElasticMaximumHeightAtTop = true;
			tableView.Delegate = behaviorDefiner;
			_headerBar.BehaviorDefiner = behaviorDefiner;

			View.AddSubview(_headerBar);
		}

		public override UIStatusBarStyle PreferredStatusBarStyle()
		{
			return UIStatusBarStyle.LightContent;
		}
    }
}