﻿using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using MMCL.DTO;

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
		Inventory,
		Ability,
		Training,
		Map
	}

	// Canvas
	[SerializeField] private Canvas m_mainCanvas;
	[SerializeField] private RectTransform m_mainCanvasRect;
	// カメラ系
	[SerializeField] private Camera m_mainCamera;
	[SerializeField] private Camera m_uiCamera;
	// 所持金表示
	[SerializeField] private Text m_goldText;
	// マップ名表示
	[SerializeField] private Text m_mapTitleText;

	// 敵味方情報リストパネル
	[SerializeField] private StatusPanels m_statusPanels;

	// 情報パネル
	[SerializeField] private InventoryPanel m_inventoryPanel;
	[SerializeField] private AbilityPanel m_abilityPanel;
	[SerializeField] private TrainingPanel m_trainingPanel;
	[SerializeField] private MapPanel m_mapPanel;
	// UIのキャッシュ保持クラス
	private UICache m_uiCache = new UICache();

	private MainPanelType m_currentPanelType = MainPanelType.Off;

	private const string GOLD_TEXT_HEADER = "G: ";
	// プレハブパス
	private const string HEALTH_BAR_PREFAB_PATH = "Prefabs/UI/HealthBar";

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
					m_inventoryPanel.Show(false);
					m_abilityPanel.gameObject.SetActive(false);
					m_trainingPanel.Show(false);
					m_mapPanel.gameObject.SetActive(false);
					break;
				case MainPanelType.Inventory:
					m_inventoryPanel.Show(true);
					m_abilityPanel.gameObject.SetActive(false);
					m_trainingPanel.Show(false);
					m_mapPanel.gameObject.SetActive(false);
					break;
					
				case MainPanelType.Ability:
					m_inventoryPanel.Show(false);
					m_abilityPanel.gameObject.SetActive(true);
					m_trainingPanel.Show(false);
					m_mapPanel.gameObject.SetActive(false);
					break;
				case MainPanelType.Training:
					m_inventoryPanel.Show(false);
					m_abilityPanel.gameObject.SetActive(false);
					m_trainingPanel.Show(true);
					m_mapPanel.gameObject.SetActive(false);
					break;
				case MainPanelType.Map:
					m_inventoryPanel.Show(false);
					m_abilityPanel.gameObject.SetActive(false);
					m_trainingPanel.Show(false);
					m_mapPanel.gameObject.SetActive(true);
					break;
			}
		}
		else
		{
			// 表示しているグループと同じグループが指定されたら、全てオフる
			m_inventoryPanel.gameObject.SetActive(false);
			m_abilityPanel.gameObject.SetActive(false);
			m_trainingPanel.Show(false);
			m_mapPanel.gameObject.SetActive(false);

			m_currentPanelType = MainPanelType.Off;
		}
	}

	/// <summary>
	/// 敵味方情報リストパネル更新
	/// </summary>
	public void UpdateStatusPanels(StatusDTO dto)
	{
		m_statusPanels.SetData(dto);
	}

	public void DeleteStatusPanelsContent(StatusDTO dto)
	{
		m_statusPanels.DeleteContent(dto);
	}

	public Canvas GetMainCanvas()
	{
		return m_mainCanvas;
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

	public HealthBar LoadHealthBarPrefab()
	{
		return m_uiCache.HealthBar ?? (m_uiCache.HealthBar = Resources.Load<HealthBar>(HEALTH_BAR_PREFAB_PATH));
	}

	private class UICache
	{
		public HealthBar HealthBar { get; set; }
	}
}
