using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Google2u;

public abstract class BaseCharaModel : MonoBehaviour
{
	[SerializeField] protected StatusVO m_statusVO;

	private Action m_onDead;

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
	public int ATK
	{
		get { return m_statusVO.atk; }
		protected set
		{
			m_statusVO.atk = value;
			if (m_statusVO.atk < 0) m_statusVO.atk = 0;
		}
	}

	// 防御力
	public int DEF
	{
		get { return m_statusVO.def; }
		protected set
		{
			m_statusVO.def = value;
			if (m_statusVO.def < 0) m_statusVO.def = 0;
		}
	}

	public void SetDeadCallback(Action onDead)
	{
		m_onDead = onDead;
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
	/// <param name="onDiedThisChara">このダメージで死亡したか、その場合死亡したキャラデータを返す</param>
	public virtual void Damage(int damage, Action<StatusVO> onDiedThisChara)
	{
		if (Health >= 1)
		{
			Health -= damage;
			UpdateStatusPanel();

			if (Health <= 0)
			{
				Health = 0;
				// 死亡処理
				Dead();
				onDiedThisChara(m_statusVO);
			}
		}
	}

	protected void UpdateStatusPanel()
	{
		// 情報パネル更新
		UIController.I.UpdateStatusPanels(m_statusVO);
	}

	/// <summary>
	/// 攻撃処理
	/// </summary>
	protected void Attack()
	{
		var target = GetTarget();

		if(target != null)
		{
			target.Damage(ATK, (killed) => OnKilledTarget(killed));
		} else
		{
			Debug.Log("対象が居ません。");
		}
	}

	protected abstract BaseCharaModel GetTarget();

	/// <summary>
	/// 対象を殺した時の処理(abstract)
	/// </summary>
	/// <param name="killedCharaVO">殺したキャラのデータ</param>
	protected abstract void OnKilledTarget(StatusVO killedCharaVO);

	private void Dead()
	{
		UIController.I.DeleteStatusPanelsContent(m_statusVO);

		m_onDead();
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
/// <summary>
/// キャラのステータスデータクラス
/// </summary>
public class StatusVO
{
	public int id;
	public bool isEnemy;

	public string name;

	public int gainExp;// 倒した時に得る経験値

	public int level;

	public int maxHealth, health;
	public int atk;
	public int def;

	/// <summary>
	/// ゲーム用に初期化されたデータを取得
	/// </summary>
	public static StatusVO Create()
	{
		var vo = new StatusVO();
		vo.id = -1;
		vo.isEnemy = false;
		vo.name = "";
		vo.gainExp = 0;
		vo.level = 1;
		vo.maxHealth = 1;
		vo.health = 1;
		vo.atk = 1;
		vo.def = 1;

		return vo;
	}
}
