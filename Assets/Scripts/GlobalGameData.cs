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
	public static int Level
	{
		get { return m_userVO.level; }
		private set
		{
			m_userVO.level = value;
			if (m_userVO.level < 0) m_userVO.level = 0;
		}
	}

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

	// 最大HP
	public static int MaxHealth
	{
		get { return m_userVO.maxHealth; }
		private set
		{
			m_userVO.maxHealth = value;
			if (m_userVO.maxHealth < 0) m_userVO.maxHealth = 0;
		}
	}

	// HP
	public static int Health
	{
		get { return m_userVO.health; }
		private set
		{
			m_userVO.health = value;
			if (m_userVO.health < 0) m_userVO.health = 0;
		}
	}

	// 攻撃力
	public static int Attack
	{
		get { return m_userVO.attack; }
		private set
		{
			m_userVO.attack = value;
			if (m_userVO.attack < 0) m_userVO.attack = 0;
		}
	}

	// 防御力
	public static int Defense
	{
		get { return m_userVO.defense; }
		private set
		{
			m_userVO.defense = value;
			if (m_userVO.defense < 0) m_userVO.defense = 0;
		}
	}

	// 幸運
	public static int Luck
	{
		get { return m_userVO.luck; }
		private set
		{
			m_userVO.luck = value;
			if (m_userVO.luck < 0) m_userVO.luck = 0;
		}
	}

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
		}
		else
		{
			// セーブデータが無い場合は作成する
			m_userVO = GetNewUserVO();
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
	/// ダメージを受ける
	/// </summary>
	public static void Damage(int damage)
	{
		Health -= damage;
		if (Health <= 0)
		{
			Health = 0;
			// 死亡処理
		}
	}

	public static void Training(Action success, Action failure)
	{
		var gold = GlobalGameData.Gold;
		var trainingCost = GlobalGameData.TrainingCost;

		if (gold >= trainingCost)
		{
			m_userVO.level++;
			GlobalGameData.UseGold(trainingCost);

			success();
		}
		else
		{
			failure();
		}
	}

	/// <summary>
	/// 初期化用ユーザーデータ作成
	/// </summary>
	private static UserVO GetNewUserVO()
	{
		var newData = new UserVO();
		newData.level = 1;
		newData.gold = 0;
		newData.totalGold = 0;

		newData.maxHealth = 1;
		newData.health = 1;
		newData.attack = 1;
		newData.defense = 1;
		newData.luck = 1;

		return newData;
	}
}

[Serializable]
public class UserVO
{
	public int level;
	public int gold;
	public int totalGold;

	public int maxHealth, health;
	public int attack;
	public int defense;

	public int luck;
}
