using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class StatusPanels : MonoBehaviour
{
	[SerializeField] private EnemyStatusContent m_contentPrefab;

	[SerializeField] private Transform m_playerStatusParent;
	[SerializeField] private Transform m_enemyStatusParent;

	private Dictionary<int, EnemyStatusContent> m_statusContentDic = new Dictionary<int, EnemyStatusContent>();

	public void SetData(StatusVO vo)
	{
		if(m_statusContentDic.ContainsKey(vo.id))
		{
			// 登録済の場合は更新
			var content = m_statusContentDic[vo.id];
			content.SetName(vo.name);
			content.SetHealth(vo.isEnemy, vo.maxHealth, vo.health);
		} else
		{
			// 登録されていないIDの場合は新たに作成
			CreateContent(vo, (content) => {
				content.Setup(vo.id);
				content.SetName(vo.name);
				content.SetHealth(vo.isEnemy, vo.maxHealth, vo.health);
				m_statusContentDic.Add(vo.id, content);
			});
		}
	}

	public void DeleteContent(StatusVO vo)
	{
		if(m_statusContentDic.ContainsKey(vo.id))
		{
			var content = m_statusContentDic[vo.id];
			Destroy(content.gameObject);
			m_statusContentDic[vo.id] = null;
		} else
		{
			// 既に存在しないIDなら何もしない
		}
	}

	/// <summary>
	/// 情報パネル作成
	/// </summary>
	private void CreateContent(StatusVO vo, Action<EnemyStatusContent> callback)
	{
		var prefab = m_contentPrefab;
		var parent = vo.isEnemy ? m_enemyStatusParent : m_playerStatusParent;
		var content = Instantiate<EnemyStatusContent>(prefab, parent);

		callback(content);
	}
}
