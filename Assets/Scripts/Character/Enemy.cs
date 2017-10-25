using System;
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
		transform.DOMove(goalPos, 8)
				 .SetEase(Ease.Linear)
				 .OnComplete(() =>
				 {
					 m_onEndMove();
				 });
	}

	private void ChangeState(State nextState)
	{
		if (m_currentState != nextState)
		{
			m_currentState = nextState;
		}
		else
		{
			// 何もしない
		}
	}
}
