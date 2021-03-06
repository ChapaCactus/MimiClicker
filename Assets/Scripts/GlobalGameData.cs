﻿using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using MMCL.VO;
using MMCL.DTO;

/// <summary>
/// ゲーム全体で扱うデータクラス
/// </summary>
public static class GlobalGameData
{
	// ユーザデータ
	private static UserVO m_userVO = null;

	// 所持品
	public static InventoryDTO InventoryDTO { get; private set; }

	// 所持金
	public static int Gold
	{
		get { return m_userVO.gold; }
		private set
		{
			m_userVO.gold = value;
			if (m_userVO.gold < 0) m_userVO.gold = 0;
		}
	}

	// 累計の取得したお金
	public static int TotalGold
	{
		get { return m_userVO.totalGold; }
		private set
		{
			m_userVO.totalGold = value;
			if (m_userVO.totalGold < 0) m_userVO.totalGold = 0;
		}
	}

	private static readonly string USERDATA_KEY = "UserData";
	private static readonly string INVENTORY_KEY = "Inventory";

	/// <summary>
	/// データセーブ
	/// </summary>
	/// <param name="onComplete">セーブ完了時</param>
	public static void Save(Action onComplete)
	{
		// ユーザデータセーブ
		var dataObject = JsonUtility.ToJson(m_userVO);
		ES2.Save(dataObject, USERDATA_KEY);
		var inventoryObject = InventoryDTO.ConvertDataObject();
		ES2.Save(inventoryObject, INVENTORY_KEY);
		onComplete();
	}

	/// <summary>
	/// データロード
	/// </summary>
	/// <param name="onComplete">ロード完了時</param>
	public static void Load(Action onComplete)
	{
		// ユーザーデータのロード
		if (ES2.Exists(USERDATA_KEY))
		{
			var dataObject = ES2.Load<string>(USERDATA_KEY);
			m_userVO = JsonUtility.FromJson<UserVO>(dataObject);
		}
		else
		{
			// セーブデータが無い場合は作成する
			m_userVO = GetNewUserVO();
		}

		// 所持品データのロード
		if (ES2.Exists(INVENTORY_KEY))
		{
			var dataObject = ES2.Load<string>(INVENTORY_KEY);
			var vo = JsonUtility.FromJson<InventoryVO>(dataObject);
			var dto = new InventoryDTO();
			dto.SetVO(vo);
			InventoryDTO = dto;
		}
		else
		{
			var vo = GetNewInventoryVO();
			var dto = new InventoryDTO();
			dto.SetVO(vo);
			InventoryDTO = dto;
		}

		onComplete();
	}

	/// <summary>
	/// 全データを初期化する
	/// CAUTION - データ削除と同義！！
	/// </summary>
	/// <param name="onComplete">全初期化完了時</param>
	public static void InitializeAllData(Action onComplete)
	{
		onComplete();
	}

	/// <summary>
	/// お金を得る
	/// </summary>
	/// <param name="gain">得た金額</param>
	public static void GainGold(int gain, Action<int> onGainGold)
	{
		Gold += gain;
		if (Gold < 0) Gold = 0;

		TotalGold += gain;

		onGainGold(Gold);
	}

	public static void UseGold(int use)
	{
		Gold -= use;
		if (Gold < 0) Gold = 0;
	}

	/// <summary>
	/// 初期化用ユーザーデータ作成
	/// </summary>
	private static UserVO GetNewUserVO()
	{
		var newData = new UserVO();
		newData.gold = 0;
		newData.totalGold = 0;

		return newData;
	}

	private static InventoryVO GetNewInventoryVO()
	{
		var newData = new InventoryVO();

		return newData;
	}
}
