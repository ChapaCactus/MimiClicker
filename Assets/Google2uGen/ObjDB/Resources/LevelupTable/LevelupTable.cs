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
	public class LevelupTableRow : IGoogle2uRow
	{
		public int _Level;
		public int _Next;
		public LevelupTableRow(string __ID, string __Level, string __Next) 
		{
			{
			int res;
				if(int.TryParse(__Level, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Level = res;
				else
					Debug.LogError("Failed To Convert _Level string: "+ __Level +" to int");
			}
			{
			int res;
				if(int.TryParse(__Next, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Next = res;
				else
					Debug.LogError("Failed To Convert _Next string: "+ __Next +" to int");
			}
		}

		public int Length { get { return 2; } }

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
					ret = _Level.ToString();
					break;
				case 1:
					ret = _Next.ToString();
					break;
			}

			return ret;
		}

		public string GetStringData( string colID )
		{
			var ret = System.String.Empty;
			switch( colID )
			{
				case "_Level":
					ret = _Level.ToString();
					break;
				case "_Next":
					ret = _Next.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "_Level" + " : " + _Level.ToString() + "} ";
			ret += "{" + "_Next" + " : " + _Next.ToString() + "} ";
			return ret;
		}
	}
	public class LevelupTable :  Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds {
			Level_1, Level_2, Level_3, Level_4, Level_5, Level_6, Level_7, Level_8, Level_9, Level_10
		};
		public string [] rowNames = {
			"Level_1", "Level_2", "Level_3", "Level_4", "Level_5", "Level_6", "Level_7", "Level_8", "Level_9", "Level_10"
		};
		public System.Collections.Generic.List<LevelupTableRow> Rows = new System.Collections.Generic.List<LevelupTableRow>();
		public override void AddRowGeneric (System.Collections.Generic.List<string> input)
		{
			Rows.Add(new LevelupTableRow(input[0],input[1],input[2]));
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
		public LevelupTableRow GetRow(rowIds in_RowID)
		{
			LevelupTableRow ret = null;
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
		public LevelupTableRow GetRow(string in_RowString)
		{
			LevelupTableRow ret = null;
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
