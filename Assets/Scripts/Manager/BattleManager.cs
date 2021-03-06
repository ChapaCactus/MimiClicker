﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using MMCL.Enums;

using DarkTonic.MasterAudio;

public static class BattleManager
{
	public static BattleState BattleState { get; private set; }

	public static Mimic Mimic { get { return GameController.I.GetMainMimic(); } }
	public static Enemy Enemy { get; private set; }

	private static readonly string FIELD_BGM = "rpg_12_loop";
	private static readonly string BATTLE_BGM = "battle_03_loop";

	public static void StartBattle()
	{
		ChangeState(BattleState.Battle);
	}

	public static void EndBattle()
	{
		ChangeState(BattleState.Not);
	}

	public static void SetEnemy(Enemy enemy)
	{
		Enemy = enemy;
	}

	public static void RemoveEnemy()
	{
		GameObject.Destroy(BattleManager.Enemy.gameObject);
		BattleManager.Enemy = null;
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
			case BattleState.Not:
				MasterAudio.StopAllOfSound(BATTLE_BGM);
				MasterAudio.PlaySound(FIELD_BGM, 0.7f, null, 0.5f);
				break;
			case BattleState.Battle:
				MasterAudio.StopAllOfSound(FIELD_BGM);
				MasterAudio.PlaySound(BATTLE_BGM, 0.7f, null, 0.5f);
				break;
		}
	}
}
