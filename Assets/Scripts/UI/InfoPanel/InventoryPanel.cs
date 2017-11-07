﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using MMCL.DTO;

/// <summary>
/// インベントリのViewクラス
/// </summary>
public class InventoryPanel : BaseInfoPanel
{
	[SerializeField] private ItemIcon m_itemIconPrefab;
	[SerializeField] private Transform m_itemIconsParent;

	private ItemIcon[] m_itemIcons = null;

	public override void UpdateUITexts()
	{
		UpdateContents();
	}

	/// <summary>
	/// インベントリ用スロットを作成する
	/// </summary>
	private void CreateInventoryContents(InventoryDTO inventory)
	{
		m_itemIcons = new ItemIcon[inventory.ItemSlots.Length];

		for (int i = 0; i < m_itemIcons.Length; i++)
		{
			var icon = Instantiate<ItemIcon>(m_itemIconPrefab, m_itemIconsParent);
			icon.Setup(inventory.ItemSlots[i]);
			m_itemIcons[i] = icon;
		}
	}

	protected override void OnShow()
	{
		if(m_itemIcons == null)
		{
			CreateInventoryContents(GetInventory());
		} else
		{
			UpdateUITexts();
		}
	}

	/// <summary>
	/// アイコンを更新
	/// </summary>
	private void UpdateContents()
	{
		var inventory = GetInventory();
		for (int i = 0; i < m_itemIcons.Length; i++)
		{
			var inventoryItem = inventory.ItemSlots[i];
			var icon = m_itemIcons[i];
			icon.Setup(inventoryItem);
		}
	}

	private InventoryDTO GetInventory()
	{
		return GlobalGameData.InventoryDTO;
	}
}
