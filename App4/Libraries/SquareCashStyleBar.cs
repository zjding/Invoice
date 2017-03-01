using UIKit;
using CoreGraphics;

namespace BLKFlexibleHeightBarDemo
{
	public class SquareCashStyleBar : BLKFlexibleHeightBar
	{
		public SquareCashStyleBar (CGRect frame) : base(frame)
		{
			ConfigureBar ();
		}

		public SquareCashStyleBar()
		{
			ConfigureBar ();
		}

		void ConfigureBar()
		{
			// Configure bar appearence
			_maximumBarHeight = 200.0f;
			_minimumBarHeight = 65.0f;
			BackgroundColor = UIColor.FromRGBA (.17f, .63f, .11f, 1.0f);

			// Add and configure name label
			var nameLabel = new BLKFlexibleHeightBarSubviewUILabel ();
			nameLabel.Font = UIFont.SystemFontOfSize (22f);
			nameLabel.TextColor = UIColor.White;
			nameLabel.Text = "Bryan Keller";

			var initialNameLabelLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes();
			initialNameLabelLayoutAttributes.Size = nameLabel.SizeThatFits (CGSize.Empty);
			initialNameLabelLayoutAttributes.Center = new CGPoint (Frame.Size.Width * .5f, _maximumBarHeight - 50f);
			nameLabel.AddLayoutAttributes (initialNameLabelLayoutAttributes, 0f);

			var midwayNameLabelLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes (initialNameLabelLayoutAttributes);
			midwayNameLabelLayoutAttributes.Center = new CGPoint (Frame.Size.Width * .5f, (_maximumBarHeight - _minimumBarHeight) * .4f + _minimumBarHeight - 50f);
			nameLabel.AddLayoutAttributes (midwayNameLabelLayoutAttributes, .6f);

			var finalNameLabelLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes (midwayNameLabelLayoutAttributes);
			finalNameLabelLayoutAttributes.Center = new CGPoint (Frame.Size.Width * .5f, _minimumBarHeight - 25f);
			nameLabel.AddLayoutAttributes (finalNameLabelLayoutAttributes, 1f);

			AddSubview (nameLabel);


			// Add and configure profile image
			var profileImageView = new BLKFlexibleHeightBarSubviewUIImageView ();
			profileImageView.Image = UIImage.FromFile (@"ProfilePicture.png");
			profileImageView.ContentMode = UIViewContentMode.ScaleAspectFill;
			profileImageView.ClipsToBounds = true;
			profileImageView.Layer.CornerRadius = 35f;
			profileImageView.Layer.BorderWidth = 2f;
			profileImageView.Layer.BorderColor = UIColor.White.CGColor;

			var initialProfileImageViewLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes ();
			initialProfileImageViewLayoutAttributes.Size = new CGSize (70f, 70f);
			initialProfileImageViewLayoutAttributes.Center = new CGPoint (Frame.Size.Width * .5f, _maximumBarHeight - 110f);
			profileImageView.AddLayoutAttributes (initialProfileImageViewLayoutAttributes, 0f);

			var midwayProfileImageViewLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes (initialProfileImageViewLayoutAttributes);
			midwayProfileImageViewLayoutAttributes.Center = new CGPoint (Frame.Size.Width * .5f, (_maximumBarHeight - _minimumBarHeight) * .8f + _minimumBarHeight - 110f);
			profileImageView.AddLayoutAttributes (midwayProfileImageViewLayoutAttributes, .2f);

			var finalProfileImageViewLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes (midwayProfileImageViewLayoutAttributes);
			finalProfileImageViewLayoutAttributes.Center = new CGPoint (Frame.Size.Width * .5f, (_maximumBarHeight - _minimumBarHeight) * .64f + _minimumBarHeight - 110f);
			finalProfileImageViewLayoutAttributes.Transform = CGAffineTransform.MakeScale (.5f, .5f);
			finalProfileImageViewLayoutAttributes.Alpha = 0f;
			profileImageView.AddLayoutAttributes (finalProfileImageViewLayoutAttributes, .5f);

			AddSubview (profileImageView);
		}
	}
	
}
