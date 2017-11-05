using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInfoPanel : MonoBehaviour
{
	public void Show(bool active)
	{
		if (active)
		{
			OnShow();
			// 表示
			gameObject.SetActive(true);
		}
		else
		{
			// 非表示
			gameObject.SetActive(false);
		}
	}

	public abstract void UpdateUITexts();

	protected abstract void OnShow();
}
