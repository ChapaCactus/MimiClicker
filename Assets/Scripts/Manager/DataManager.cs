using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Google2u;

/// <summary>
/// データ管理クラス
/// </summary>
public class DataManager : SingletonMonoBehaviour<DataManager>
{
	// NOTE - G2Uは、勝手にInspectorから外れる事があるため注意
	[SerializeField] private EnemyMaster m_enemyMaster;

	/// <summary>
	/// 敵データをマスターから取得
	/// </summary>
	public EnemyMasterRow GetEnemyDataInMaster(string identifier)
	{
		return m_enemyMaster.GetRow(identifier);
	}

	public EnemyMasterRow GetEnemyDataInMaster(EnemyMaster.rowIds identifier)
	{
		return m_enemyMaster.GetRow(identifier);
	}
}
