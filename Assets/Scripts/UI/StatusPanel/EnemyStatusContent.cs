using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

public class EnemyStatusContent : MonoBehaviour
{
	public int WorldID { get; private set; }

	private HealthBar m_healthBar;

	[SerializeField]
	private Text m_nameText;
	[SerializeField]
	private Transform m_contentsParent;
	[SerializeField]
	private Transform m_animationTarget;
	[SerializeField]
	private Image m_backGroundImage;

	public void Setup(int worldID, bool isEnemy)
	{
		WorldID = worldID;

		if (isEnemy)
		{
			SetEnemyBG();
			EnemyMoveIn();
		}
		else
		{
			SetPlayerBG();
			PlayerMoveIn();
		}
	}

	public void SetName(string name)
	{
		m_nameText.text = name;
	}

	public void SetHealth(bool isEnemy, int maxHealth, int health)
	{
		if (m_healthBar == null)
		{
			HealthBar.Create(m_contentsParent, (healthBar) =>
			{
				m_healthBar = healthBar;
				m_healthBar.SetValue(maxHealth, health);
			});
		}
		else
		{
			m_healthBar.SetValue(maxHealth, health);
		}
	}

	public void MoveOut(bool isEnemy, Action onComplete)
	{
		if(isEnemy)
		{
			EnemyMoveOut(onComplete);
		} else
		{
			PlayerMoveOut(onComplete);
		}
	}

	private void EnemyMoveIn()
	{
		MoveX(400, 0);
	}

	private void PlayerMoveIn()
	{
		MoveX(-400, 0);
	}

	private void EnemyMoveOut(Action onComplete)
	{
		MoveX(0, 400, onComplete);
	}

	private void PlayerMoveOut(Action onComplete)
	{
		MoveX(0, -400, onComplete);
	}

	private void MoveX(float fromX, float toX, Action onComplete = null)
	{
		m_animationTarget.localPosition = new Vector2(fromX, 0);
		m_animationTarget.DOLocalMoveX(toX, 1f)
						 .SetEase(Ease.InExpo)
		                 .OnComplete(() => onComplete.SafeCall());
	}

	private void SetEnemyBG()
	{
		SetBGColor(Color.red * 0.7f);
	}

	private void SetPlayerBG()
	{
		SetBGColor(Color.green * 0.7f);
	}

	// 背景色変更
	private void SetBGColor(Color color)
	{
		m_backGroundImage.color = color;
	}
}
