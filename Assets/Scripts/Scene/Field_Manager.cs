//------------------------------------------------------------------------
// ● 使用ライブラリの宣言
//------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
//========================================================================
// ■ Field_Manager
//------------------------------------------------------------------------
//	フィールド場面の管理クラス。
//========================================================================

public class Field_Manager : Scene_Manager {
	//--------------------------------------------------------------------
	// ● メンバ変数
	//--------------------------------------------------------------------
	float end_second;	// ゲームが終了する秒数
	Dictionary<string, AudioSource> ses = new Dictionary<string, AudioSource>();
	Coroutine end_coroutine;
	//--------------------------------------------------------------------
	// ● 初期化
	//--------------------------------------------------------------------
	protected override void Start() {
		base.Start();

		foreach ( var a in GetComponentsInChildren<AudioSource>() )
			ses[a.name] = a;

		end_second = 5 * 60 + Time.time;	// 5分後に終了を設定
	}
	//--------------------------------------------------------------------
	// ● 更新
	//--------------------------------------------------------------------
	protected override void Update() {
		base.Update();

		// 終了秒に到達したか、BackSpaceボタンが押された場合
		if ( end_coroutine == null && ( end_second < Time.time || Input.GetKeyDown(KeyCode.Backspace) ) )
			end_coroutine = StartCoroutine( end() );

		// 終了までの秒数をデバッグ表示
		Debug_EX.add( "end_second : " + (end_second - Time.time) );
	}
	//--------------------------------------------------------------------
	// ● 終了
	//--------------------------------------------------------------------
	IEnumerator end() {
		ses["SE_End"].Play();
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene("Title");    // タイトル場面に遷移
	}
}