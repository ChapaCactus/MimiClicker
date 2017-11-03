using System;

using MMCL.VO;

namespace MMCL.DTO
{
	[Serializable]
	public class StatusDTO
	{
		private StatusVO m_vo;

		public int WorldID { get { return m_vo.worldID; } }
		public bool IsEnemy { get { return m_vo.isEnemy; } }

		public string Name { get { return m_vo.name; } }
		public int GainEXP { get { return m_vo.gainExp; } }
		public int Level
		{
			get { return m_vo.level; }
			set
			{
				m_vo.level = value;
			}
		}

		public int MaxHealth { get { return m_vo.maxHealth; } }
		public int Health
		{
			get { return m_vo.health; }
			set
			{
				m_vo.health = value;
				if (m_vo.health < 0)
					m_vo.health = 0;
			}
		}

		public int ATK { get { return m_vo.atk; } }
		public int DEF { get { return m_vo.def; } }

		public int TrainingCost { get { return (int)(Level * 1.5f); } }

		public void SetVO(StatusVO vo)
		{
			m_vo = vo;
		}
	}
}
