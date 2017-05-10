﻿//------------------------------------------------------------------------
// ● 使用ライブラリの宣言
//------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
//========================================================================
// ■ Debug_EX
//------------------------------------------------------------------------
//	デバック表示の拡張クラス。
//========================================================================

public class Debug_EX : MonoBehaviour {
	//--------------------------------------------------------------------
	// ● メンバ変数
	//--------------------------------------------------------------------
	public static bool is_view { get; private set; }	// 表示するか？
	static ArrayList texts = new ArrayList();			// デバッグ設定用の文章
	static ArrayList view_texts = new ArrayList();		// デバッグ表示用の文章
	static GUIStyle gui_style = new GUIStyle();			// テキスト描画スタイル
	static int font_size = 14;
	//--------------------------------------------------------------------
	// ● 追加
	//--------------------------------------------------------------------
	public static void add(object o) {
		texts.Add(o);
	}
	//--------------------------------------------------------------------
	// ● 初期化
	//--------------------------------------------------------------------
	void Start() {
		is_view = Debug.isDebugBuild;

		gui_style.normal.textColor = Color.white;
		gui_style.fontSize = font_size;
	}
	//--------------------------------------------------------------------
	// ● 更新（遅）
	//--------------------------------------------------------------------
	void LateUpdate() {
		view_texts = new ArrayList(texts);
		texts.Clear();	// 毎フレーム初期化する
		
		// デバッグ表示キーが押された場合、表示フラグを反転
		if ( Input.GetKeyDown(KeyCode.Alpha1) )
			is_view = !is_view;
	}
	//--------------------------------------------------------------------
	// ● デバッグ表示
	//--------------------------------------------------------------------
	void OnGUI() {
		// 表示する場合
		if (is_view) {
			Rect rect = new Rect(10, 10, 600, font_size + 5);

			// デバック用文章を走査し、全て画面に表示
			foreach (var text in view_texts) {
				if (text is Color)
					gui_style.normal.textColor = (Color)text;
					
				else if (text is string) {
					GUI.Label(rect, (string)text, gui_style);
					rect.y += font_size + 5;
				}
			}
		}
	}
}