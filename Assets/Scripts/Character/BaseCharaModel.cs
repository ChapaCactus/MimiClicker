using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public abstract class BaseCharaModel : MonoBehaviour
{
	// アイテムドロップの開始点
	[SerializeField] private Transform m_itemDropStartPos;

	// Master参照用
	public string ID { get; private set; }

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

	private Vector3 GetRandomDir()
	{
		var randomX = UnityEngine.Random.Range(-3, 4);
		var randomY = 6;
		var randomZ = UnityEngine.Random.Range(-3, 4);
		var randomVec = new Vector3(randomX, randomY, randomZ);

		return randomVec;
	}
}
