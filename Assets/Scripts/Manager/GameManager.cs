using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using DarkTonic.MasterAudio;

public class GameManager : MonoBehaviour
{
	private GameController m_gameController;
	// 基本操作するミミック
	[SerializeField] private Mimic m_mainMimic;
	// サブミミック
	[SerializeField] private Mimic[] m_subMimics;

	// 敵スポナー
	[SerializeField] private EnemySpawner m_enemySpawner;

	[SerializeField] private UIManager m_uiManager;

	// 出現している敵
	public Enemy Enemy { get; set; }

	private void Awake()
	{
		StartCoroutine(Setup());
	}

	public Mimic GetMainMimic()
	{
		return m_mainMimic;
	}

	public void KillEnemy()
	{
		Destroy(Enemy.gameObject);
		Enemy = null;
	}

	private IEnumerator Setup()
	{
		yield return Load();

		UpdateUIContents();

		yield return CreateGameController();

		yield return CreateMainMimic();

		yield return SceneIn();

		yield return SetupEnemySpawner();
	}

	private IEnumerator SceneIn()
	{
		var isPlaying = true;
		var wait = new WaitWhile(() => isPlaying);

		StageInAnimation.Create(UIController.I.GetMainCanvasRect().transform, anim =>
		{
			anim.Play("始まりの野原", () => {
				isPlaying = false;
				anim.Kill();
			});
		});

		yield return wait;
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

	private IEnumerator CreateMainMimic()
	{
		m_mainMimic = Mimic.Create();
		m_mainMimic.SetDeadCallback(() =>
		{
			Destroy(m_mainMimic.gameObject);
			m_mainMimic = null;
		});

		yield return null;
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
		if (m_mainMimic != null)
		{
			m_mainMimic.ChargeGold((charge) => GainGold(charge));
		}
	}

	/// <summary>
	/// ゴールド取得
	/// </summary>
	private void GainGold(int gain)
	{
		GlobalGameData.GainGold(gain, (gold) => { m_uiManager.UpdateGoldText(gold); });
	}

	private void UpdateUIContents()
	{
		m_uiManager.UpdateGoldText(GlobalGameData.Gold);
	}
}
