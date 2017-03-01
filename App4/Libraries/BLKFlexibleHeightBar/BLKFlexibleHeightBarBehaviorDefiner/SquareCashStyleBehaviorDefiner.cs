using System;
using UIKit;

namespace BLKFlexibleHeightBarDemo
{
	public class SquareCashStyleBehaviorDefiner : BLKFlexibleHeightBarBehaviorDefiner
	{
		public override void Scrolled (UIScrollView scrollView)
		{
			if(!_currentlySnapping)
			{
				var progress = (scrollView.ContentOffset.Y+scrollView.ContentInset.Top) / (_flexibleHeightBar.MaximumBarHeight-_flexibleHeightBar.MinimumBarHeight);
				_flexibleHeightBar.Progress = progress;
				_flexibleHeightBar.SetNeedsLayout();
			}
		}
	}

}
