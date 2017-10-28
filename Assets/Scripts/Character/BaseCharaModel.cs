using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public abstract class BaseCharaModel : MonoBehaviour
{
	protected StatusVO m_statusVO;

	// アイテムドロップの開始点
	[SerializeField] private Transform m_itemDropStartPos;

	// レベル
	public int Level
	{
		get { return m_statusVO.level; }
		protected set
		{
			m_statusVO.level = value;
			if (m_statusVO.level < 0) m_statusVO.level = 0;
		}
	}

	// 最大HP
	public int MaxHealth
	{
		get { return m_statusVO.maxHealth; }
		protected set
		{
			m_statusVO.maxHealth = value;
			if (m_statusVO.maxHealth < 0) m_statusVO.maxHealth = 0;
		}
	}

	// HP
	public int Health
	{
		get { return m_statusVO.health; }
		protected set
		{
			m_statusVO.health = value;
			if (m_statusVO.health < 0) m_statusVO.health = 0;
		}
	}

	// 攻撃力
	public int Attack
	{
		get { return m_statusVO.attack; }
		protected set
		{
			m_statusVO.attack = value;
			if (m_statusVO.attack < 0) m_statusVO.attack = 0;
		}
	}

	// 防御力
	public int Defense
	{
		get { return m_statusVO.defense; }
		protected set
		{
			m_statusVO.defense = value;
			if (m_statusVO.defense < 0) m_statusVO.defense = 0;
		}
	}

	/// <summary>
	/// ゴールドを落とす
	/// </summary>
	public void DropGold(Action onGoldDied)
	{
		var goldObject = GoldObject.Create(m_itemDropStartPos);
		goldObject.Setup(4.0f, () =>
		{
			onGoldDied();
			Destroy(goldObject.gameObject);
		});
		goldObject.Show();
		goldObject.GetComponent<Rigidbody>().AddForce(GetRandomDir(), ForceMode.VelocityChange);
		goldObject.StartTimer();
	}

	/// <summary>
	/// ダメージを受ける
	/// </summary>
	public void Damage(int damage)
	{
		Health -= damage;
		if (Health <= 0)
		{
			Health = 0;
			// 死亡処理
		}
	}

	private Vector3 GetRandomDir()
	{
		var randomX = UnityEngine.Random.Range(-3, 4);
		var randomY = 6;
		var randomZ = UnityEngine.Random.Range(-3, 4);
		var randomVec = new Vector3(randomX, randomY, randomZ);

		return randomVec;
	}
}

[Serializable]
public class StatusVO
{
	public int level;
	public int gold;
	public int totalGold;

	public int maxHealth, health;
	public int attack;
	public int defense;
}
