using System;
using System.Collections.Generic;
using UIKit;

namespace App4
{
	public class RaisedTabBarController: UITabBarController 
	{
		public RaisedTabBarController()
		{
		}

		public RaisedTabBarController(IntPtr handle) : base (handle)
        {

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
		}

		public void InsertEmptyTabItem(string title, int i)
		{
			var vc = new UIViewController();

			vc.TabBarItem = new UITabBarItem(title, null, 0);
			vc.TabBarItem.Enabled = false;

			List<UIViewController> viewCtlList = new List<UIViewController>(this.ViewControllers);

			viewCtlList.Insert(i, vc);

			this.ViewControllers = viewCtlList.ToArray();
		}

		public void AddRaisedButton(UIImage buttonImage, UIImage highlightImage)
		{
			var button = new UIButton(UIButtonType.Custom);

			button.AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin |
				UIViewAutoresizing.FlexibleLeftMargin |
				UIViewAutoresizing.FlexibleBottomMargin |
				UIViewAutoresizing.FlexibleTopMargin;

			button.Frame = new CoreGraphics.CGRect(0, 0, buttonImage.Size.Width, buttonImage.Size.Height);

			button.SetBackgroundImage(buttonImage, UIControlState.Normal);
			button.SetBackgroundImage(highlightImage, UIControlState.Highlighted);

			var heightDifference = buttonImage.Size.Height - this.TabBar.Frame.Size.Height;

			if (heightDifference < 0)
			{
				button.Center = this.TabBar.Center;
			}
			else
			{
				var center = this.TabBar.Center;
				center.Y -= (nfloat)(heightDifference / 2.0);
				button.Center = center;
			}

			button.TouchUpInside += onRaisedButton_TouchUpInside;

			this.View.AddSubview(button);
		}

		public virtual void onRaisedButton_TouchUpInside(object sender, EventArgs e)
		{

		}
	}
}
