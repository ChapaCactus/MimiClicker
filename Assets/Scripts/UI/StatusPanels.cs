using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using MMCL.DTO;

public class StatusPanels : MonoBehaviour
{
	[SerializeField] private EnemyStatusContent m_contentPrefab;

	[SerializeField] private Transform m_playerStatusParent;
	[SerializeField] private Transform m_enemyStatusParent;

	private Dictionary<int, EnemyStatusContent> m_statusContentDic = new Dictionary<int, EnemyStatusContent>();

	public void SetData(StatusDTO dto)
	{
		if(m_statusContentDic.ContainsKey(dto.WorldID))
		{
			// 登録済の場合は更新
			var content = m_statusContentDic[dto.WorldID];
			content.SetName(dto.Name);
			content.SetHealth(dto.IsEnemy, dto.MaxHealth, dto.Health);
		} else
		{
			// 登録されていないIDの場合は新たに作成
			CreateContent(dto, (content) => {
				content.Setup(dto.WorldID);
				content.SetName(dto.Name);
				content.SetHealth(dto.IsEnemy, dto.MaxHealth, dto.Health);
				m_statusContentDic.Add(dto.WorldID, content);
			});
		}
	}

	public void DeleteContent(StatusDTO dto)
	{
		if(m_statusContentDic.ContainsKey(dto.WorldID))
		{
			var content = m_statusContentDic[dto.WorldID];
			Destroy(content.gameObject);
			m_statusContentDic[dto.WorldID] = null;
		} else
		{
			// 既に存在しないIDなら何もしない
		}
	}

	/// <summary>
	/// 情報パネル作成
	/// </summary>
	private void CreateContent(StatusDTO dto, Action<EnemyStatusContent> callback)
	{
		var prefab = m_contentPrefab;
		var parent = dto.IsEnemy ? m_enemyStatusParent : m_playerStatusParent;
		var content = Instantiate<EnemyStatusContent>(prefab, parent);

		callback(content);
	}
}
