using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[SerializeField] private Slider m_slider;

	public static void Create(Transform parent, Action<HealthBar> callback)
	{
		var prefab = UIController.I.LoadHealbarPrefab();
		var healthBar = Instantiate(prefab, parent);

		callback.SafeCall(healthBar);
	}

	public void SetValue(int maxValue, int startValue)
	{
		m_slider.maxValue = maxValue;
		m_slider.value = startValue;
	}
}
