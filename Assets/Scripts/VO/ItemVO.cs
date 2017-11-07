using System;

using MMCL.Enums;

using Google2u;

namespace MMCL.VO
{
	[Serializable]
	public struct ItemVO
	{
		// ユニークアイテムか？
		public ItemMaster.rowIds RowId { get; set; }
		public bool IsUnique { get; set; }
		public string Name { get; set; }
		public Rarity Rarity { get; set; }
		public ItemCategory Category { get; set; }
		public int MaxQuantity { get; set; }
		public int Quantity { get; set; }
		public string Explain { get; set; }
		public string SpriteName { get; set; }

		public static ItemVO Create(ItemMaster.rowIds identifer, ItemMasterRow master)
		{
			var vo = new ItemVO();
			vo.RowId = identifer;
			vo.IsUnique = false;
			vo.Name = master._Name;
			vo.Rarity = Rarity.None;
			vo.Category = ItemCategory.None;
			vo.MaxQuantity = 0;
			vo.Quantity = 0;
			vo.Explain = master._Explain;
			vo.SpriteName = master._SpriteName;

			return vo;
		}
	}
}
