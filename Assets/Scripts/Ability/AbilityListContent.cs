using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using MMCL.VO;

public class AbilityListContent : MonoBehaviour
{
	[SerializeField]
	private Image m_iconImage;

	[SerializeField]
	private Button m_lvUpButton;

	[SerializeField]
	private Text m_nameText;
	[SerializeField]
	private Text m_explainText;

	public int Id { get; private set; }

	public void Setup(int id, Sprite icon)
	{
		Id = id;

		m_iconImage.sprite = icon;

		Refresh();
	}

	public void Refresh()
	{
		var newVO = AbilityVO.Create(Id);

		m_nameText.text = newVO.Name;
		m_explainText.text = newVO.Explain;
	}
}
