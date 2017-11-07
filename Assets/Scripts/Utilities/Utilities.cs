using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public static class Utilities
{
	/// <summary>
	/// intのIDを、Masterで扱う"ID_XXX"の形に整形する
	/// </summary>
	/// <returns>Master用整形済みstringのID</returns>
	public static string ConvertMasterRowID(int id)
	{
		var padleft = id.ToString().PadLeft(3, '0');
		var combine = ("ID_" + padleft);
		return combine;
	}

	/// <summary>
	/// ワールド座標をスクリーン座標に変換
	/// </summary>
	/// <returns>スクリーン座標</returns>
	public static Vector2 GetScreenPosition(Vector3 worldPos)
	{
		var pos = Vector2.zero;

		var uiController = UIController.I;
		var mainCanvasRect = uiController.GetMainCanvasRect();
		var mainCamera = uiController.GetMainCamera();
		var uiCamera = uiController.GetUICamera();

		var screenPos = RectTransformUtility.WorldToScreenPoint(mainCamera, worldPos);
		RectTransformUtility.ScreenPointToLocalPointInRectangle(
			mainCanvasRect, screenPos, uiCamera, out pos);

		return pos;
	}

	/// <summary>
	/// CanvasGroupの表示切り替え
	/// </summary>
	/// <param name="_canvasGroup">対象CanvasGroup</param>
	/// <param name="_value">ON / OFF</param>
	public static void ToggleCanvasGroup(CanvasGroup canvasGroup, bool value)
	{
		if (value)
		{
			// => ON
			canvasGroup.alpha = 1;
			canvasGroup.interactable = true;
			canvasGroup.blocksRaycasts = true;
		}
		else
		{
			// => OFF
			canvasGroup.alpha = 0;
			canvasGroup.interactable = false;
			canvasGroup.blocksRaycasts = false;
		}
	}

	/// <summary>
	/// nullチェック付きAction呼び出し拡張クラス(ジェネリック)
	/// </summary>
	public static void SafeCall<T>(this Action<T> action, T arg)
	{
		if (action != null)
		{
			action(arg);
		}

		Debug.Assert(action != null, "action is null.");
	}

	/// <summary>
	/// nullチェック付きAction呼び出し拡張クラス
	/// </summary>
	public static void SafeCall(this Action action)
	{
		if (action != null)
		{
			action();
		}
	}
}
