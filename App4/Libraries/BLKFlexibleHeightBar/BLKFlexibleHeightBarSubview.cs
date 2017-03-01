using System;
using System.Collections.Generic;
using UIKit;

namespace BLKFlexibleHeightBarDemo
{
	public class BLKFlexibleHeightBarSubviewUIView : UIView, IBLKFlexibleHeightBarSubview
	{
		readonly List<float> ProgressValues = new List<float> ();
		readonly List<BLKFlexibleHeightBarSubviewLayoutAttributes> LayoutAttributesForProgressValues = new List<BLKFlexibleHeightBarSubviewLayoutAttributes> ();
		const float EPSILON = .001f;
		
		public void AddLayoutAttributes (BLKFlexibleHeightBarSubviewLayoutAttributes layoutAttributes, float progress)
		{
			progress = Math.Max (Math.Min (progress, 1.0f), 0.0f);

			for (int idx = 0; idx < ProgressValues.Count; idx++)
			{
				float existingDouble = ProgressValues [idx];

				if (Math.Abs (existingDouble - progress) < EPSILON)
				{
					LayoutAttributesForProgressValues [idx] = layoutAttributes;
					return;
				}
			}

			int insertionIndex = 0;
			foreach (var existingDouble in ProgressValues)
			{
				if (progress > existingDouble)
				{
					insertionIndex++;
				}
				else
				{
					break;
				}
			}

			ProgressValues.Insert (insertionIndex, progress);
			LayoutAttributesForProgressValues.Insert (insertionIndex, layoutAttributes);
		}

		public void RemoveLayoutAttributesForProgress (float progress)
		{
			int indexToRemove = ProgressValues.IndexOf (progress);

			if (indexToRemove != -1)
			{
				ProgressValues.RemoveAt (indexToRemove);
				LayoutAttributesForProgressValues.RemoveAt (indexToRemove);
			}
		}

		public int NumberOfLayoutAttributes
		{
			get
			{
				return LayoutAttributesForProgressValues.Count;
			}
		}

		public float ProgressAtIndex (int index)
		{
			return ProgressValues [index];
		}

		public BLKFlexibleHeightBarSubviewLayoutAttributes LayoutAttributesAtIndex (int index)
		{
			return LayoutAttributesForProgressValues [index];
		}
	}

	public class BLKFlexibleHeightBarSubviewUIImageView : UIImageView, IBLKFlexibleHeightBarSubview
	{
		readonly List<float> ProgressValues = new List<float> ();
		readonly List<BLKFlexibleHeightBarSubviewLayoutAttributes> LayoutAttributesForProgressValues = new List<BLKFlexibleHeightBarSubviewLayoutAttributes> ();
		const float EPSILON = .001f;
		
		public void AddLayoutAttributes (BLKFlexibleHeightBarSubviewLayoutAttributes layoutAttributes, float progress)
		{
			progress = Math.Max (Math.Min (progress, 1.0f), 0.0f);

			for (int idx = 0; idx < ProgressValues.Count; idx++)
			{
				float existingDouble = ProgressValues [idx];

				if (Math.Abs (existingDouble - progress) < EPSILON)
				{
					LayoutAttributesForProgressValues [idx] = layoutAttributes;
					return;
				}
			}

			int insertionIndex = 0;
			foreach (var existingDouble in ProgressValues)
			{
				if (progress > existingDouble)
				{
					insertionIndex++;
				}
				else
				{
					break;
				}
			}

			ProgressValues.Insert (insertionIndex, progress);
			LayoutAttributesForProgressValues.Insert (insertionIndex, layoutAttributes);
		}

		public void RemoveLayoutAttributesForProgress (float progress)
		{
			int indexToRemove = ProgressValues.IndexOf (progress);

			if (indexToRemove != -1)
			{
				ProgressValues.RemoveAt (indexToRemove);
				LayoutAttributesForProgressValues.RemoveAt (indexToRemove);
			}
		}

		public int NumberOfLayoutAttributes
		{
			get
			{
				return LayoutAttributesForProgressValues.Count;
			}
		}

		public float ProgressAtIndex (int index)
		{
			return ProgressValues [index];
		}

		public BLKFlexibleHeightBarSubviewLayoutAttributes LayoutAttributesAtIndex (int index)
		{
			return LayoutAttributesForProgressValues [index];
		}
	}

	public class BLKFlexibleHeightBarSubviewUILabel : UILabel, IBLKFlexibleHeightBarSubview
	{
		readonly List<float> ProgressValues = new List<float> ();
		readonly List<BLKFlexibleHeightBarSubviewLayoutAttributes> LayoutAttributesForProgressValues = new List<BLKFlexibleHeightBarSubviewLayoutAttributes> ();
		const float EPSILON = .001f;
		
		public void AddLayoutAttributes (BLKFlexibleHeightBarSubviewLayoutAttributes layoutAttributes, float progress)
		{
			progress = Math.Max (Math.Min (progress, 1.0f), 0.0f);

			for (int idx = 0; idx < ProgressValues.Count; idx++)
			{
				float existingDouble = ProgressValues [idx];

				if (Math.Abs (existingDouble - progress) < EPSILON)
				{
					LayoutAttributesForProgressValues [idx] = layoutAttributes;
					return;
				}
			}

			int insertionIndex = 0;
			foreach (var existingDouble in ProgressValues)
			{
				if (progress > existingDouble)
				{
					insertionIndex++;
				}
				else
				{
					break;
				}
			}

			ProgressValues.Insert (insertionIndex, progress);
			LayoutAttributesForProgressValues.Insert (insertionIndex, layoutAttributes);
		}

		public void RemoveLayoutAttributesForProgress (float progress)
		{
			int indexToRemove = ProgressValues.IndexOf (progress);

			if (indexToRemove != -1)
			{
				ProgressValues.RemoveAt (indexToRemove);
				LayoutAttributesForProgressValues.RemoveAt (indexToRemove);
			}
		}

		public int NumberOfLayoutAttributes
		{
			get
			{
				return LayoutAttributesForProgressValues.Count;
			}
		}

		public float ProgressAtIndex (int index)
		{
			return ProgressValues [index];
		}

		public BLKFlexibleHeightBarSubviewLayoutAttributes LayoutAttributesAtIndex (int index)
		{
			return LayoutAttributesForProgressValues [index];
		}
	}

	public class BLKFlexibleHeightBarSubviewUIButton : UIButton, IBLKFlexibleHeightBarSubview
	{
		readonly List<float> ProgressValues = new List<float> ();
		readonly List<BLKFlexibleHeightBarSubviewLayoutAttributes> LayoutAttributesForProgressValues = new List<BLKFlexibleHeightBarSubviewLayoutAttributes> ();
		const float EPSILON = .001f;
		
		public void AddLayoutAttributes (BLKFlexibleHeightBarSubviewLayoutAttributes layoutAttributes, float progress)
		{
			progress = Math.Max (Math.Min (progress, 1.0f), 0.0f);

			for (int idx = 0; idx < ProgressValues.Count; idx++)
			{
				float existingDouble = ProgressValues [idx];

				if (Math.Abs (existingDouble - progress) < EPSILON)
				{
					LayoutAttributesForProgressValues [idx] = layoutAttributes;
					return;
				}
			}

			int insertionIndex = 0;
			foreach (var existingDouble in ProgressValues)
			{
				if (progress > existingDouble)
				{
					insertionIndex++;
				}
				else
				{
					break;
				}
			}

			ProgressValues.Insert (insertionIndex, progress);
			LayoutAttributesForProgressValues.Insert (insertionIndex, layoutAttributes);
		}

		public void RemoveLayoutAttributesForProgress (float progress)
		{
			int indexToRemove = ProgressValues.IndexOf (progress);

			if (indexToRemove != -1)
			{
				ProgressValues.RemoveAt (indexToRemove);
				LayoutAttributesForProgressValues.RemoveAt (indexToRemove);
			}
		}

		public int NumberOfLayoutAttributes
		{
			get
			{
				return LayoutAttributesForProgressValues.Count;
			}
		}

		public float ProgressAtIndex (int index)
		{
			return ProgressValues [index];
		}

		public BLKFlexibleHeightBarSubviewLayoutAttributes LayoutAttributesAtIndex (int index)
		{
			return LayoutAttributesForProgressValues [index];
		}
	}

	public class BLKFlexibleHeightBarSubviewUITextField : UITextField, IBLKFlexibleHeightBarSubview
	{
		readonly List<float> ProgressValues = new List<float> ();
		readonly List<BLKFlexibleHeightBarSubviewLayoutAttributes> LayoutAttributesForProgressValues = new List<BLKFlexibleHeightBarSubviewLayoutAttributes> ();
		const float EPSILON = .001f;
		
		public void AddLayoutAttributes (BLKFlexibleHeightBarSubviewLayoutAttributes layoutAttributes, float progress)
		{
			progress = Math.Max (Math.Min (progress, 1.0f), 0.0f);

			for (int idx = 0; idx < ProgressValues.Count; idx++)
			{
				float existingDouble = ProgressValues [idx];

				if (Math.Abs (existingDouble - progress) < EPSILON)
				{
					LayoutAttributesForProgressValues [idx] = layoutAttributes;
					return;
				}
			}

			int insertionIndex = 0;
			foreach (var existingDouble in ProgressValues)
			{
				if (progress > existingDouble)
				{
					insertionIndex++;
				}
				else
				{
					break;
				}
			}

			ProgressValues.Insert (insertionIndex, progress);
			LayoutAttributesForProgressValues.Insert (insertionIndex, layoutAttributes);
		}

		public void RemoveLayoutAttributesForProgress (float progress)
		{
			int indexToRemove = ProgressValues.IndexOf (progress);

			if (indexToRemove != -1)
			{
				ProgressValues.RemoveAt (indexToRemove);
				LayoutAttributesForProgressValues.RemoveAt (indexToRemove);
			}
		}

		public int NumberOfLayoutAttributes
		{
			get
			{
				return LayoutAttributesForProgressValues.Count;
			}
		}

		public float ProgressAtIndex (int index)
		{
			return ProgressValues [index];
		}

		public BLKFlexibleHeightBarSubviewLayoutAttributes LayoutAttributesAtIndex (int index)
		{
			return LayoutAttributesForProgressValues [index];
		}
	}

}