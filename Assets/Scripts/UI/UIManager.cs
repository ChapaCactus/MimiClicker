using System;
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

	// カメラ系
	[SerializeField] private RectTransform m_mainCanvasRect;
	[SerializeField] private Camera m_mainCamera;
	[SerializeField] private Camera m_uiCamera;
	// 所持金表示
	[SerializeField] private Text m_goldText;
	// マップ名表示
	[SerializeField] private Text m_mapTitleText;

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

		if (m_trainingPanel.isActiveAndEnabled)
		{
			// トレーニングパネルが有効なら、UI更新
			m_trainingPanel.UpdateUITexts();
		}
	}

	/// <summary>
	/// マップ名表示を更新
	/// </summary>
	public void SetMapTitleText(string title)
	{
		m_mapTitleText.text = title;
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
					m_trainingPanel.Show(false);
					m_mapPanel.gameObject.SetActive(false);
					break;
				case MainPanelType.Ability:
					m_abilityPanel.gameObject.SetActive(true);
					m_trainingPanel.Show(false);
					m_mapPanel.gameObject.SetActive(false);
					break;
				case MainPanelType.Training:
					m_abilityPanel.gameObject.SetActive(false);
					m_trainingPanel.Show(true);
					m_mapPanel.gameObject.SetActive(false);
					break;
				case MainPanelType.Map:
					m_abilityPanel.gameObject.SetActive(false);
					m_trainingPanel.Show(false);
					m_mapPanel.gameObject.SetActive(true);
					break;
			}
		}
		else
		{
			// 表示しているグループと同じグループが指定されたら、全てオフる
			m_abilityPanel.gameObject.SetActive(false);
			m_trainingPanel.Show(false);
			m_mapPanel.gameObject.SetActive(false);

			m_currentPanelType = MainPanelType.Off;
		}
	}

	public RectTransform GetMainCanvasRect()
	{
		return m_mainCanvasRect;
	}

	public Camera GetMainCamera()
	{
		return m_mainCamera;
	}

	public Camera GetUICamera()
	{
		return m_uiCamera;
	}
}
