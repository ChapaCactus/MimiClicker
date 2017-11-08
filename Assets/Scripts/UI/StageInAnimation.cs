using System;
using System.Collections;

using UnityEngine;
using UnityEngine.UI;

using DarkTonic.MasterAudio;

using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class StageInAnimation : MonoBehaviour
{
	[SerializeField]
	private CanvasGroup m_canvasGroup;
	[SerializeField]
	private Text m_text;

	private Action m_onEnd;

	private static readonly string PREFAB_NAME = "Prefabs/UI/Animation/StageInAnimation";
	private static readonly string SE_NAME = "Bravery";
	private static readonly float ANIM_IN_DURATION = 5;
	private static readonly float ANIM_OUT_DURATION = 2;

	public static void Create(Transform parent, Action<StageInAnimation> callback)
	{
		var prefab = Resources.Load(PREFAB_NAME) as GameObject;
		var animation = Instantiate(prefab, parent).GetComponent<StageInAnimation>();

		callback.SafeCall(animation);
	}

	public void Kill()
	{
		Destroy(gameObject);
	}

	public void Play(string stageName, Action onEnd)
	{
		m_text.text = stageName;
		m_onEnd = onEnd;

		gameObject.SetActive(true);

		StartCoroutine(PlayAnimation());
	}

	private IEnumerator PlayAnimation()
	{
		bool isPlaying = true;
		var wait = new WaitWhile(() => isPlaying);

		m_canvasGroup.alpha = 0;
		m_canvasGroup.interactable = false;
		m_canvasGroup.blocksRaycasts = false;

		// SE再生
		MasterAudio.PlaySound(SE_NAME, 1, null, 1);

		var seq = DOTween.Sequence();
		seq.Append(
			m_canvasGroup.DOFade(1, ANIM_IN_DURATION)
			.SetEase(Ease.OutExpo)
		);
		seq.Append(
			m_canvasGroup.DOFade(0, ANIM_OUT_DURATION)
		);
		seq.OnComplete(() => isPlaying = false);

		yield return wait;

		m_onEnd.SafeCall();

		m_canvasGroup.alpha = 0;
		m_canvasGroup.interactable = false;
		m_canvasGroup.blocksRaycasts = false;

		Init();
	}

	private void Init()
	{
		m_onEnd = null;
	}
}
