//------------------------------------------------------------------------
// ● 使用ライブラリの宣言
//------------------------------------------------------------------------
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

using System.Collections;
//========================================================================
// ■ Align_Put
//------------------------------------------------------------------------
//	整列配置クラス。
//========================================================================

public class Align_Put : MonoBehaviour {
	//--------------------------------------------------------------------
	// ● メンバ変数
	//--------------------------------------------------------------------
	[SerializeField] GameObject put_object;
	[SerializeField] float start_z;
	[SerializeField] float end_z;
	[SerializeField] float put_delta_z;
	[SerializeField] bool is_flip;
	//--------------------------------------------------------------------
	// ● 配置
	//--------------------------------------------------------------------
	public void put() {
#if UNITY_EDITOR
		var start_position = transform.position;
		var rotation = put_object.transform.rotation;
		if (is_flip)	rotation *= Quaternion.Euler(0, 180, 0);

		for (var z = start_z; z <= end_z; z += put_delta_z) {
			start_position.z = z;

			var go = (GameObject)PrefabUtility.InstantiatePrefab(put_object);
			go.transform.parent = transform.parent;
			go.transform.position = start_position;
			go.transform.rotation = rotation;
		}

		print("配置しました。");
	}
#endif
}



#if UNITY_EDITOR
//========================================================================
// ■ Align_Put_Editor
//------------------------------------------------------------------------
//	整列配置のエディタクラス。
//========================================================================

[ CustomEditor( typeof(Align_Put) ) ]
public class Align_Put_Editor : Editor {
	//--------------------------------------------------------------------
	// ● InspectorGUI表示
	//--------------------------------------------------------------------
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();

		// ボタンを描画し、押された場合
		if ( GUILayout.Button("Align_Put") )
			( (Align_Put)target ).put();	// 対象スクリプトの配置関数を呼ぶ
	}
}
#endif