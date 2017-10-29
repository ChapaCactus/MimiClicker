using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Mimic : BaseCharaModel
{
	public int ChargePower { get; private set; }

	// トレーニングにかかるコスト
	public int TrainingCost { get { return (int)(Level * 1.5f); } }

	private static readonly string PREFAB_PATH = "Prefabs/Character/Mimic";

	private void Awake()
	{
		// test
		ChargePower = 1;
	}

	public static Mimic Create()
	{
		var prefab = Resources.Load<Mimic>(PREFAB_PATH);
		var mimic = Instantiate<Mimic>(prefab);
		mimic.Init();

		return mimic;
	}

	public void ChargeGold(Action<int> onEndCharge)
	{
		var screenPos = Utilities.GetScreenPosition(transform.position);
		var fukidashi = Fukidashi.Create();
		fukidashi.Setup("+1", () => { });
		fukidashi.Move(screenPos + new Vector2(0, 25), 15f);

		onEndCharge(ChargePower);
	}

	public void Training(Action success, Action failure)
	{
		var gold = GlobalGameData.Gold;

		if (gold >= TrainingCost)
		{
			Level++;
			GlobalGameData.UseGold(TrainingCost);

			success();
		}
		else
		{
			failure();
		}
	}

	/// <summary>
	/// 初期化
	/// </summary>
	private void Init()
	{
		m_statusVO = StatusVO.Create();
	}

	protected override void OnKilledTarget(StatusVO killedCharaVO)
	{
		//
	}
}
