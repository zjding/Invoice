
namespace BLKFlexibleHeightBarDemo
{
	public interface IBLKFlexibleHeightBarSubview
	{
		void AddLayoutAttributes (BLKFlexibleHeightBarSubviewLayoutAttributes layoutAttributes, float progress);
		void RemoveLayoutAttributesForProgress (float progress);
		int NumberOfLayoutAttributes { get; }
		float ProgressAtIndex (int index);
		BLKFlexibleHeightBarSubviewLayoutAttributes LayoutAttributesAtIndex (int index);
	}

}
