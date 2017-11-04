using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using HedgehogTeam.EasyTouch;

public class TouchManager : MonoBehaviour
{
	private Action m_onTapStart;

	private void Awake()
	{
		EasyTouch.On_TouchStart -= On_TouchStart;
		EasyTouch.On_TouchStart += On_TouchStart;
	}

	public void SetTapCallback(Action onTapStart)
	{
		m_onTapStart = onTapStart;
	}

	private void On_TouchStart(Gesture gesture)
	{
		m_onTapStart();
	}
}
