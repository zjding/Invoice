using System;
using UIKit;
using CoreGraphics;

namespace BLKFlexibleHeightBarDemo
{
	public class FacebookStyleBarBehaviorDefiner : BLKFlexibleHeightBarBehaviorDefiner
	{
		float _thresholdFromTop;

		public float ThresholdFromTop
		{
			get
			{
				return _thresholdFromTop;
			}
			set
			{
				_thresholdFromTop = value;
			}
		}

		float _thresholdNegativeDirection;

		public float ThresholdNegativeDirection
		{
			get
			{
				return _thresholdNegativeDirection;
			}
			set
			{
				_thresholdNegativeDirection = value;
			}
		}

		float _thresholdPositiveDirection;

		public float ThresholdPositiveDirection
		{
			get
			{
				return _thresholdPositiveDirection;
			}
			set
			{
				_thresholdPositiveDirection = value;
			}
		}

		nfloat _previousYOffset;
		nfloat _previousProgress;

		public FacebookStyleBarBehaviorDefiner()
		{
			_previousYOffset = 0.0f;
			_previousProgress = 0.0f;

			_thresholdFromTop = 0.0f;
			_thresholdNegativeDirection = 0.0f;
			_thresholdPositiveDirection = 0.0f;

			_elasticMaximumHeightAtTop = false;
		}

		void SetThresholdFromTop(float thresholdFromTop)
		{
			_thresholdFromTop = Math.Max (thresholdFromTop, 0.0f);
		}

		void SetThresholdNegativeDirection(float thresholdNegativeDirection)
		{
			_thresholdNegativeDirection = Math.Max (thresholdNegativeDirection, 0.0f);
		}

		void SetThresholdPositiveDirection(float thresholdPositiveDirection)
		{
			_thresholdPositiveDirection = Math.Max (thresholdPositiveDirection, 0.0f);
		}

		void ApplyFromTopProgressTrackingThreshold()
		{
			_previousYOffset += _thresholdFromTop;
		}

		void ApplyNegativeDirectionProgressTrackingThreshold()
		{
			if(_flexibleHeightBar.Progress == 1.0)
			{
				_previousYOffset -= _thresholdNegativeDirection;
			}
		}

		void ApplyPositiveDirectionProgressTrackingThreshold()
		{
			if(_flexibleHeightBar.Progress == 0.0)
			{
				_previousYOffset += _thresholdPositiveDirection;
			}
		}

		public override void DraggingStarted (UIScrollView scrollView)
		{
			var scrollViewViewportHeight = (scrollView.Bounds.GetMaxY ()) - (scrollView.Bounds.GetMinY ());

			if((scrollView.ContentOffset.Y+scrollView.ContentInset.Top) >= 0.0 && scrollView.ContentOffset.Y <= (scrollView.ContentSize.Height-scrollViewViewportHeight))
			{
				_previousYOffset = scrollView.ContentOffset.Y;
				_previousProgress = _flexibleHeightBar.Progress;

				// Apply top threshold
				if((scrollView.ContentOffset.Y+scrollView.ContentInset.Top) == 0.0)
				{
					ApplyFromTopProgressTrackingThreshold();
				}
				else
				{
					// Edge case (not true) - user is scrolling to the top but there isn't enough runway left to pass the threshold
					if((scrollView.ContentOffset.Y+scrollView.ContentInset.Top) > (_thresholdNegativeDirection+(_flexibleHeightBar.MaximumBarHeight-_flexibleHeightBar.MinimumBarHeight)))
					{
						ApplyNegativeDirectionProgressTrackingThreshold();
					}

					// Edge case (not true) - user is scrolling to the bottom but there isn't enough runway left to pass the threshold
					if(scrollView.ContentOffset.Y < (scrollView.ContentSize.Height-scrollViewViewportHeight-_thresholdPositiveDirection))
					{
						ApplyPositiveDirectionProgressTrackingThreshold();
					}
				}
			}
			// Edge case - user starts to scroll while the scroll view is stretched above the top
			else if((scrollView.ContentOffset.Y+scrollView.ContentInset.Top) < 0.0f)
			{
				_previousYOffset = -scrollView.ContentInset.Top;
				_previousProgress = 0.0f;

				if(_thresholdFromTop != 0.0f)
				{
					ApplyFromTopProgressTrackingThreshold();
				}
				else
				{
					ApplyNegativeDirectionProgressTrackingThreshold();
					ApplyPositiveDirectionProgressTrackingThreshold();
				}
			}
			// Edge case - user starts to scroll while the scroll view is stretched below the bottom
			else if(scrollView.ContentOffset.Y > (scrollView.ContentSize.Height-scrollViewViewportHeight))
			{
				_previousYOffset = scrollView.ContentSize.Height - scrollViewViewportHeight;
				_previousProgress = 1.0f;

				ApplyNegativeDirectionProgressTrackingThreshold();
				ApplyPositiveDirectionProgressTrackingThreshold();
			}
		}

		public override void Scrolled (UIScrollView scrollView)
		{
			if(!_currentlySnapping)
			{
				var deltaYOffset = scrollView.ContentOffset.Y - _previousYOffset;
				var deltaProgress = deltaYOffset / (_flexibleHeightBar.MaximumBarHeight-_flexibleHeightBar.MinimumBarHeight);

				_flexibleHeightBar.Progress = _previousProgress + deltaProgress;

				_flexibleHeightBar.SetNeedsLayout();
			}
		}

	}

}
