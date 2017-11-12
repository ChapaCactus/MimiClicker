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
	public class StageMasterRow : IGoogle2uRow
	{
		public string _Name;
		public System.Collections.Generic.List<string> _Items = new System.Collections.Generic.List<string>();
		public System.Collections.Generic.List<string> _RootA = new System.Collections.Generic.List<string>();
		public System.Collections.Generic.List<string> _RootB = new System.Collections.Generic.List<string>();
		public System.Collections.Generic.List<string> _RootC = new System.Collections.Generic.List<string>();
		public System.Collections.Generic.List<string> _RootD = new System.Collections.Generic.List<string>();
		public System.Collections.Generic.List<string> _RootE = new System.Collections.Generic.List<string>();
		public StageMasterRow(string __ID, string __Name, string __Items, string __RootA, string __RootB, string __RootC, string __RootD, string __RootE) 
		{
			_Name = __Name.Trim();
			{
				string []result = __Items.Split("|".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					_Items.Add( result[i].Trim() );
				}
			}
			{
				string []result = __RootA.Split("|".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					_RootA.Add( result[i].Trim() );
				}
			}
			{
				string []result = __RootB.Split("|".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					_RootB.Add( result[i].Trim() );
				}
			}
			{
				string []result = __RootC.Split("|".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					_RootC.Add( result[i].Trim() );
				}
			}
			{
				string []result = __RootD.Split("|".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					_RootD.Add( result[i].Trim() );
				}
			}
			{
				string []result = __RootE.Split("|".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					_RootE.Add( result[i].Trim() );
				}
			}
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
					ret = _Items.ToString();
					break;
				case 2:
					ret = _RootA.ToString();
					break;
				case 3:
					ret = _RootB.ToString();
					break;
				case 4:
					ret = _RootC.ToString();
					break;
				case 5:
					ret = _RootD.ToString();
					break;
				case 6:
					ret = _RootE.ToString();
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
				case "_Items":
					ret = _Items.ToString();
					break;
				case "_RootA":
					ret = _RootA.ToString();
					break;
				case "_RootB":
					ret = _RootB.ToString();
					break;
				case "_RootC":
					ret = _RootC.ToString();
					break;
				case "_RootD":
					ret = _RootD.ToString();
					break;
				case "_RootE":
					ret = _RootE.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "_Name" + " : " + _Name.ToString() + "} ";
			ret += "{" + "_Items" + " : " + _Items.ToString() + "} ";
			ret += "{" + "_RootA" + " : " + _RootA.ToString() + "} ";
			ret += "{" + "_RootB" + " : " + _RootB.ToString() + "} ";
			ret += "{" + "_RootC" + " : " + _RootC.ToString() + "} ";
			ret += "{" + "_RootD" + " : " + _RootD.ToString() + "} ";
			ret += "{" + "_RootE" + " : " + _RootE.ToString() + "} ";
			return ret;
		}
	}
	public class StageMaster :  Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds {
			ID_001, ID_002
		};
		public string [] rowNames = {
			"ID_001", "ID_002"
		};
		public System.Collections.Generic.List<StageMasterRow> Rows = new System.Collections.Generic.List<StageMasterRow>();
		public override void AddRowGeneric (System.Collections.Generic.List<string> input)
		{
			Rows.Add(new StageMasterRow(input[0],input[1],input[2],input[3],input[4],input[5],input[6],input[7]));
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
		public StageMasterRow GetRow(rowIds in_RowID)
		{
			StageMasterRow ret = null;
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
		public StageMasterRow GetRow(string in_RowString)
		{
			StageMasterRow ret = null;
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
