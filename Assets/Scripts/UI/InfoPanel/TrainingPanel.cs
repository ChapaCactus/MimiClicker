using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class TrainingPanel : BaseInfoPanel
{
	[SerializeField] private Button m_trainingButton;

	// UIテキスト
	[SerializeField] private Text m_lvText;
	[SerializeField] private Text m_costText;

	private void Awake()
	{
		m_trainingButton.onClick.AddListener(OnTapTraining);
	}

	public void OnTapTraining()
	{
		GetMainMimic().Training(OnTrainingSuccess, OnTrainingFailure);
	}

	/// <summary>
	/// 各種テキスト更新
	/// </summary>
	public override void UpdateUITexts()
	{
		int level = GetCurrentLevel();
		int trainingCost = GetTrainingCost();
		int gold = GetGold();

		m_lvText.text = ("Lv: " + level);
		m_costText.text = ("C: " + trainingCost);
		// トレーニング開始ボタンの活性・非活性化
		m_trainingButton.interactable = (gold >= trainingCost) ? true : false;
	}

	private void OnTrainingSuccess()
	{
		UpdateUITexts();
		UIController.I.UpdateUITexts();
	}

	private void OnTrainingFailure()
	{
		UpdateUITexts();
		UIController.I.UpdateUITexts();
	}

	protected override void OnShow()
	{
	}

	private int GetCurrentLevel()
	{
		return GetMainMimic().Status.Level;
	}

	private int GetTrainingCost()
	{
		return GetMainMimic().Status.TrainingCost;
	}

	private int GetGold()
	{
		return GlobalGameData.Gold;
	}

	private Mimic GetMainMimic()
	{
		return GameController.I.GetMainMimic();
	}
}
