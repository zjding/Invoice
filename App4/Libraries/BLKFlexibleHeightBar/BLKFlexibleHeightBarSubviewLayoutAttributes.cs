using System.Diagnostics;
using CoreAnimation;
using CoreGraphics;

namespace BLKFlexibleHeightBarDemo
{
	public class BLKFlexibleHeightBarSubviewLayoutAttributes
	{
		CGRect _frame;

		public CGRect Frame
		{
			get
			{
				return _frame;
			}
			set
			{
				SetFrame (value);
			}
		}

		CGRect _bounds;

		public CGRect Bounds
		{
			get
			{
				return _bounds;
			}
			set
			{
				SetBounds (value);
			}
		}

		CGPoint _center;

		public CGPoint Center
		{
			get
			{
				return _center;
			}
			set
			{
				SetCenter (value);
			}
		}

		CGSize _size;

		public CGSize Size
		{
			get
			{
				return _size;
			}
			set
			{
				SetSize (value);
			}
		}

		CATransform3D _transform3D;

		public CATransform3D Transform3D
		{
			get
			{
				return _transform3D;
			}
			set
			{
				SetTransform3D (value);
			}
		}

		CGAffineTransform _transform;

		public CGAffineTransform Transform
		{
			get
			{
				return _transform;
			}
			set
			{
				SetTransform (value);
			}
		}


		public float Alpha
		{
			get;
			set;
		}

		public int ZIndex
		{
			get;
			set;
		}

		public bool Hidden
		{
			get;
			set;
		}

		public BLKFlexibleHeightBarSubviewLayoutAttributes ()
		{
			_frame = CGRect.Empty;
			_bounds = CGRect.Empty;
			_center = CGPoint.Empty;
			_size = CGSize.Empty;
			_transform3D = CATransform3D.Identity;
			_transform = CGAffineTransform.MakeIdentity ();
			Alpha = 1f;
			ZIndex = 0;
			Hidden = false;
		}

		public BLKFlexibleHeightBarSubviewLayoutAttributes (BLKFlexibleHeightBarSubviewLayoutAttributes layoutAttributes)
		{
			_frame = layoutAttributes._frame;
			_bounds = layoutAttributes._bounds;
			_center = layoutAttributes._center;
			_size = layoutAttributes._size;
			_transform3D = layoutAttributes._transform3D;
			_transform = layoutAttributes._transform;
			Alpha = layoutAttributes.Alpha;
			ZIndex = layoutAttributes.ZIndex;
			Hidden = layoutAttributes.Hidden;
		}

		bool TransformsAreIdentity ()
		{
			return _transform.IsIdentity && _transform3D.IsIdentity;
		}

		void SetFrame (CGRect frame)
		{
			if (TransformsAreIdentity ())
			{
				_frame = frame;
			}

			_center = new CGPoint (frame.GetMidX (), frame.GetMidY ());
			_size = new CGSize (_frame.Width, _frame.Height);
			_bounds = new CGRect (_bounds.GetMinX (), _bounds.GetMinY (), _size.Width, _size.Height);
		}

		void SetBounds (CGRect bounds)
		{
			Debug.Assert (bounds.X == 0.0 && bounds.Y == 0.0, @"Bounds must be set with a (0,0) origin");
			_bounds = bounds;
			_size = new CGSize (_bounds.Width, _bounds.Height);
		}

		void SetCenter (CGPoint center)
		{
			_center = center;
			if (TransformsAreIdentity ())
			{
				_frame = new CGRect (center.X - _bounds.GetMidX (), center.Y - _bounds.GetMidY (), _frame.Width, _frame.Height);
			}
		}

		void SetSize (CGSize size)
		{
			_size = size;
			if (TransformsAreIdentity ())
			{
				_frame = new CGRect (_frame.GetMinX (), _frame.GetMinY (), size.Width, size.Height);
			}
			_bounds = new CGRect (_bounds.GetMinX (), _bounds.GetMinY (), size.Width, size.Height);
		}

		void SetTransform3D (CATransform3D transform3D)
		{
			_transform3D = transform3D;
			_transform = new CGAffineTransform (transform3D.m11, transform3D.m12, transform3D.m21, transform3D.m22, transform3D.m41, transform3D.m42);
			if (!transform3D.IsIdentity)
			{
				_frame = CGRect.Empty;
			}
		}

		void SetTransform (CGAffineTransform transform)
		{
			_transform = transform;
			_transform3D = CATransform3D.MakeFromAffine (transform);
			if (CGAffineTransform.MakeIdentity () != transform)
			{
				_frame = CGRect.Empty;
			}
		}
	}

}
