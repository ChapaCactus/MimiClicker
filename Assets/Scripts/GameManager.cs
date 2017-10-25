using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour
{
	private GameController m_gameController;

	// 敵スポナー
	[SerializeField] private EnemySpawner m_enemySpawner;

	[SerializeField] private UIManager m_uiManager;
	// 基本操作するミミック
	[SerializeField] private Mimic m_mainMimic;

	// 出現している敵
	public Enemy Enemy { get; set; }

	private void Awake()
	{
		StartCoroutine(Setup());
	}

	private IEnumerator Setup()
	{
		yield return Load();

		yield return CreateGameController();

		yield return SetupEnemySpawner();

		UpdateUIContents();
	}

	private IEnumerator Load()
	{
		bool isLoading = true;
		var wait = new WaitWhile(() => isLoading);
		// データロード
		GlobalGameData.Load(() =>
		{
			isLoading = false;
			Debug.Log("セーブデータロード完了");
		});

		yield return wait;
	}

	private IEnumerator CreateGameController()
	{
		bool isLoading = true;
		var wait = new WaitWhile(() => isLoading);

		// GameController作成
		GameController.Create((controller) =>
		{
			m_gameController = controller;
			m_gameController.Setup(this);
			m_gameController.SetCallback(OnTap);

			isLoading = false;
		});

		yield return wait;
	}

	private IEnumerator SetupEnemySpawner()
	{
		bool isLoading = true;
		var wait = new WaitWhile(() => isLoading);

		m_enemySpawner.Setup(() =>
		{
			isLoading = false;
		});

		yield return wait;
	}

	/// <summary>
	/// タップをした時
	/// </summary>
	private void OnTap()
	{
		m_mainMimic.DropGold(GainGold);
	}

	/// <summary>
	/// ゴールド取得
	/// </summary>
	private void GainGold()
	{
		GlobalGameData.GainGold(1, (gold) => { m_uiManager.UpdateGoldText(gold); });
	}

	private void UpdateUIContents()
	{
		m_uiManager.UpdateGoldText(GlobalGameData.Gold);
	}
}
