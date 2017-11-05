using System;

namespace MMCL.VO
{
	[Serializable]
	/// <summary>
	/// 所持品データクラス
	/// </summary>
	public class InventoryVO
	{
		public int MaxSize { get; set; }

		public ItemVO[] ItemSlots { get; set; }
	}
}
