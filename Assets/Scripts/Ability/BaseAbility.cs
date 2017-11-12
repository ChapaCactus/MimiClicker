using MMCL.Enums;

namespace MMCL.Ability
{
	public class BaseAbility
	{
		// 対象ステータス
		public StatusType TargetStatus { get; private set; }

		public int BuffValue { get; private set; }
		public float BuffRate { get; private set; }
	}
}
