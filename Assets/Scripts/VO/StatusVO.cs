using System;

namespace MMCL.VO
{
	[Serializable]
	/// <summary>
	/// キャラのステータスデータクラス
	/// </summary>
	public class StatusVO
	{
		public int worldID;
		public bool isEnemy;
		public string name;
		public int gainExp;// 倒した時に得る経験値

		public int level;
		public int totalExp;
		public int next;

		public int maxHealth, health;
		public int atk;
		public int def;

		/// <summary>
		/// ゲーム用に初期化されたデータを取得
		/// </summary>
		public static StatusVO Create()
		{
			var vo = new StatusVO();
			vo.worldID = -1;
			vo.isEnemy = false;
			vo.name = "";
			vo.gainExp = 0;

			vo.level = 1;
			vo.totalExp = 0;
			vo.next = 0;

			vo.maxHealth = 1;
			vo.health = 1;
			vo.atk = 1;
			vo.def = 1;

			return vo;
		}
	}
}
