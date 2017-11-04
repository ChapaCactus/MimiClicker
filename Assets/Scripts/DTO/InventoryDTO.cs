using System;

using MMCL.VO;

namespace MMCL.DTO
{
	public class InventoryDTO
	{
		private InventoryVO m_vo;
		private ItemDTO[] m_itemSlots;

		public ItemDTO[] ItemSlots { get { return m_itemSlots; } }
		public int MaxSize { get { return m_vo.MaxSize; } }

		public void SetVO(InventoryVO vo)
		{
			m_vo = vo;
		}

		/// <summary>
		/// 使用中のスロット数を取得
		/// </summary>
		/// <returns>使用中のスロット数</returns>
		public int GetUsedSlotCount()
		{
			int count = 0;
			foreach(var slot in m_itemSlots)
			{
				if(slot != null)
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
			var collectableSlotIndex = CheckCollectableSlot(item);
			if(collectableSlotIndex != -1)
			{
				// 加算
				Add(collectableSlotIndex, item, success);
			} else
			{
				// NOTE - 加算できなかった場合、新規追加出来るスロットを探す
				var emptySlotIndex = CheckEmptySlot();
				if(emptySlotIndex != -1)
				{
					// 追加
					Add(emptySlotIndex, item, success);
				} else
				{
					// NOTE - 同種アイテム所持しておらず、空きスロットも無いなら追加失敗
					failure.Call();
				}
			}
		}

		private void Add(int index, ItemDTO item, Action onComplete)
		{
			if(m_itemSlots[index] != null)
			{
				// NOTE - 既に存在するなら数をインクリメント
				m_itemSlots[index].Increment();
				onComplete.Call();
			} else
			{
				// NOTE - 存在しないなら新規追加
				m_itemSlots[index] = item;
				onComplete.Call();
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
			m_itemSlots[index] = null;
		}

		/// <summary>
		/// インベントリの空きスロットを探す
		/// </summary>
		/// <returns>空きIndex, 空きが見つからなければ-1を返す</returns>
		private int CheckEmptySlot()
		{
			for (int index = 0; index < m_itemSlots.Length; index++)
			{
				if(m_itemSlots[index] == null)
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
			var masterID = item.MasterID;

			for (int index = 0; index < m_itemSlots.Length; index++)
			{
				var slot = m_itemSlots[index];
				if (masterID == slot.MasterID)
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
	}
}
