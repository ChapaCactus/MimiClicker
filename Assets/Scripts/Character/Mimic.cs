using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using MMCL.DTO;
using MMCL.VO;

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

	public override void Damage(int damage, Action<StatusDTO> onDiedThisChara)
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

		if (gold >= Status.TrainingCost)
		{
			Status.Level++;
			GlobalGameData.UseGold(Status.TrainingCost);

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
		var vo = StatusVO.Create();
		vo.isEnemy = false;
		vo.worldID = -100;

		// test
		vo.name = "ミミックちゃん";
		vo.maxHealth = 10;
		vo.health = 10;

		Status = new StatusDTO();
		Status.SetVO(vo);

		base.UpdateStatusPanel();
	}

	protected override BaseCharaModel GetTarget()
	{
		return GameController.I.GetEnemy();
	}

	protected override void OnKilledTarget(StatusDTO killedCharaDTO)
	{
		Debug.Log(killedCharaDTO.Name + "を倒した！！ 戦闘に勝利した！！");

		m_currentState = State.Wait;
	}

	protected override void DropItem() { }
}
