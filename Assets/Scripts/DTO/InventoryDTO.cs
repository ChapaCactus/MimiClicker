﻿using System;
using System.Collections.Generic;

using UnityEngine;

using MMCL.VO;

namespace MMCL.DTO
{
	public class InventoryDTO
	{
		private InventoryVO m_vo;
		private ItemDTO[] m_items;

		public ItemDTO[] Items { get { return m_items; } }

		public void SetVO(InventoryVO vo)
		{
			m_vo = vo;

			CreateItemDTOs((dtos) =>
			{
				m_items = dtos;
			});
		}

		// セーブ・ロード用
		public string ConvertDataObject()
		{
			return JsonUtility.ToJson(m_vo);
		}

		/// <summary>
		/// 使用中のスロット数を取得
		/// </summary>
		/// <returns>使用中のスロット数</returns>
		public int GetUsedSlotCount()
		{
			int count = 0;
			foreach (var slot in Items)
			{
				if (slot != null)
				{
					// 使用中ならカウント
					count++;
				}
			}

			return count;
		}

		/// <summary>
		/// アイテムを使用する
		/// </summary>
		public void UseItem(int index)
		{
		}

		/// <summary>
		/// アイテム追加(又は加算)出来るか調べ、可能なら追加
		/// </summary>
		/// <param name="item">追加するアイテム</param>
		/// <param name="success">追加成功</param>
		/// <param name="failure">追加失敗</param>
		public void TryAddItem(ItemDTO item, Action success, Action failure)
		{
			Debug.Log("Adding Item Name: " + item.Name + ", Qty: " + item.Quantity);

			var collectableSlotIndex = CheckCollectableSlot(item);
			if (collectableSlotIndex != -1)
			{
				// 加算
				Add(collectableSlotIndex, item, success);
			}
			else
			{
				// NOTE - 加算できなかった場合、新規追加出来るスロットを探す
				var emptySlotIndex = CheckEmptySlot();
				if (emptySlotIndex != -1)
				{
					// 追加
					Add(emptySlotIndex, item, success);
				}
				else
				{
					// NOTE - 同種アイテム所持しておらず、空きスロットも無いなら追加失敗
					failure.SafeCall();
				}
			}

			Dump();
		}

		private void Add(int index, ItemDTO item, Action onComplete)
		{
			if (Items[index] != null)
			{
				// NOTE - 既に存在するなら数をインクリメント
				// NOTE - 所持上限数によって処理を変える必要あり
				Items[index].Increment();
				onComplete.SafeCall();
			}
			else
			{
				// NOTE - 存在しないなら新規追加
				Items[index] = item;
				onComplete.SafeCall();
			}
		}

		/// <summary>
		/// インベントリを整理する
		/// </summary>
		private void Sort()
		{
		}

		/// <summary>
		/// 指定スロットを空き(null)にする
		/// </summary>
		private void Remove(int index)
		{
			Items[index] = null;
		}

		/// <summary>
		/// インベントリの空きスロットを探す
		/// </summary>
		/// <returns>空きIndex, 空きが見つからなければ-1を返す</returns>
		private int CheckEmptySlot()
		{
			for (int index = 0; index < Items.Length; index++)
			{
				if (Items[index].IsEmpty)
				{
					return index;
				}
			}

			return -1;
		}

		/// <summary>
		/// スロットに纏める(既に所持しているアイテムに加算する)が
		/// 出来るかを調べる、同じアイテムを所持していないorそのアイテムが所持上限で -1を返す
		/// </summary>
		/// <returns>The collectable slot.</returns>
		private int CheckCollectableSlot(ItemDTO item)
		{
			for (int index = 0; index < Items.Length; index++)
			{
				var slot = Items[index];
				if (item.RowID == slot.RowID)
				{
					// 同じアイテムIDで
					if (!slot.IsFull)
					{
						// 所持数上限で無いなら
						return index;
					}
				}
			}

			// 同じアイテムを所持していない or 同種アイテムが全て所持数上限に達している
			return -1;
		}

		private void CreateItemDTOs(Action<ItemDTO[]> callback)
		{
			var res = new List<ItemDTO>();

			for (int i = 0; i < 24; i++)
			{
				ItemDTO.CreateEmpty(dto => {
					res.Add(dto);
				});
			}

			callback(res.ToArray());
		}

		private void Dump()
		{
			Debug.Log("My Itemslots Dumping...");
			for (int i = 0; i < Items.Length; i++)
			{
				Debug.Log("index: " + i + ", name: " + Items[i].Name + ", Qty: " + Items[i].Quantity);
			}
		}
	}
}
