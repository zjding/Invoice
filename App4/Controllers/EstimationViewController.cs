using Foundation;
using System;
using UIKit;
using BLKFlexibleHeightBarDemo;
using CoreGraphics;

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

			_headerBar = new SquareCashStyleBar(new CGRect(0f, 0f, View.Frame.Width, 50f));

			var behaviorDefiner = new SquareCashStyleBehaviorDefiner();
			behaviorDefiner.AddSnappingPositionProgress(0f, 0f, .5f);
			behaviorDefiner.AddSnappingPositionProgress(1f, .5f, 1f);
			behaviorDefiner.IsSnappingEnabled = true;
			behaviorDefiner.IsElasticMaximumHeightAtTop = true;
			tableView.Delegate = behaviorDefiner;
			_headerBar.BehaviorDefiner = behaviorDefiner;

			View.AddSubview(_headerBar);

			tableView.ContentInset = new UIEdgeInsets(_headerBar.MaximumBarHeight, 0f, 0f, 0f);

			var closeButton = new BLKFlexibleHeightBarSubviewUIButton();
			closeButton.Frame = new CGRect(0f, 0f, 30f, 30f);
			closeButton.TintColor = UIColor.White;
			closeButton.SetImage(UIImage.FromFile(@"Images/Multiply-50-white.png"), UIControlState.Normal);
			//closeButton.AddTarget(CloseViewController, UIControlEvent.TouchUpInside);
			_headerBar.AddSubview(closeButton);
		}

		public override UIStatusBarStyle PreferredStatusBarStyle()
		{
			return UIStatusBarStyle.LightContent;
		}

		public override bool PrefersStatusBarHidden()
		{
			return true;
		}
    }
}