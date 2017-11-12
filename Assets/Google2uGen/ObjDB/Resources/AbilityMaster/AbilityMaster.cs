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
	public class AbilityMasterRow : IGoogle2uRow
	{
		public string _Name;
		public string _TargetStatus;
		public int _Value;
		public int _Rate;
		public string _Explain;
		public string _SpriteName;
		public AbilityMasterRow(string __ID, string __Name, string __TargetStatus, string __Value, string __Rate, string __Explain, string __SpriteName) 
		{
			_Name = __Name.Trim();
			_TargetStatus = __TargetStatus.Trim();
			{
			int res;
				if(int.TryParse(__Value, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Value = res;
				else
					Debug.LogError("Failed To Convert _Value string: "+ __Value +" to int");
			}
			{
			int res;
				if(int.TryParse(__Rate, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Rate = res;
				else
					Debug.LogError("Failed To Convert _Rate string: "+ __Rate +" to int");
			}
			_Explain = __Explain.Trim();
			_SpriteName = __SpriteName.Trim();
		}

		public int Length { get { return 6; } }

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
					ret = _TargetStatus.ToString();
					break;
				case 2:
					ret = _Value.ToString();
					break;
				case 3:
					ret = _Rate.ToString();
					break;
				case 4:
					ret = _Explain.ToString();
					break;
				case 5:
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
				case "_TargetStatus":
					ret = _TargetStatus.ToString();
					break;
				case "_Value":
					ret = _Value.ToString();
					break;
				case "_Rate":
					ret = _Rate.ToString();
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
			ret += "{" + "_TargetStatus" + " : " + _TargetStatus.ToString() + "} ";
			ret += "{" + "_Value" + " : " + _Value.ToString() + "} ";
			ret += "{" + "_Rate" + " : " + _Rate.ToString() + "} ";
			ret += "{" + "_Explain" + " : " + _Explain.ToString() + "} ";
			ret += "{" + "_SpriteName" + " : " + _SpriteName.ToString() + "} ";
			return ret;
		}
	}
	public class AbilityMaster :  Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds {
			ID_000, ID_001
		};
		public string [] rowNames = {
			"ID_000", "ID_001"
		};
		public System.Collections.Generic.List<AbilityMasterRow> Rows = new System.Collections.Generic.List<AbilityMasterRow>();
		public override void AddRowGeneric (System.Collections.Generic.List<string> input)
		{
			Rows.Add(new AbilityMasterRow(input[0],input[1],input[2],input[3],input[4],input[5],input[6]));
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
		public AbilityMasterRow GetRow(rowIds in_RowID)
		{
			AbilityMasterRow ret = null;
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
		public AbilityMasterRow GetRow(string in_RowString)
		{
			AbilityMasterRow ret = null;
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
