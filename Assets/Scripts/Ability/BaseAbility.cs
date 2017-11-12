using MMCL.Enums;

namespace MMCL.Ability
{
	public class BaseAbility
	{
		// 対象ステータス
		public StatusType TargetStatus { get; private set; } = StatusType.None;

		public int BuffValue { get; private set; } = 0;
		public float BuffRate { get; private set; } = 1.0f;
	}
}
