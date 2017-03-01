using System;
using System.Linq;
using UIKit;
using CoreGraphics;
using CoreAnimation;

namespace BLKFlexibleHeightBarDemo
{
	public class BLKFlexibleHeightBar : UIView
	{
		protected nfloat _progress;
		protected nfloat _maximumBarHeight;
		protected nfloat _minimumBarHeight;
		protected BLKFlexibleHeightBarBehaviorDefiner _behaviorDefiner;

		public BLKFlexibleHeightBar () : base ()
		{
			CommonInit ();
		}

		public BLKFlexibleHeightBar (CGRect frame) : base (frame)
		{
			CommonInit ();
		}

		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();
			CommonInit ();
			_maximumBarHeight = Bounds.GetMaxY ();
		}

		void CommonInit ()
		{
			_progress = 0.0f;
			_maximumBarHeight = 44.0f;
			_minimumBarHeight = 20.0f;
		}

		public nfloat Progress
		{
			get
			{
				return _progress;
			}
			set
			{
				SetProgress (value);
			}
		}

		public BLKFlexibleHeightBarBehaviorDefiner BehaviorDefiner
		{
			get
			{
				return _behaviorDefiner;
			}
			set
			{
				_behaviorDefiner = value;
				_behaviorDefiner.FlexibleHeightBar = this;
			}
		}

		public nfloat MaximumBarHeight
		{
			get
			{
				return _maximumBarHeight;
			}
			set
			{
				_maximumBarHeight = (nfloat)Math.Max (value, 0.0f);
			}
		}

		public nfloat MinimumBarHeight
		{
			get
			{
				return _minimumBarHeight;
			}
			set
			{
				_minimumBarHeight = (nfloat)Math.Max (value, 0.0f);
				;
			}
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			// Update height
			var barFrame = Frame;
			var newHeight = InterpolateFromValue (_maximumBarHeight, _minimumBarHeight, _progress);
			Frame = new CGRect (barFrame.X, barFrame.Y, barFrame.Width, newHeight);

			if (_behaviorDefiner != null && _behaviorDefiner.IsElasticMaximumHeightAtTop)
			{
				_progress = (nfloat)Math.Max (_progress, 0.0f);
			}

			// Update subviews using the appropriate layout attributes for the current progress
			foreach (var subview in Subviews.Cast<IBLKFlexibleHeightBarSubview> ())
			{
				for (int i = 0; i < subview.NumberOfLayoutAttributes; i++)
				{
					var floorProgressPosition = subview.ProgressAtIndex (i);

					if (i + 1 < subview.NumberOfLayoutAttributes)
					{
						var ceilingProgressPosition = subview.ProgressAtIndex (i + 1);

						if (_progress >= floorProgressPosition && _progress < ceilingProgressPosition)
						{
							var floorLayoutAttributes = subview.LayoutAttributesAtIndex (i);
							var ceilingLayoutAttributes = subview.LayoutAttributesAtIndex (i + 1);

							ApplyAttributes (floorLayoutAttributes, ceilingLayoutAttributes, subview as UIView, floorProgressPosition, ceilingProgressPosition);
						}
					}
					else
					{
						if (_progress >= floorProgressPosition)
						{
							var floorLayoutAttributes = subview.LayoutAttributesAtIndex (i);

							ApplyAttributes (floorLayoutAttributes, floorLayoutAttributes, subview as UIView, floorProgressPosition, 1.0f);
						}
					}
				}
			}

		}

		void ApplyAttributes (BLKFlexibleHeightBarSubviewLayoutAttributes floorLayoutAttributes, BLKFlexibleHeightBarSubviewLayoutAttributes ceilingLayoutAttributes, UIView subview, nfloat floorProgress, nfloat ceilingProgress)
		{
			var numerator = _progress - floorProgress;
			nfloat denominator;
			if (ceilingProgress == floorProgress)
			{
				denominator = ceilingProgress;
			}
			else
			{
				denominator = ceilingProgress - floorProgress;
			}
			var relativeProgress = numerator / denominator;

			// Interpolate CA3DTransform
			CATransform3D transform3D;
			transform3D.m11 = InterpolateFromValue (floorLayoutAttributes.Transform3D.m11, ceilingLayoutAttributes.Transform3D.m11, relativeProgress);
			transform3D.m12 = InterpolateFromValue (floorLayoutAttributes.Transform3D.m12, ceilingLayoutAttributes.Transform3D.m12, relativeProgress);
			transform3D.m13 = InterpolateFromValue (floorLayoutAttributes.Transform3D.m13, ceilingLayoutAttributes.Transform3D.m13, relativeProgress);
			transform3D.m14 = InterpolateFromValue (floorLayoutAttributes.Transform3D.m14, ceilingLayoutAttributes.Transform3D.m14, relativeProgress);
			transform3D.m21 = InterpolateFromValue (floorLayoutAttributes.Transform3D.m21, ceilingLayoutAttributes.Transform3D.m21, relativeProgress);
			transform3D.m22 = InterpolateFromValue (floorLayoutAttributes.Transform3D.m22, ceilingLayoutAttributes.Transform3D.m22, relativeProgress);
			transform3D.m23 = InterpolateFromValue (floorLayoutAttributes.Transform3D.m23, ceilingLayoutAttributes.Transform3D.m23, relativeProgress);
			transform3D.m24 = InterpolateFromValue (floorLayoutAttributes.Transform3D.m24, ceilingLayoutAttributes.Transform3D.m24, relativeProgress);
			transform3D.m31 = InterpolateFromValue (floorLayoutAttributes.Transform3D.m31, ceilingLayoutAttributes.Transform3D.m31, relativeProgress);
			transform3D.m32 = InterpolateFromValue (floorLayoutAttributes.Transform3D.m32, ceilingLayoutAttributes.Transform3D.m32, relativeProgress);
			transform3D.m33 = InterpolateFromValue (floorLayoutAttributes.Transform3D.m33, ceilingLayoutAttributes.Transform3D.m33, relativeProgress);
			transform3D.m34 = InterpolateFromValue (floorLayoutAttributes.Transform3D.m34, ceilingLayoutAttributes.Transform3D.m34, relativeProgress);
			transform3D.m41 = InterpolateFromValue (floorLayoutAttributes.Transform3D.m41, ceilingLayoutAttributes.Transform3D.m41, relativeProgress);
			transform3D.m42 = InterpolateFromValue (floorLayoutAttributes.Transform3D.m42, ceilingLayoutAttributes.Transform3D.m42, relativeProgress);
			transform3D.m43 = InterpolateFromValue (floorLayoutAttributes.Transform3D.m43, ceilingLayoutAttributes.Transform3D.m43, relativeProgress);
			transform3D.m44 = InterpolateFromValue (floorLayoutAttributes.Transform3D.m44, ceilingLayoutAttributes.Transform3D.m44, relativeProgress);

			// Interpolate frame
			CGRect frame;
			if (floorLayoutAttributes.Frame != (null) && ceilingLayoutAttributes.Frame == (null))
			{
				frame = floorLayoutAttributes.Frame;
			}
			else if (floorLayoutAttributes.Frame == null && ceilingLayoutAttributes.Frame == null)
			{
				frame = subview.Frame;
			}
			else
			{
				var x = InterpolateFromValue (floorLayoutAttributes.Frame.GetMinX (), ceilingLayoutAttributes.Frame.GetMinX (), relativeProgress);
				var y = InterpolateFromValue (floorLayoutAttributes.Frame.GetMinY (), ceilingLayoutAttributes.Frame.GetMinY (), relativeProgress);
				var width = InterpolateFromValue (floorLayoutAttributes.Frame.Width, ceilingLayoutAttributes.Frame.Width, relativeProgress);
				var height = InterpolateFromValue (floorLayoutAttributes.Frame.Height, ceilingLayoutAttributes.Frame.Height, relativeProgress);
				frame = new CGRect (x, y, width, height);
			}

			// Interpolate center
			CGPoint center;
			{
				var x = InterpolateFromValue (floorLayoutAttributes.Center.X, ceilingLayoutAttributes.Center.X, relativeProgress);
				var y = InterpolateFromValue (floorLayoutAttributes.Center.Y, ceilingLayoutAttributes.Center.Y, relativeProgress);
				center = new CGPoint (x, y);
			}

			// Interpolate bounds
			CGRect bounds;
			{
				var x = InterpolateFromValue (floorLayoutAttributes.Bounds.GetMinX (), ceilingLayoutAttributes.Bounds.GetMinX (), relativeProgress);
				var y = InterpolateFromValue (floorLayoutAttributes.Bounds.GetMinY (), ceilingLayoutAttributes.Bounds.GetMinY (), relativeProgress);
				var width = InterpolateFromValue (floorLayoutAttributes.Bounds.Width, ceilingLayoutAttributes.Bounds.Width, relativeProgress);
				var height = InterpolateFromValue (floorLayoutAttributes.Bounds.Height, ceilingLayoutAttributes.Bounds.Height, relativeProgress);
				bounds = new CGRect (x, y, width, height);
			}

			// Interpolate alpha
			var alpha = InterpolateFromValue (floorLayoutAttributes.Alpha, ceilingLayoutAttributes.Alpha, relativeProgress);

			// Apply updated attributes
			subview.Layer.Transform = transform3D;
			if (transform3D.IsIdentity)
			{
				subview.Frame = frame;
			}
			subview.Center = center;
			subview.Bounds = bounds;
			subview.Alpha = alpha;
			subview.Layer.ZPosition = floorLayoutAttributes.ZIndex;
			subview.Hidden = floorLayoutAttributes.Hidden;
		}

		nfloat InterpolateFromValue (nfloat fromValue, nfloat toValue, nfloat progress)
		{
			return fromValue - ((fromValue - toValue) * progress);
		}

		void SetProgress (nfloat progress)
		{
			_progress = (nfloat)Math.Min (progress, 1.0f);
			if ((_behaviorDefiner != null && !_behaviorDefiner.IsElasticMaximumHeightAtTop) || _behaviorDefiner == null)
			{
				_progress = (nfloat)Math.Max (_progress, 0.0f);
			}
		}
		
	}

}
