using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using MMCL.DTO;

public class ItemIcon : MonoBehaviour
{
	[SerializeField]
	private Image m_itemImage;

	[SerializeField]
	private Image m_iconFrameImage;

	[SerializeField]
	private Text m_quantityText;

	[SerializeField]
	private Button m_button;

	public void Setup(ItemDTO item)
	{
		m_quantityText.text = item.Quantity.ToString();

		SetSprite(item.SpriteFilePath);
	}

	private void SetSprite(string path)
	{
		Debug.Log(path);
		var sprite = Resources.Load<Sprite>(path);
		m_itemImage.sprite = sprite;
	}
}
