using UnityEngine;
using UnityEditor;

namespace Google2u
{
	[CustomEditor(typeof(LevelupTable))]
	public class LevelupTableEditor : Editor
	{
		public int Index = 0;
		public override void OnInspectorGUI ()
		{
			LevelupTable s = target as LevelupTable;
			LevelupTableRow r = s.Rows[ Index ];

			EditorGUILayout.BeginHorizontal();
			if ( GUILayout.Button("<<") )
			{
				Index = 0;
			}
			if ( GUILayout.Button("<") )
			{
				Index -= 1;
				if ( Index < 0 )
					Index = s.Rows.Count - 1;
			}
			if ( GUILayout.Button(">") )
			{
				Index += 1;
				if ( Index >= s.Rows.Count )
					Index = 0;
			}
			if ( GUILayout.Button(">>") )
			{
				Index = s.Rows.Count - 1;
			}

			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "ID", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.LabelField( s.rowNames[ Index ] );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Level", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._Level );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Next", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._Next );
			}
			EditorGUILayout.EndHorizontal();

		}
	}
}
