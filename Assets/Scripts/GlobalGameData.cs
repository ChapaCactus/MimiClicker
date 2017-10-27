using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary>
/// ゲーム全体で扱うデータクラス
/// </summary>
public static class GlobalGameData
{
	// レベル
	public static int Level { get; private set; }
	// 所持金
	public static int Gold { get; private set; }
	// 累計の取得したお金
	public static int TotalGold { get; private set; }

	// トレーニングにかかるコスト
	public static int TrainingCost { get { return (int)(Level * 1.5f); } }

	/// <summary>
	/// データセーブ
	/// </summary>
	/// <param name="onComplete">セーブ完了時</param>
	public static void Save(Action onComplete)
	{
		onComplete();
	}

	/// <summary>
	/// データロード
	/// </summary>
	/// <param name="onComplete">ロード完了時</param>
	public static void Load(Action onComplete)
	{
		Level = 0;
		Gold = 0;
		TotalGold = 0;

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

		Debug.Log("Gold Gained -> Gold: " + Gold + ", TotalGold: " + TotalGold);
	}

	public static void Training(Action success, Action failure)
	{
		Level++;

		success();
	}
}
