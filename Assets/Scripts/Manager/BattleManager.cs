using System.Collections;
using System.Collections.Generic;

using MMCL.Enums;

using DarkTonic.MasterAudio;

public static class BattleManager
{
	public static BattleState BattleState { get; private set; }

	public static void StartBattle()
	{
		ChangeState(BattleState.Battle);
	}

	public static void EndBattle()
	{
		ChangeState(BattleState.None);
	}

	private static void ChangeState(BattleState next)
	{
		if (BattleState == next) return;

		BattleState = next;
		OnStateChanged();
	}

	private static void OnStateChanged()
	{
		switch(BattleState)
		{
			case BattleState.None:
				MasterAudio.PlaySound("rpg_12_loop", 1, null, 0.5f);
				break;
			case BattleState.Battle:
				MasterAudio.PlaySound("battle_03_loop", 1, null, 0.5f);
				break;
		}
	}
}
