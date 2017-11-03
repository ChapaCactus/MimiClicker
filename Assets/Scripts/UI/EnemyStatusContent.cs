using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class EnemyStatusContent : MonoBehaviour
{
	public int ID { get; private set; }

	[SerializeField]
	private Text m_nameText;

	private HealthBar m_healthBar;

	[SerializeField]
	private Transform m_contentsParent;

	[SerializeField]
	private Image m_backGroundImage;

	public void Setup(int id)
	{
		ID = id;
	}

	public void SetName(string name)
	{
		m_nameText.text = name;
	}

	public void SetHealth(bool isEnemy, int maxHealth, int health)
	{
		if (m_healthBar == null)
		{
			HealthBar.Create(m_contentsParent, (healthBar) =>
			{
				m_healthBar = healthBar;
				m_healthBar.SetValue(maxHealth, health);

				if (isEnemy) SetEnemyBG();
				else SetPlayerBG();
			});
		}
		else
		{
			m_healthBar.SetValue(maxHealth, health);
		}
	}

	private void SetEnemyBG()
	{
		SetBGColor(Color.red * 0.7f);
	}

	private void SetPlayerBG()
	{
		SetBGColor(Color.green * 0.7f);
	}

	// 背景色変更
	private void SetBGColor(Color color)
	{
		m_backGroundImage.color = color;
	}
}
