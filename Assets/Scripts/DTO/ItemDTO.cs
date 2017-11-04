using System;

using MMCL.VO;
using MMCL.Enums;

namespace MMCL.DTO
{
	[Serializable]
	public class ItemDTO
	{
		private ItemVO m_vo;

		public int MasterID { get { return m_vo.MasterID; } }
		public bool IsUnique { get { return m_vo.IsUnique; } }
		public string Name { get { return m_vo.Name; } }
		public Rarity Rarity { get { return m_vo.Rarity; } }
		public ItemCategory Category { get { return m_vo.Category; } }
		public int MaxQuantity { get { return m_vo.MaxQuantity; } }
		public int Quantity { get { return m_vo.Quantity; } }
		public string Description { get { return m_vo.Description; } }
		// 所持数上限か
		public bool IsFull { get { return (Quantity == MaxQuantity); } }

		public void SetVO(ItemVO vo)
		{
			m_vo = vo;
		}

		public void Increment()
		{
			m_vo.Quantity++;
		}
	}
}
