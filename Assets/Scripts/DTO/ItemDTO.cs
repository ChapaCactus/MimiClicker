using System;

using MMCL.VO;
using MMCL.Enums;

using Google2u;

using UnityEngine;

namespace MMCL.DTO
{
	[Serializable]
	public class ItemDTO
	{
		private ItemVO m_vo;

		private const string SPRITE_PATH_HEADER = "Images/Icon/Item/";

		public ItemMaster.rowIds RowID { get { return m_vo.RowId; } }
		public bool IsUnique { get { return m_vo.IsUnique; } }
		public string Name { get { return m_vo.Name; } }
		public Rarity Rarity { get { return m_vo.Rarity; } }
		public ItemCategory Category { get { return m_vo.Category; } }
		public int MaxQuantity { get { return m_vo.MaxQuantity; } }
		public int Quantity { get { return m_vo.Quantity; } }
		public string Explain { get { return m_vo.Explain; } }
		// 所持数上限か
		public bool IsFull { get { return (Quantity == MaxQuantity); } }
		// 空スロットか
		public bool IsEmpty { get { return (RowID == ItemMaster.rowIds.ID_000); } }

		public string SpriteFilePath { get { return (SPRITE_PATH_HEADER + m_vo.SpriteName); } }

		/// <summary>
		/// ItemMasterIDからItemDTOを作成
		/// </summary>
		public static void Create(ItemMaster.rowIds rowID, Action<ItemDTO> callback)
		{
			DataManager.I.GetItemDataInMaster(rowID, master =>
			{
				var vo = ItemVO.Create(rowID, master);
				var dto = new ItemDTO();
				dto.SetVO(vo);

				callback.SafeCall(dto);
			});
		}

		/// <summary>
		/// ItemVOからItemDTOを作成
		/// </summary>
		public static void Create(ItemVO vo, Action<ItemDTO> callback)
		{
			var dto = new ItemDTO();
			dto.SetVO(vo);

			callback.SafeCall(dto);
		}

		/// <summary>
		/// 空アイテムDTOを作る
		/// NOTE - 空スロットやダミーとして使う
		/// </summary>
		public static void CreateEmpty(Action<ItemDTO> callback)
		{
			ItemDTO.Create(ItemMaster.rowIds.ID_000, row => callback.SafeCall(row));
		}

		private void SetVO(ItemVO vo)
		{
			m_vo = vo;
		}

		public void Increment()
		{
			m_vo.Quantity++;
		}
	}
}
