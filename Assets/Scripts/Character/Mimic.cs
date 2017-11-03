using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Mimic : BaseCharaModel
{
	public enum State
	{
		None,
		Wait,
		Battle,
		Think
	}

	public int ChargePower { get; private set; }

	// トレーニングにかかるコスト
	public int TrainingCost { get { return (int)(Level * 1.5f); } }

	private State m_currentState = State.None;

	private float m_attackTimer = 0;

	private Action<int> m_onDamaged;

	private const float ATTACK_TIMER_DEFAULT = 0.3f;
	private const string PREFAB_PATH = "Prefabs/Character/Mimic";

	private void Awake()
	{
		// test
		ChargePower = 1;
		// test ダメージを受けたら戦闘状態にしておく
		m_onDamaged = (damage) =>
		{
			m_currentState = State.Battle;
		};
	}

	private void Update()
	{
		if (m_currentState == State.Battle)
		{
			m_attackTimer -= Time.deltaTime;

			if (m_attackTimer <= 0)
			{
				m_attackTimer = ATTACK_TIMER_DEFAULT;
				Attack();
			}
		}
	}

	public static Mimic Create()
	{
		var prefab = Resources.Load<Mimic>(PREFAB_PATH);
		var mimic = Instantiate<Mimic>(prefab);
		mimic.Init();

		return mimic;
	}

	public override void Damage(int damage, Action<StatusVO> onDiedThisChara)
	{
		base.Damage(damage, onDiedThisChara);

		m_onDamaged.Call(damage);
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
		m_statusVO.isEnemy = false;
		m_statusVO.id = -100;

		// test
		m_statusVO.name = "ミミックちゃん";
		m_statusVO.maxHealth = 10;
		m_statusVO.health = 10;

		base.UpdateStatusPanel();
	}

	protected override BaseCharaModel GetTarget()
	{
		return GameController.I.GetEnemy();
	}

	protected override void OnKilledTarget(StatusVO killedCharaVO)
	{
		Debug.Log(killedCharaVO.name + "を倒した！！ 戦闘に勝利した！！");

		m_currentState = State.Wait;
	}
}
