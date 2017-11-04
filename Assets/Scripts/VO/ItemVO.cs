using System;

using MMCL.Enums;

namespace MMCL.VO
{
	[Serializable]
	public class ItemVO
	{
		// ユニークアイテムか？
		public bool IsUnique { get; set; }
		public string Name { get; set; }
		public Rarity Rarity { get; set; }
		public ItemCategory Category { get; set; }
		public int Quantity { get; set; }
		public string Description { get; set; }

		public void Create(Action<ItemVO> callback)
		{
			var vo = new ItemVO();
			vo.IsUnique = false;
			vo.Name = "";
			vo.Rarity = Rarity.None;
			vo.Category = ItemCategory.None;
			vo.Quantity = 0;
			vo.Description = "";

			callback.Call(vo);
		}
	}
}
