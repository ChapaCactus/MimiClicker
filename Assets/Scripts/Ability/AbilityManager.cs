using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MMCL.Enums;

namespace MMCL.Ability
{
	public class AbilityManager : MonoBehaviour
	{
		public BaseAbility[] AutoBuffAbilities { get; private set; }

		/// <summary>
		/// 自動発動アビリティの、それぞれのステータスに対する上昇量合計値を取得
		/// </summary>
		public AutoBuffAmountsContainer GetAutoBuffAmountsContainer()
		{
			var container = AutoBuffAmountsContainer.Create();

			foreach (var buff in AutoBuffAbilities)
			{
				var status = buff.TargetStatus;
				var value = buff.BuffValue;
				var rate = buff.BuffRate;
				// データコンテナの各値を更新
				container.UpdateValue(status, value);
				container.UpdateRate(status, value);
			}

			return container;
		}

		/// <summary>
		/// 上昇値をまとめて受け渡し用データクラス
		/// </summary>
		public class AutoBuffAmountsContainer
		{
			public Dictionary<StatusType, int> Values { get; private set; }
			public Dictionary<StatusType, float> Rates { get; private set; }

			public static AutoBuffAmountsContainer Create()
			{
				return new AutoBuffAmountsContainer();
			}

			// コンストラクタ禁止
			private AutoBuffAmountsContainer() { }

			public void UpdateValue(StatusType status, int value)
			{
				if (Values.ContainsKey(status))
				{
					Values[status] += value;
				}
				else
				{
					Values.Add(status, value);
				}
			}

			public void UpdateRate(StatusType status, int rate)
			{
				if (Rates.ContainsKey(status))
				{
					Rates[status] += rate;
				}
				else
				{
					Rates.Add(status, rate);
				}
			}
		}
	}
}
