using System;

using MMCL.Enums;

namespace MMCL.VO
{
	[Serializable]
	public class ItemVO
	{
		// ユニークアイテムか？
		public int MasterID { get; set; }
		public bool IsUnique { get; set; }
		public string Name { get; set; }
		public Rarity Rarity { get; set; }
		public ItemCategory Category { get; set; }
		public int MaxQuantity { get; set; }
		public int Quantity { get; set; }
		public string Description { get; set; }

		public void Create(Action<ItemVO> callback)
		{
			var vo = new ItemVO();
			vo.MasterID = 0;
			vo.IsUnique = false;
			vo.Name = "";
			vo.Rarity = Rarity.None;
			vo.Category = ItemCategory.None;
			vo.MaxQuantity = 0;
			vo.Quantity = 0;
			vo.Description = "";

			callback.Call(vo);
		}
	}
}
