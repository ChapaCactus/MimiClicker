using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameController : MonoBehaviour
{
	// タップした時
	private Action m_onTapCallback;

	private static string GAME_CONTROLLER_GO_NAME = "GameController";

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Tap();
		}
	}

	/// <summary>
	/// ゲームコントローラー作成
	/// </summary>
	/// <param name="onCreate">インスンタンスを返す</param>
	public static void Create(Action<GameController> onCreate)
	{
		var go = new GameObject(GAME_CONTROLLER_GO_NAME);
		var controller = go.AddComponent<GameController>();

		onCreate(controller);
	}

	public void Setup()
	{
	}

	/// <summary>
	/// コールバック設定
	/// </summary>
	public void SetCallback(Action onTapCallback)
	{
		m_onTapCallback = onTapCallback;
	}

	/// <summary>
	/// タップ処理
	/// </summary>
	private void Tap()
	{
		if (m_onTapCallback != null)
		{
			m_onTapCallback();
		}
	}
}
