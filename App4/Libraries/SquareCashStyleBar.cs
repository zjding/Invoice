using UIKit;
using CoreGraphics;

namespace BLKFlexibleHeightBarDemo
{
	public class SquareCashStyleBar : BLKFlexibleHeightBar
	{
		public string invoiceName;
		public string invoiceIssueDate;
		public string invoiceDueTerm;

		public BLKFlexibleHeightBarSubviewUILabel invoiceLabel;
		public BLKFlexibleHeightBarSubviewUILabel numberLabel;
		public BLKFlexibleHeightBarSubviewUILabel dateLabel;
		public BLKFlexibleHeightBarSubviewUILabel dueLabel;

		public SquareCashStyleBar(CGRect frame) : base(frame)
		{
			//ConfigureBar();
		}

		public SquareCashStyleBar()
		{
			ConfigureBar();
		}

		public void ConfigureBar()
		{
			// Configure bar appearence
			_maximumBarHeight = 80.0f;
			_minimumBarHeight = 30.0f;
			BackgroundColor = UIColor.FromRGBA(.17f, .63f, .11f, 1.0f);

			///////////////////////

			// Add and configure name label
			invoiceLabel = new BLKFlexibleHeightBarSubviewUILabel();
			//nameLabel.Font = UIFont.SystemFontOfSize (30f);
			invoiceLabel.Font = UIFont.FromName("Arial", 36f);
			invoiceLabel.TextColor = UIColor.White;
			invoiceLabel.Text = "Invoice";

			var initialInvoiceLabelLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes();
			initialInvoiceLabelLayoutAttributes.Size = invoiceLabel.SizeThatFits(CGSize.Empty);
			//initialNameLabelLayoutAttributes.Center = new CGPoint(Frame.Size.Width * .5f, _maximumBarHeight - 50f);
			initialInvoiceLabelLayoutAttributes.Center = new CGPoint(Frame.Size.Width - 60f, _maximumBarHeight - 35f);
			invoiceLabel.AddLayoutAttributes(initialInvoiceLabelLayoutAttributes, 0f);

			//var midwayNameLabelLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes (initialNameLabelLayoutAttributes);
			////midwayNameLabelLayoutAttributes.Center = new CGPoint (Frame.Size.Width * .5f, (_maximumBarHeight - _minimumBarHeight) * .4f + _minimumBarHeight - 50f);
			//midwayNameLabelLayoutAttributes.Center = new CGPoint((Frame.Size.Width * .5f - 45f) * .4f, (_maximumBarHeight - _minimumBarHeight) * .4f);
			//nameLabel.AddLayoutAttributes (midwayNameLabelLayoutAttributes, .6f);

			var finalInvoiceLabelLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes(initialInvoiceLabelLayoutAttributes);
			//finalNameLabelLayoutAttributes.Center = new CGPoint (Frame.Size.Width * .5f, _minimumBarHeight - 25f);
			finalInvoiceLabelLayoutAttributes.Center = new CGPoint(Frame.Size.Width * .5f - 10f, _minimumBarHeight - 15f);
			finalInvoiceLabelLayoutAttributes.Transform = CGAffineTransform.MakeScale(.5f, .5f);
			invoiceLabel.AddLayoutAttributes(finalInvoiceLabelLayoutAttributes, 1f);

			AddSubview(invoiceLabel);

			/////////////////

			// Add and configure name label
			numberLabel = new BLKFlexibleHeightBarSubviewUILabel();
			//nameLabel.Font = UIFont.SystemFontOfSize (30f);
			numberLabel.Font = UIFont.FromName("Arial", 18f);
			numberLabel.TextColor = UIColor.White;
			numberLabel.Text = invoiceName;

			var initialNumberLabelLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes();
			initialNumberLabelLayoutAttributes.Size = numberLabel.SizeThatFits(CGSize.Empty);
			//initialNameLabelLayoutAttributes.Center = new CGPoint(Frame.Size.Width * .5f, _maximumBarHeight - 50f);
			initialNumberLabelLayoutAttributes.Center = new CGPoint(Frame.Size.Width - 15f, _maximumBarHeight - 8f);
			numberLabel.AddLayoutAttributes(initialNumberLabelLayoutAttributes, 0f);

			//var midwayNameLabelLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes (initialNameLabelLayoutAttributes);
			////midwayNameLabelLayoutAttributes.Center = new CGPoint (Frame.Size.Width * .5f, (_maximumBarHeight - _minimumBarHeight) * .4f + _minimumBarHeight - 50f);
			//midwayNameLabelLayoutAttributes.Center = new CGPoint((Frame.Size.Width * .5f - 45f) * .4f, (_maximumBarHeight - _minimumBarHeight) * .4f);
			//nameLabel.AddLayoutAttributes (midwayNameLabelLayoutAttributes, .6f);

			var finalNumberLabelLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes(initialNumberLabelLayoutAttributes);
			//finalNameLabelLayoutAttributes.Center = new CGPoint (Frame.Size.Width * .5f, _minimumBarHeight - 25f);
			finalNumberLabelLayoutAttributes.Center = new CGPoint(Frame.Size.Width * .5f + 35f, _minimumBarHeight - 13.5f);
			finalNumberLabelLayoutAttributes.Transform = CGAffineTransform.MakeScale(.85f, .85f);
			numberLabel.AddLayoutAttributes(finalNumberLabelLayoutAttributes, 1f);

			AddSubview(numberLabel);

			/////////////////

			// Add and configure name label
			dateLabel = new BLKFlexibleHeightBarSubviewUILabel();
			//nameLabel.Font = UIFont.SystemFontOfSize (30f);
			dateLabel.Font = UIFont.FromName("Avenir Next", 16f);
			dateLabel.TextColor = UIColor.White;
			dateLabel.Text = invoiceIssueDate;

			var initialDateLabelLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes();
			initialDateLabelLayoutAttributes.Size = dateLabel.SizeThatFits(CGSize.Empty);
			//initialNameLabelLayoutAttributes.Center = new CGPoint(Frame.Size.Width * .5f, _maximumBarHeight - 50f);
			initialDateLabelLayoutAttributes.Center = new CGPoint(60f, _maximumBarHeight - 22f);
			dateLabel.AddLayoutAttributes(initialDateLabelLayoutAttributes, 0f);

			//var midwayNameLabelLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes (initialNameLabelLayoutAttributes);
			////midwayNameLabelLayoutAttributes.Center = new CGPoint (Frame.Size.Width * .5f, (_maximumBarHeight - _minimumBarHeight) * .4f + _minimumBarHeight - 50f);
			//midwayNameLabelLayoutAttributes.Center = new CGPoint((Frame.Size.Width * .5f - 45f) * .4f, (_maximumBarHeight - _minimumBarHeight) * .4f);
			//nameLabel.AddLayoutAttributes (midwayNameLabelLayoutAttributes, .6f);

			var finalDateLabelLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes(initialDateLabelLayoutAttributes);
			//finalNameLabelLayoutAttributes.Center = new CGPoint (Frame.Size.Width * .5f, _minimumBarHeight - 25f);
			finalDateLabelLayoutAttributes.Center = new CGPoint(60f, _minimumBarHeight - 15f);
			finalDateLabelLayoutAttributes.Alpha = 0f;
			dateLabel.AddLayoutAttributes(finalDateLabelLayoutAttributes, 1f);

			AddSubview(dateLabel);

			/////////////////

			dueLabel = new BLKFlexibleHeightBarSubviewUILabel();
			//nameLabel.Font = UIFont.SystemFontOfSize (30f);
			dueLabel.Font = UIFont.FromName("Avenir Next", 12f);
			dueLabel.TextColor = UIColor.White;
			dueLabel.Text = "Due: " + invoiceDueTerm;

			var initialDueLabelLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes();
			initialDueLabelLayoutAttributes.Size = dueLabel.SizeThatFits(CGSize.Empty);
			//initialNameLabelLayoutAttributes.Center = new CGPoint(Frame.Size.Width * .5f, _maximumBarHeight - 50f);
			initialDueLabelLayoutAttributes.Center = new CGPoint(40f, _maximumBarHeight - 7f);
			dueLabel.AddLayoutAttributes(initialDueLabelLayoutAttributes, 0f);

			//var midwayNameLabelLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes (initialNameLabelLayoutAttributes);
			////midwayNameLabelLayoutAttributes.Center = new CGPoint (Frame.Size.Width * .5f, (_maximumBarHeight - _minimumBarHeight) * .4f + _minimumBarHeight - 50f);
			//midwayNameLabelLayoutAttributes.Center = new CGPoint((Frame.Size.Width * .5f - 45f) * .4f, (_maximumBarHeight - _minimumBarHeight) * .4f);
			//nameLabel.AddLayoutAttributes (midwayNameLabelLayoutAttributes, .6f);

			var finalDueLabelLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes(initialDueLabelLayoutAttributes);
			//finalNameLabelLayoutAttributes.Center = new CGPoint (Frame.Size.Width * .5f, _minimumBarHeight - 25f);
			finalDueLabelLayoutAttributes.Center = new CGPoint(40f, _minimumBarHeight - 15f);;
			finalDueLabelLayoutAttributes.Alpha = 0f;
			dueLabel.AddLayoutAttributes(finalDueLabelLayoutAttributes, 1f);

			AddSubview(dueLabel);

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

