using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary>
/// ゲーム全体で扱うデータクラス
/// </summary>
public static class GlobalGameData
{
	// ユーザデータ
	private static UserVO m_userVO;

	// レベル
	public static int Level { get { return m_userVO.level; } }
	// 所持金
	public static int Gold { get { return m_userVO.gold; } }
	// 累計の取得したお金
	public static int TotalGold { get { return m_userVO.totalGold; } }

	// トレーニングにかかるコスト
	public static int TrainingCost { get { return (int)(Level * 1.5f); } }

	private static readonly string USERDATA_KEY = "UserData";

	/// <summary>
	/// データセーブ
	/// </summary>
	/// <param name="onComplete">セーブ完了時</param>
	public static void Save(Action onComplete)
	{
		var dataObject = JsonUtility.ToJson(m_userVO);
		ES2.Save(dataObject, USERDATA_KEY);
		onComplete();
	}

	/// <summary>
	/// データロード
	/// </summary>
	/// <param name="onComplete">ロード完了時</param>
	public static void Load(Action onComplete)
	{
		if (ES2.Exists(USERDATA_KEY))
		{
			var dataObject = ES2.Load<string>(USERDATA_KEY);
			m_userVO = JsonUtility.FromJson<UserVO>(dataObject);
		} else
		{
			// セーブデータが無い場合
			var newData = new UserVO();
			newData.level = 1;
			newData.gold = 0;
			newData.totalGold = 0;
			m_userVO = newData;
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
		m_userVO.gold += gain;
		if (Gold < 0) m_userVO.gold = 0;

		m_userVO.totalGold += gain;

		onGainGold(Gold);
	}

	public static void Training(Action success, Action failure)
	{
		m_userVO.level++;

		success();
	}
}

[Serializable]
public class UserVO
{
	public int level;
	public int gold;
	public int totalGold;
}
