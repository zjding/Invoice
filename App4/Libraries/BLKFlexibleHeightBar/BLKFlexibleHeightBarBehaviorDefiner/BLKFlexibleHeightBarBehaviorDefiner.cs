using System;
using System.Collections.Generic;
using System.Diagnostics;
using CoreGraphics;
using UIKit;

namespace BLKFlexibleHeightBarDemo
{
	public class BLKFlexibleHeightBarBehaviorDefiner : UIScrollViewDelegate, IUITableViewDelegate
	{
		protected BLKFlexibleHeightBar _flexibleHeightBar;

		public BLKFlexibleHeightBar FlexibleHeightBar
		{
			get
			{
				return _flexibleHeightBar;
			}
			set
			{
				if(_flexibleHeightBar != value)
				{
					_flexibleHeightBar = value;
				}
			}
		}

		protected bool _snappingEnabled;

		public bool IsSnappingEnabled
		{
			get
			{
				return _snappingEnabled;
			}
			set
			{
				_snappingEnabled = value;
			}
		}

		protected bool _currentlySnapping;

		public bool IsCurrentlySnapping
		{
			get
			{
				return _currentlySnapping;
			}
			private set
			{
				_currentlySnapping = value;
			}
		}

		protected bool _elasticMaximumHeightAtTop;

		public bool IsElasticMaximumHeightAtTop
		{
			get
			{
				return _elasticMaximumHeightAtTop;
			}
			set
			{
				_elasticMaximumHeightAtTop = value;
			}
		}

		Dictionary<Range, float> _snappingPositionsForProgressRanges;

		public BLKFlexibleHeightBarBehaviorDefiner()
		{
			_snappingPositionsForProgressRanges = new Dictionary<Range, float> ();
			_snappingEnabled = true;
			_currentlySnapping = false;
			_elasticMaximumHeightAtTop = false;
		}

		public void AddSnappingPositionProgress(float progress, float start, float end)
		{
			// Make sure start and end are between 0 and 1
			start = (Math.Max (Math.Min (start, 1.0f), 0.0f) * 100.0f);
			end = (Math.Max (Math.Min (end, 1.0f), 0.0f) * 100.0f);
			var progressPercentRange = new Range(start, end-start);
		
			foreach(var existingRange in _snappingPositionsForProgressRanges.Keys)
			{
				bool noRangeConflict = (progressPercentRange.Intersection(existingRange).Length == 0);
				Debug.Assert(noRangeConflict, @"progressPercentRange sent to -addSnappingProgressPosition:forProgressPercentRange: intersects a progressPercentRange for an existing progressPosition.");
			}

			_snappingPositionsForProgressRanges.Add (progressPercentRange, progress);
		}

		public void RemoveSnappingPositionProgressForProgressRangeStart(float start, float end)
		{
			// Make sure start and end are between 0 and 1
			start = (Math.Max (Math.Min (start, 1.0f), 0.0f) * 100.0f);
			end = (Math.Max (Math.Min (end, 1.0f), 0.0f) * 100.0f);
			var progressPercentRange = new Range(start, end-start);

			_snappingPositionsForProgressRanges.Remove (progressPercentRange);
		}

		public void SnapToProgress(float progress, UIScrollView scrollView)
		{
			var deltaProgress = progress - _flexibleHeightBar.Progress;
			var deltaYOffset = (_flexibleHeightBar.MaximumBarHeight-_flexibleHeightBar.MinimumBarHeight) * deltaProgress;
			scrollView.ContentOffset = new CGPoint(scrollView.ContentOffset.X, scrollView.ContentOffset.Y+deltaYOffset);

			_flexibleHeightBar.Progress = progress;
			_flexibleHeightBar.SetNeedsLayout ();
			_flexibleHeightBar.LayoutIfNeeded ();

			_currentlySnapping = false;
		}

		public void SnapWithScrollView(UIScrollView scrollView)
		{
			if(!_currentlySnapping && _snappingEnabled && _flexibleHeightBar.Progress >= 0.0)
			{
				_currentlySnapping = true;

				var snapPosition = float.MaxValue;
				foreach(var pair in _snappingPositionsForProgressRanges)
				{
					var existingRange = pair.Key;
					var progressPercent = _flexibleHeightBar.Progress * 100.0f;

					if(progressPercent >= existingRange.Location && (progressPercent <= (existingRange.Location+existingRange.Length)))
					{
						snapPosition = pair.Value;
					}

				}

				if(snapPosition != float.MaxValue)
				{
					UIView.Animate (0.15, delegate
					{

						SnapToProgress (snapPosition, scrollView);

					}, delegate
					{

						_currentlySnapping = false;

					});
				}
				else
				{
					_currentlySnapping= false;
				}
			}
		}
	}

}
