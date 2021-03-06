﻿using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using DG.Tweening;

using Google2u;

using MMCL.DTO;
using MMCL.VO;

public class Enemy : BaseCharaModel
{
	public enum State
	{
		None,
		Pop,// 出現した
		MoveEnd,// 移動完了時
		Think,// 思考中
		Opening,// 物色中
		Battle,// 戦闘中
		Away// 去る
	}

	private State m_currentState = State.None;

	private Action m_onEndMove;
	private Action m_endAway;// 立ち去った時

	private float m_attackTimer = 0;

	private Vector3 m_spawnPos;

	private const float ATTACK_TIMER_DEFAULT = 2;
	private const string PREFAB_PATH = "Prefabs/Character/Enemy";

	private void Update()
	{
		if (m_currentState == State.Opening)
		{
			m_attackTimer -= Time.deltaTime;

			if (m_attackTimer <= 0)
			{
				m_attackTimer = ATTACK_TIMER_DEFAULT;
				Attack();
			}
		}
	}

	public static Enemy Create(Transform parent, EnemyMaster.rowIds masterID, int charaID)
	{
		var prefab = Resources.Load(PREFAB_PATH) as GameObject;
		var go = Instantiate(prefab, parent);
		var enemy = go.GetComponent<Enemy>();
		// Masterセット
		var enemyMaster = DataManager.I.GetEnemyDataInMaster(masterID);
		enemy.SetVO(charaID, enemyMaster);

		return enemy;
	}

	public void Setup(Action onEndMove, Action endAway)
	{
		m_onEndMove = onEndMove;
		m_endAway = endAway;
	}

	public void SetVO(int charaID, EnemyMasterRow master)
	{
		// ステータスデータセット
		var vo = CreateStatusVOFromMaster(charaID, master);
		Status = new StatusDTO();
		Status.SetVO(vo);

		base.UpdateStatusPanel();
	}

	public void Move(Vector3 startPos, Vector3 goalPos)
	{
		m_spawnPos = startPos;
		transform.position = startPos;
		transform.DOMove(goalPos, 3)
				 .SetEase(Ease.Linear)
				 .OnComplete(() =>
				 {
					 ChangeState(State.MoveEnd);
				 });
	}

	public void StartOpening()
	{
		ChangeState(State.Opening);
	}

	private void ChangeState(State nextState)
	{
		if (m_currentState != nextState)
		{
			m_currentState = nextState;

			if (m_currentState == State.MoveEnd)
			{
				// 移動が終わった時
				var mimic = GameController.I.GetMainMimic();
				if (mimic != null && mimic.CurrentState != CharaState.Dead)
				{
					// ミミックが居るなら
					CreateFukidashi(15, "!", m_onEndMove);
				}
				else
				{
					// ミミックが居ない場合、何もせず帰る
					CreateFukidashi(15, "?", () => ChangeState(State.Away));
				}
			}
			else if (m_currentState == State.Away)
			{
				Away(transform.position, m_spawnPos);
			}
		}
		else
		{
			// 何もしない
		}
	}

	private void CreateFukidashi(float moveY, string message, Action onEndFukidashi)
	{
		var screenPos = Utilities.GetScreenPosition(transform.position);
		var fukidashi = Fukidashi.Create();
		fukidashi.Setup(message, onEndFukidashi);
		fukidashi.Move(screenPos + new Vector2(0, 25), moveY);
	}

	/// <summary>
	/// 帰還
	/// </summary>
	private void Away(Vector3 startPos, Vector3 goalPos)
	{
		// 敵情報パネルを消しておく
		UIController.I.DeleteStatusPanelsContent(Status);

		m_spawnPos = startPos;
		transform.position = startPos;
		transform.DOMove(goalPos, 3)
				 .SetEase(Ease.Linear)
				 .OnComplete(() =>
				 {
					 m_endAway();
				 });
	}

	protected override BaseCharaModel GetTarget()
	{
		return GameController.I.GetMainMimic();
	}

	protected override void OnKilledTarget(StatusDTO killedCharaDTO)
	{
		// NOTE - 敵がMimicを倒した時... 立ち去る
		ChangeState(State.Away);
	}

	/// <summary>
	/// この敵に設定されたアイテムをドロップする
	/// </summary>
	protected override void DropItem()
	{
		var dropID = ItemMaster.rowIds.ID_001;

		ItemDTO.Create(dropID, dto =>
		{
			GlobalGameData.InventoryDTO.TryAddItem(dto, () => { }, () => { });
		});
	}

	/// <summary>
	/// エネミーマスターからステータスデータを作成
	/// </summary>
	private StatusVO CreateStatusVOFromMaster(int charaID, EnemyMasterRow master)
	{
		var statusVO = new StatusVO();
		statusVO.worldID = charaID;
		statusVO.isEnemy = true;
		statusVO.name = master._Name;
		statusVO.gainExp = master._GainExp;
		statusVO.maxHealth = master._HP;
		statusVO.health = master._HP;
		statusVO.atk = master._ATK;
		statusVO.def = master._DEF;

		return statusVO;
	}
}
