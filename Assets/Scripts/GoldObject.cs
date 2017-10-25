using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GoldObject : MonoBehaviour
{
	private float m_duration;
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

	public void Setup(float duration, Action onEndTimer)
	{
		m_duration = duration;
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
		StartCoroutine(TimerCoroutine(m_duration));
	}

	private IEnumerator TimerCoroutine(float duration)
	{
		var waitDuration = new WaitForSeconds(duration);

		yield return waitDuration;

		// 終了時のコールバックを呼ぶ
		m_onEndTimer();
	}
}
