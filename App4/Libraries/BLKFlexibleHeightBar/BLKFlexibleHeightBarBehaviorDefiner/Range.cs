using System;

namespace BLKFlexibleHeightBarDemo
{
	public class Range
	{
		float _location;

		public float Location
		{
			get
			{
				return _location;
			}
			set
			{
				_location = value;
			}
		}

		public float Length { get; set; }

		public float Start
		{
			get
			{
				return _location;
			}
			set
			{
				_location = value;
			}
		}

		public float End
		{
			get
			{
				return _location + Length;
			}
			set
			{
				Length = value - _location;
			}
		}

		public Range(float start, float length)
		{
			_location = start;
			Length = length;
		}

		public Range Intersection(Range other)
		{
			if(End>other.Start && other.End>Start)
			{
				var start = Math.Max (Start, other.Start);
				var end = Math.Min (End, other.End);
				return new Range (start, end - start);
			}
			return new Range(float.NaN, 0);
		}
	}

}
