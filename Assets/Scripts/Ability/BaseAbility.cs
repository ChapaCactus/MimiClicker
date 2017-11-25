using MMCL.Enums;

namespace MMCL.Ability
{
	public class BaseAbility
	{
		// 対象ステータス
		public StatusType TargetStatus { get; private set; }
		// 上昇値(実数)
		public int BuffValue { get; private set; }
		// 上昇値(割合)
		public float BuffRate { get; private set; }
	}
}
