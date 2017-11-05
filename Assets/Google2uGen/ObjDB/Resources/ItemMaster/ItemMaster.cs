//----------------------------------------------
//    Google2u: Google Doc Unity integration
//         Copyright © 2015 Litteratus
//
//        This file has been auto-generated
//              Do not manually edit
//----------------------------------------------

using UnityEngine;
using System.Globalization;

namespace Google2u
{
	[System.Serializable]
	public class ItemMasterRow : IGoogle2uRow
	{
		public string _Name;
		public string _Type;
		public int _HP;
		public int _ATK;
		public int _DEF;
		public string _Explain;
		public string _SpriteName;
		public ItemMasterRow(string __ID, string __Name, string __Type, string __HP, string __ATK, string __DEF, string __Explain, string __SpriteName) 
		{
			_Name = __Name.Trim();
			_Type = __Type.Trim();
			{
			int res;
				if(int.TryParse(__HP, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_HP = res;
				else
					Debug.LogError("Failed To Convert _HP string: "+ __HP +" to int");
			}
			{
			int res;
				if(int.TryParse(__ATK, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_ATK = res;
				else
					Debug.LogError("Failed To Convert _ATK string: "+ __ATK +" to int");
			}
			{
			int res;
				if(int.TryParse(__DEF, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_DEF = res;
				else
					Debug.LogError("Failed To Convert _DEF string: "+ __DEF +" to int");
			}
			_Explain = __Explain.Trim();
			_SpriteName = __SpriteName.Trim();
		}

		public int Length { get { return 7; } }

		public string this[int i]
		{
		    get
		    {
		        return GetStringDataByIndex(i);
		    }
		}

		public string GetStringDataByIndex( int index )
		{
			string ret = System.String.Empty;
			switch( index )
			{
				case 0:
					ret = _Name.ToString();
					break;
				case 1:
					ret = _Type.ToString();
					break;
				case 2:
					ret = _HP.ToString();
					break;
				case 3:
					ret = _ATK.ToString();
					break;
				case 4:
					ret = _DEF.ToString();
					break;
				case 5:
					ret = _Explain.ToString();
					break;
				case 6:
					ret = _SpriteName.ToString();
					break;
			}

			return ret;
		}

		public string GetStringData( string colID )
		{
			var ret = System.String.Empty;
			switch( colID )
			{
				case "_Name":
					ret = _Name.ToString();
					break;
				case "_Type":
					ret = _Type.ToString();
					break;
				case "_HP":
					ret = _HP.ToString();
					break;
				case "_ATK":
					ret = _ATK.ToString();
					break;
				case "_DEF":
					ret = _DEF.ToString();
					break;
				case "_Explain":
					ret = _Explain.ToString();
					break;
				case "_SpriteName":
					ret = _SpriteName.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "_Name" + " : " + _Name.ToString() + "} ";
			ret += "{" + "_Type" + " : " + _Type.ToString() + "} ";
			ret += "{" + "_HP" + " : " + _HP.ToString() + "} ";
			ret += "{" + "_ATK" + " : " + _ATK.ToString() + "} ";
			ret += "{" + "_DEF" + " : " + _DEF.ToString() + "} ";
			ret += "{" + "_Explain" + " : " + _Explain.ToString() + "} ";
			ret += "{" + "_SpriteName" + " : " + _SpriteName.ToString() + "} ";
			return ret;
		}
	}
	public class ItemMaster :  Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds {
			ID_001, ID_002, ID_003, ID_004, ID_005
		};
		public string [] rowNames = {
			"ID_001", "ID_002", "ID_003", "ID_004", "ID_005"
		};
		public System.Collections.Generic.List<ItemMasterRow> Rows = new System.Collections.Generic.List<ItemMasterRow>();
		public override void AddRowGeneric (System.Collections.Generic.List<string> input)
		{
			Rows.Add(new ItemMasterRow(input[0],input[1],input[2],input[3],input[4],input[5],input[6],input[7]));
		}
		public override void Clear ()
		{
			Rows.Clear();
		}
		public IGoogle2uRow GetGenRow(string in_RowString)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}
		public IGoogle2uRow GetGenRow(rowIds in_RowID)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public ItemMasterRow GetRow(rowIds in_RowID)
		{
			ItemMasterRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public ItemMasterRow GetRow(string in_RowString)
		{
			ItemMasterRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}

	}

}
