using System;
using Foundation;
using UIKit;
using ObjCRuntime;

namespace BLKFlexibleHeightBarDemo
{
	public class BLKDelegateSplitter : NSObject, IUITableViewDelegate
	{
		NSObject _firstDelegate;
		NSObject _secondDelegate;

		public BLKDelegateSplitter(NSObject firstDelegate, NSObject secondDelegate)
		{
			_firstDelegate = firstDelegate;
			_secondDelegate = secondDelegate;
		}

		NSObject ForwardingTargetForSelector(Selector sel)
		{
			if(_firstDelegate.RespondsToSelector (sel))
			{
				return _firstDelegate;
			}
			else if(_secondDelegate.RespondsToSelector (sel))
			{
				return _secondDelegate;
			}
			else
			{
				return null;
			}
		}

		public override NSObject PerformSelector (Selector sel)
		{
			if(_firstDelegate.RespondsToSelector (sel))
			{
				return _firstDelegate.PerformSelector (sel);
			}
			if(_secondDelegate.RespondsToSelector (sel))
			{
				return _secondDelegate.PerformSelector (sel);
			}
			throw new Exception ();
		}

		public override bool RespondsToSelector (Selector sel)
		{
			if(_firstDelegate.RespondsToSelector (sel) || _secondDelegate.RespondsToSelector (sel))
			{
				return true;
			}
			return false;
		}
	}

}
