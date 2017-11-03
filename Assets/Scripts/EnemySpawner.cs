using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Google2u;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private Transform m_enemySpawnPos;
	[SerializeField] private Transform m_enemyGoalPos;

	// 敵ID生成数
	private int m_createdIDCount = 0;

	private float m_enemySpawnTimer = 0;
	private bool m_isInitialized = false;

	private void Update()
	{
		if (!m_isInitialized) return;

		var enemy = GameController.I.GetEnemy();
		if (enemy == null)
		{
			m_enemySpawnTimer -= Time.deltaTime;

			if (m_enemySpawnTimer <= 0)
			{
				m_enemySpawnTimer = 5;
				Spawn();
			}
		}
	}

	public void Setup(Action onSetupComplete)
	{
		m_isInitialized = true;

		onSetupComplete();
	}

	private void Spawn()
	{
		var masterID = EnemyMaster.rowIds.Enemy_001;
		var charaID = m_createdIDCount += 1;
		var enemy = Enemy.Create(transform, masterID, charaID);

		// 到達した時
		Action onEndMove = () => enemy.StartOpening();
		// 帰還した時
		Action endAway = () => GameController.I.KillEnemy();
		// 死んだ時
		Action onDead = () => GameController.I.KillEnemy();

		enemy.Setup(onEndMove, endAway);
		enemy.SetDeadCallback(onDead);
		// 敵をセット
		GameController.I.SetEnemy(enemy);
		// 移動開始
		enemy.Move(m_enemySpawnPos.position, m_enemyGoalPos.position);
	}
}
