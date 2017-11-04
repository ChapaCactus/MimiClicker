using System;

using MMCL.VO;
using MMCL.Enums;

namespace MMCL.DTO
{
	[Serializable]
	public class ItemDTO
	{
		private ItemVO m_vo;

		public bool IsUnique { get { return m_vo.IsUnique; } }
		public string Name { get { return m_vo.Name; } }
		public Rarity Rarity { get { return m_vo.Rarity; } }
		public ItemCategory Category { get { return m_vo.Category; } }
		public int Quantity { get { return m_vo.Quantity; } }
		public string Description { get { return m_vo.Description; } }

		public void SetVO(ItemVO vo)
		{
			m_vo = vo;
		}
	}
}
