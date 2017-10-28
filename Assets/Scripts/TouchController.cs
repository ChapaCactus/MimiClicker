using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TouchController : SingletonMonoBehaviour<TouchController>
{
	[SerializeField] private TouchManager m_touchManager;

	public void SetTapCallback(Action onTap)
	{
		m_touchManager.SetTapCallback(onTap);
	}
}
