﻿using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UIController))]
/// <summary>
/// UIマネージャ
/// NOTE - 子要素にCanvasを持たせる想定
/// </summary>
public class UIManager : MonoBehaviour
{
	public enum MainPanelType
	{
		Off,
		Ability,
		Training,
		Map
	}

	// 所持金表示
	[SerializeField] private Text m_goldText;

	// InfoPanels
	[SerializeField] private AbilityPanel m_abilityPanel;
	[SerializeField] private TrainingPanel m_trainingPanel;
	[SerializeField] private MapPanel m_mapPanel;

	private MainPanelType m_currentPanelType = MainPanelType.Off;

	private const string GOLD_TEXT_HEADER = "G: ";

	private void Awake()
	{
		ToggleMainPanel(MainPanelType.Off);
	}

	/// <summary>
	/// 所持金表示を更新
	/// </summary>
	public void UpdateGoldText(int gold)
	{
		m_goldText.text = (GOLD_TEXT_HEADER + gold);
	}

	/// <summary>
	/// メインパネルを切り替え
	/// </summary>
	public void ToggleMainPanel(MainPanelType type)
	{
		if (m_currentPanelType != type)
		{
			m_currentPanelType = type;

			// 現在と違うグループが指定されたらそれを表示
			switch (type)
			{
				case MainPanelType.Off:
					m_abilityPanel.gameObject.SetActive(false);
					m_trainingPanel.gameObject.SetActive(false);
					m_mapPanel.gameObject.SetActive(false);
					break;
				case MainPanelType.Ability:
					m_abilityPanel.gameObject.SetActive(true);
					m_trainingPanel.gameObject.SetActive(false);
					m_mapPanel.gameObject.SetActive(false);
					break;
				case MainPanelType.Training:
					m_abilityPanel.gameObject.SetActive(false);
					m_trainingPanel.gameObject.SetActive(true);
					m_mapPanel.gameObject.SetActive(false);
					break;
				case MainPanelType.Map:
					m_abilityPanel.gameObject.SetActive(false);
					m_trainingPanel.gameObject.SetActive(false);
					m_mapPanel.gameObject.SetActive(true);
					break;
			}
		} else
		{
			// 表示しているグループと同じグループが指定されたら、全てオフる
			m_abilityPanel.gameObject.SetActive(false);
			m_trainingPanel.gameObject.SetActive(false);
			m_mapPanel.gameObject.SetActive(false);

			m_currentPanelType = MainPanelType.Off;
		}
	}
}