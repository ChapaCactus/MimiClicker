using System;

using MMCL.VO;
using MMCL.Enums;

using Google2u;

namespace MMCL.DTO
{
	[Serializable]
	public class ItemDTO
	{
		private ItemVO m_vo;

		private const string SPRITE_PATH_HEADER = "";

		public int MasterID { get { return m_vo.MasterID; } }
		public bool IsUnique { get { return m_vo.IsUnique; } }
		public string Name { get { return m_vo.Name; } }
		public Rarity Rarity { get { return m_vo.Rarity; } }
		public ItemCategory Category { get { return m_vo.Category; } }
		public int MaxQuantity { get { return m_vo.MaxQuantity; } }
		public int Quantity { get { return m_vo.Quantity; } }
		public string Explain { get; private set; }

		public string SpriteName { get; private set; }
		// 所持数上限か
		public bool IsFull { get { return (Quantity == MaxQuantity); } }

		public string SpriteFilePath { get { return (SPRITE_PATH_HEADER + SpriteName); } }

		public void SetVO(ItemVO vo)
		{
			m_vo = vo;

			DataManager.I.GetItemDataInMaster(ItemMaster.rowIds.ID_001, (row) =>
			{
				Explain = row._Explain;
				SpriteName = row._SpriteName;
			});
		}

		public void Increment()
		{
			m_vo.Quantity++;
		}
	}
}
