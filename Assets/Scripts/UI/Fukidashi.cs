using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

public class Fukidashi : MonoBehaviour
{
	[SerializeField] private Text m_text;

	[SerializeField] private CanvasGroup m_canvasGroup;

	private Action m_onEndAnimation;

	public static Fukidashi Create()
	{
		var prefab = Resources.Load("Prefabs/UI/Fukidashi") as GameObject;
		var go = Instantiate(prefab, UIController.I.GetMainCanvasRect());
		var fukidashi = go.GetComponent<Fukidashi>();

		return fukidashi;
	}

	public void Setup(string text, Action onEndAnimation)
	{
		m_text.text = text;

		m_onEndAnimation = onEndAnimation;
	}

	public void Move(Vector2 startPos, float moveY)
	{
		transform.localPosition = startPos;

		var sequence = DOTween.Sequence();

		sequence.Append(transform.DOLocalMoveY(moveY, 1f)
						.SetRelative()
						.SetEase(Ease.OutExpo))
				.OnComplete(() => m_onEndAnimation());
		
		sequence.Append(m_canvasGroup.DOFade(0, 0.5f));
	}
}
