using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Google2u;

using MMCL.DTO;

public abstract class BaseCharaModel : MonoBehaviour
{
	public enum CharaState
	{
		None,
		Wait,
		Battle,
		Think,
		Dead
	}

	public StatusDTO Status { get; protected set; }

	private Action m_onDead;

	// アイテムドロップの開始点
	[SerializeField] private Transform m_itemDropStartPos;

	public void Setup()
	{
		
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
	public virtual void Damage(int damage, Action<StatusDTO> onDiedThisChara = null)
	{
		if (Status.Health >= 1)
		{
			Status.Health -= damage;
			UpdateStatusPanel();

			if (Status.Health <= 0)
			{
				// 死亡処理
				Dead();
				onDiedThisChara.SafeCall(Status);
			}
		}
	}

	protected void UpdateStatusPanel()
	{
		// 情報パネル更新
		UIController.I.UpdateStatusPanels(Status);
	}

	/// <summary>
	/// 攻撃処理
	/// </summary>
	protected void Attack()
	{
		var target = GetTarget();

		if(target != null)
		{
			target.Damage(Status.ATK, (killed) => OnKilledTarget(killed));
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
	protected abstract void OnKilledTarget(StatusDTO killedCharaDTO);

	protected abstract void DropItem();

	protected virtual void Dead()
	{
		UIController.I.DeleteStatusPanelsContent(Status);

		DropItem();

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
