using System;

using MMCL.VO;

namespace MMCL.DTO
{
	[Serializable]
	public class ItemDTO
	{
		public enum RarityEnum
		{
			N,
			R,
			SR,
			SSR,
			SSSR,
			SSSSR
		}

		private ItemVO m_vo;

		public bool IsUnique { get { return m_vo.IsUnique; } }
		public string Name { get { return m_vo.Name; } }
		public RarityEnum Rarity { get { return (RarityEnum)m_vo.Rarity; } }
		public int Quantity { get { return m_vo.Quantity; } }
		public string Description { get { return m_vo.Description; } }

		public void SetVO(ItemVO vo)
		{
			m_vo = vo;
		}
	}
}
