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
			_maximumBarHeight = 80.0f;
			_minimumBarHeight = 30.0f;
			BackgroundColor = UIColor.FromRGBA (.17f, .63f, .11f, 1.0f);

			// Add and configure name label
			var nameLabel = new BLKFlexibleHeightBarSubviewUILabel ();
			//nameLabel.Font = UIFont.SystemFontOfSize (30f);
			nameLabel.Font = UIFont.FromName("Avenir Next", 24f);
			nameLabel.TextColor = UIColor.White;
			nameLabel.Text = "Invoice #2";

			var initialNameLabelLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes();
			initialNameLabelLayoutAttributes.Size = nameLabel.SizeThatFits (CGSize.Empty);
			//initialNameLabelLayoutAttributes.Center = new CGPoint(Frame.Size.Width * .5f, _maximumBarHeight - 50f);
			initialNameLabelLayoutAttributes.Center = new CGPoint (60f, _maximumBarHeight - 15f);
			nameLabel.AddLayoutAttributes (initialNameLabelLayoutAttributes, 0f);

			//var midwayNameLabelLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes (initialNameLabelLayoutAttributes);
			////midwayNameLabelLayoutAttributes.Center = new CGPoint (Frame.Size.Width * .5f, (_maximumBarHeight - _minimumBarHeight) * .4f + _minimumBarHeight - 50f);
			//midwayNameLabelLayoutAttributes.Center = new CGPoint((Frame.Size.Width * .5f - 45f) * .4f, (_maximumBarHeight - _minimumBarHeight) * .4f);
			//nameLabel.AddLayoutAttributes (midwayNameLabelLayoutAttributes, .6f);

			var finalNameLabelLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes (initialNameLabelLayoutAttributes);
			//finalNameLabelLayoutAttributes.Center = new CGPoint (Frame.Size.Width * .5f, _minimumBarHeight - 25f);
			finalNameLabelLayoutAttributes.Center = new CGPoint(Frame.Size.Width * .5f, _minimumBarHeight - 15f);
			finalNameLabelLayoutAttributes.Transform = CGAffineTransform.MakeScale(.7f, .7f);
			nameLabel.AddLayoutAttributes (finalNameLabelLayoutAttributes, 1f);

			AddSubview (nameLabel);


			//// Add and configure profile image
			//var profileImageView = new BLKFlexibleHeightBarSubviewUIImageView ();
			//profileImageView.Image = UIImage.FromFile (@"ProfilePicture.png");
			//profileImageView.ContentMode = UIViewContentMode.ScaleAspectFill;
			//profileImageView.ClipsToBounds = true;
			//profileImageView.Layer.CornerRadius = 35f;
			//profileImageView.Layer.BorderWidth = 2f;
			//profileImageView.Layer.BorderColor = UIColor.White.CGColor;

			//var initialProfileImageViewLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes ();
			//initialProfileImageViewLayoutAttributes.Size = new CGSize (70f, 70f);
			//initialProfileImageViewLayoutAttributes.Center = new CGPoint (Frame.Size.Width * .5f, _maximumBarHeight - 110f);
			//profileImageView.AddLayoutAttributes (initialProfileImageViewLayoutAttributes, 0f);

			//var midwayProfileImageViewLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes (initialProfileImageViewLayoutAttributes);
			//midwayProfileImageViewLayoutAttributes.Center = new CGPoint (Frame.Size.Width * .5f, (_maximumBarHeight - _minimumBarHeight) * .8f + _minimumBarHeight - 110f);
			//profileImageView.AddLayoutAttributes (midwayProfileImageViewLayoutAttributes, .2f);

			//var finalProfileImageViewLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes (midwayProfileImageViewLayoutAttributes);
			//finalProfileImageViewLayoutAttributes.Center = new CGPoint (Frame.Size.Width * .5f, (_maximumBarHeight - _minimumBarHeight) * .64f + _minimumBarHeight - 110f);
			//finalProfileImageViewLayoutAttributes.Transform = CGAffineTransform.MakeScale (.5f, .5f);
			//finalProfileImageViewLayoutAttributes.Alpha = 0f;
			//profileImageView.AddLayoutAttributes (finalProfileImageViewLayoutAttributes, .5f);

			//AddSubview (profileImageView);

		}
	}
	
}
