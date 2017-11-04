using System;

namespace MMCL.VO
{
	[Serializable]
	public class ItemVO
	{
		// ユニークアイテムか？
		public bool IsUnique { get; set; }
		public string Name { get; set; }
		public int Rarity { get; set; }
		public int Quantity { get; set; }
		public string Description { get; set; }
	}
}
