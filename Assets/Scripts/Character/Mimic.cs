using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Mimic : BaseCharaModel
{
	public int ChargePower { get; private set; }

	private void Awake()
	{
		// test
		ChargePower = 1;
	}

	public void ChargeGold(Action<int> onEndCharge)
	{
		var screenPos = Utilities.GetScreenPosition(transform.position);
		var fukidashi = Fukidashi.Create();
		fukidashi.Setup("+1", () => { });
		fukidashi.Move(screenPos + new Vector2(0, 25), 15f);

		onEndCharge(ChargePower);
	}
}
