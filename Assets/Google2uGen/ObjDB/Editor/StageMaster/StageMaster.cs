using UnityEngine;
using UnityEditor;

namespace Google2u
{
	[CustomEditor(typeof(StageMaster))]
	public class StageMasterEditor : Editor
	{
		public int Index = 0;
		public int _Items_Index = 0;
		public int _RootA_Index = 0;
		public int _RootB_Index = 0;
		public int _RootC_Index = 0;
		public int _RootD_Index = 0;
		public int _RootE_Index = 0;
		public override void OnInspectorGUI ()
		{
			StageMaster s = target as StageMaster;
			StageMasterRow r = s.Rows[ Index ];

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
			GUILayout.Label( "_Name", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._Name );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			if ( r._Items.Count == 0 )
			{
			    GUILayout.Label( "_Items", GUILayout.Width( 150.0f ) );
			    {
			    	EditorGUILayout.LabelField( "Empty Array" );
			    }
			}
			else
			{
			    GUILayout.Label( "_Items", GUILayout.Width( 130.0f ) );
			    if ( _Items_Index >= r._Items.Count )
				    _Items_Index = 0;
			    if ( GUILayout.Button("<", GUILayout.Width( 18.0f )) )
			    {
			    	_Items_Index -= 1;
			    	if ( _Items_Index < 0 )
			    		_Items_Index = r._Items.Count - 1;
			    }
			    EditorGUILayout.LabelField(_Items_Index.ToString(), GUILayout.Width( 15.0f ));
			    if ( GUILayout.Button(">", GUILayout.Width( 18.0f )) )
			    {
			    	_Items_Index += 1;
			    	if ( _Items_Index >= r._Items.Count )
		        		_Items_Index = 0;
				}
				EditorGUILayout.TextField( r._Items[_Items_Index] );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			if ( r._RootA.Count == 0 )
			{
			    GUILayout.Label( "_RootA", GUILayout.Width( 150.0f ) );
			    {
			    	EditorGUILayout.LabelField( "Empty Array" );
			    }
			}
			else
			{
			    GUILayout.Label( "_RootA", GUILayout.Width( 130.0f ) );
			    if ( _RootA_Index >= r._RootA.Count )
				    _RootA_Index = 0;
			    if ( GUILayout.Button("<", GUILayout.Width( 18.0f )) )
			    {
			    	_RootA_Index -= 1;
			    	if ( _RootA_Index < 0 )
			    		_RootA_Index = r._RootA.Count - 1;
			    }
			    EditorGUILayout.LabelField(_RootA_Index.ToString(), GUILayout.Width( 15.0f ));
			    if ( GUILayout.Button(">", GUILayout.Width( 18.0f )) )
			    {
			    	_RootA_Index += 1;
			    	if ( _RootA_Index >= r._RootA.Count )
		        		_RootA_Index = 0;
				}
				EditorGUILayout.TextField( r._RootA[_RootA_Index] );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			if ( r._RootB.Count == 0 )
			{
			    GUILayout.Label( "_RootB", GUILayout.Width( 150.0f ) );
			    {
			    	EditorGUILayout.LabelField( "Empty Array" );
			    }
			}
			else
			{
			    GUILayout.Label( "_RootB", GUILayout.Width( 130.0f ) );
			    if ( _RootB_Index >= r._RootB.Count )
				    _RootB_Index = 0;
			    if ( GUILayout.Button("<", GUILayout.Width( 18.0f )) )
			    {
			    	_RootB_Index -= 1;
			    	if ( _RootB_Index < 0 )
			    		_RootB_Index = r._RootB.Count - 1;
			    }
			    EditorGUILayout.LabelField(_RootB_Index.ToString(), GUILayout.Width( 15.0f ));
			    if ( GUILayout.Button(">", GUILayout.Width( 18.0f )) )
			    {
			    	_RootB_Index += 1;
			    	if ( _RootB_Index >= r._RootB.Count )
		        		_RootB_Index = 0;
				}
				EditorGUILayout.TextField( r._RootB[_RootB_Index] );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			if ( r._RootC.Count == 0 )
			{
			    GUILayout.Label( "_RootC", GUILayout.Width( 150.0f ) );
			    {
			    	EditorGUILayout.LabelField( "Empty Array" );
			    }
			}
			else
			{
			    GUILayout.Label( "_RootC", GUILayout.Width( 130.0f ) );
			    if ( _RootC_Index >= r._RootC.Count )
				    _RootC_Index = 0;
			    if ( GUILayout.Button("<", GUILayout.Width( 18.0f )) )
			    {
			    	_RootC_Index -= 1;
			    	if ( _RootC_Index < 0 )
			    		_RootC_Index = r._RootC.Count - 1;
			    }
			    EditorGUILayout.LabelField(_RootC_Index.ToString(), GUILayout.Width( 15.0f ));
			    if ( GUILayout.Button(">", GUILayout.Width( 18.0f )) )
			    {
			    	_RootC_Index += 1;
			    	if ( _RootC_Index >= r._RootC.Count )
		        		_RootC_Index = 0;
				}
				EditorGUILayout.TextField( r._RootC[_RootC_Index] );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			if ( r._RootD.Count == 0 )
			{
			    GUILayout.Label( "_RootD", GUILayout.Width( 150.0f ) );
			    {
			    	EditorGUILayout.LabelField( "Empty Array" );
			    }
			}
			else
			{
			    GUILayout.Label( "_RootD", GUILayout.Width( 130.0f ) );
			    if ( _RootD_Index >= r._RootD.Count )
				    _RootD_Index = 0;
			    if ( GUILayout.Button("<", GUILayout.Width( 18.0f )) )
			    {
			    	_RootD_Index -= 1;
			    	if ( _RootD_Index < 0 )
			    		_RootD_Index = r._RootD.Count - 1;
			    }
			    EditorGUILayout.LabelField(_RootD_Index.ToString(), GUILayout.Width( 15.0f ));
			    if ( GUILayout.Button(">", GUILayout.Width( 18.0f )) )
			    {
			    	_RootD_Index += 1;
			    	if ( _RootD_Index >= r._RootD.Count )
		        		_RootD_Index = 0;
				}
				EditorGUILayout.TextField( r._RootD[_RootD_Index] );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			if ( r._RootE.Count == 0 )
			{
			    GUILayout.Label( "_RootE", GUILayout.Width( 150.0f ) );
			    {
			    	EditorGUILayout.LabelField( "Empty Array" );
			    }
			}
			else
			{
			    GUILayout.Label( "_RootE", GUILayout.Width( 130.0f ) );
			    if ( _RootE_Index >= r._RootE.Count )
				    _RootE_Index = 0;
			    if ( GUILayout.Button("<", GUILayout.Width( 18.0f )) )
			    {
			    	_RootE_Index -= 1;
			    	if ( _RootE_Index < 0 )
			    		_RootE_Index = r._RootE.Count - 1;
			    }
			    EditorGUILayout.LabelField(_RootE_Index.ToString(), GUILayout.Width( 15.0f ));
			    if ( GUILayout.Button(">", GUILayout.Width( 18.0f )) )
			    {
			    	_RootE_Index += 1;
			    	if ( _RootE_Index >= r._RootE.Count )
		        		_RootE_Index = 0;
				}
				EditorGUILayout.TextField( r._RootE[_RootE_Index] );
			}
			EditorGUILayout.EndHorizontal();

		}
	}
}
