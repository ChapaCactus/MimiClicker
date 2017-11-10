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
	[SerializeField] GameObject m_google2uDatabase;

	public ItemMaster ItemMaster { get; private set; }
	public EnemyMaster EnemyMaster { get; private set; }

	private void Awake()
	{
		ItemMaster = m_google2uDatabase.GetComponent<ItemMaster>();
		EnemyMaster = m_google2uDatabase.GetComponent<EnemyMaster>();
	}

	public void GetItemDataInMaster(ItemMaster.rowIds identifier, Action<ItemMasterRow> callback)
	{
		var row = ItemMaster.GetRow(identifier);
		callback(row);
	}

	/// <summary>
	/// 敵データをマスターから取得
	/// </summary>
	public EnemyMasterRow GetEnemyDataInMaster(string identifier)
	{
		return EnemyMaster.GetRow(identifier);
	}

	public EnemyMasterRow GetEnemyDataInMaster(EnemyMaster.rowIds identifier)
	{
		return EnemyMaster.GetRow(identifier);
	}
}
