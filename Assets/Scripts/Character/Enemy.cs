﻿using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using DG.Tweening;

public class Enemy : BaseCharaModel
{
	public enum State
	{
		None,
		Pop,// 出現した
		MoveEnd,// 移動完了時
		Think,// 思考中
		Battle,// 戦闘中
		Away// 去る
	}

	private State m_currentState = State.None;

	private Action m_onEndMove;

	public void Setup(Action onEndMove)
	{
		m_onEndMove = onEndMove;
	}

	public void Move(Vector3 startPos, Vector3 goalPos)
	{
		transform.position = startPos;
		transform.DOMove(goalPos, 3)
				 .SetEase(Ease.Linear)
				 .OnComplete(() =>
				 {
					 m_onEndMove();
					 ChangeState(State.MoveEnd);
				 });
	}

	private void ChangeState(State nextState)
	{
		if (m_currentState != nextState)
		{
			m_currentState = nextState;

			if(m_currentState == State.MoveEnd)
			{
				// 移動が終わった時
				var screenPos = Utilities.GetScreenPosition(transform.position);
				var fukidashi = Fukidashi.Create();
				fukidashi.Setup("!", () => { Debug.Log("吹き出しアニメーション終わり！"); });
				fukidashi.Move(screenPos + new Vector2(0, 25), 15f);
			}
		}
		else
		{
			// 何もしない
		}
	}
}