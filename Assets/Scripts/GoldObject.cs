using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GoldObject : MonoBehaviour
{
	public float LifeTime { get; private set; } = 0;
	private Action m_onEndTimer;

	private const string PREFAB_PATH = "Prefabs/GoldObject";

	public static GoldObject Create(Transform parent)
	{
		var prefab = Resources.Load(PREFAB_PATH) as GameObject;
		var go = Instantiate(prefab, parent);
		go.transform.localPosition = Vector3.zero;
		var gold = go.GetComponent<GoldObject>();

		return gold;
	}

	public void Setup(float lifeTime, Action onEndTimer)
	{
		LifeTime = lifeTime;
		m_onEndTimer = onEndTimer;
	}

	public void Show()
	{
		gameObject.SetActive(true);
	}

	/// <summary>
	/// NOTE - アクティブ時に呼ぶこと
	/// </summary>
	public void StartTimer()
	{
		StartCoroutine(TimerCoroutine());
	}

	private IEnumerator TimerCoroutine()
	{
		var waitDuration = new WaitForSeconds(this.LifeTime);

		yield return waitDuration;

		// 終了時のコールバックを呼ぶ
		m_onEndTimer();
	}
}
