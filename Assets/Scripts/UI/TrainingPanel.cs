using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class TrainingPanel : MonoBehaviour
{
	[SerializeField] private Button m_trainingButton;

	private void Awake()
	{
		m_trainingButton.onClick.AddListener(OnTapTraining);
	}

	public void OnTapTraining()
	{
		GlobalGameData.Training(() => { Debug.Log("Success Training."); }, () => { Debug.Log("Failure Training."); });
	}
}
