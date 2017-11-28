using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameController : SingletonMonoBehaviour<GameController>
{
	private GameManager m_gameManager;

	// タップした時
	private Action m_onTap;

	private static string GAME_CONTROLLER_GO_NAME = "GameController";

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

	public void Setup(GameManager gameManager)
	{
		m_gameManager = gameManager;
	}

	/// <summary>
	/// コールバック設定
	/// </summary>
	public void SetCallback(Action onTap)
	{
		TouchController.I.SetTapCallback(onTap);
	}

	public Mimic GetMainMimic()
	{
		return m_gameManager.MainMimic;
	}

	/// <summary>
	/// 敵をセット
	/// </summary>
	public void SetEnemy(Enemy enemy)
	{
		m_gameManager.Enemy = enemy;
	}

	/// <summary>
	/// 敵を取得
	/// </summary>
	public Enemy GetEnemy()
	{
		return m_gameManager.Enemy;
	}

	/// <summary>
	/// 敵を殺す
	/// </summary>
	public void KillEnemy()
	{
		m_gameManager.KillEnemy();
	}
}
