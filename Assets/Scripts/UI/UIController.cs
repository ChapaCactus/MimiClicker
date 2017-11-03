using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using MMCL.DTO;

[RequireComponent(typeof(UIManager))]
public class UIController : SingletonMonoBehaviour<UIController>
{
	private UIManager m_uiManager;

	private void Awake()
	{
		m_uiManager = GetComponent<UIManager>();
	}

	public void UpdateUITexts()
	{
		var gold = GlobalGameData.Gold;
		m_uiManager.UpdateGoldText(gold);
	}

	public RectTransform GetMainCanvasRect()
	{
		return m_uiManager.GetMainCanvasRect();
	}

	public Camera GetMainCamera()
	{
		return m_uiManager.GetMainCamera();
	}

	public Camera GetUICamera()
	{
		return m_uiManager.GetUICamera();
	}

	public void OnClickAbilityPanel()
	{
		m_uiManager.ToggleMainPanel(UIManager.MainPanelType.Ability);
	}

	public void OnClickTrainingPanel()
	{
		m_uiManager.ToggleMainPanel(UIManager.MainPanelType.Training);
	}

	public void OnClickMapPanel()
	{
		m_uiManager.ToggleMainPanel(UIManager.MainPanelType.Map);
	}

	public HealthBar LoadHealbarPrefab()
	{
		return m_uiManager.LoadHealthBarPrefab();
	}

	public void UpdateStatusPanels(StatusDTO dto)
	{
		m_uiManager.UpdateStatusPanels(dto);
	}

	public void DeleteStatusPanelsContent(StatusDTO dto)
	{
		m_uiManager.DeleteStatusPanelsContent(dto);
	}
}
