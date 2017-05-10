//------------------------------------------------------------------------
// ● 使用ライブラリの宣言
//------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//========================================================================
// ■ UI_Smartphone
//------------------------------------------------------------------------
//	スマートフォンのUIクラス。
//========================================================================

public class UI_Smartphone : MonoBehaviour {
	//--------------------------------------------------------------------
	// ● メンバ変数
	//--------------------------------------------------------------------
	bool is_active;
	CanvasGroup group;
	public GameObject picture_camera;
	public GameObject take_light;
	float hidden_take_light_second;
	//--------------------------------------------------------------------
	// ● 初期化
	//--------------------------------------------------------------------
	void Start() {
		group = GetComponent<CanvasGroup>();
		StartCoroutine( start_sub() );
	}
	IEnumerator start_sub() {
		is_active = true;
//		yield return null;
		set_active(false);
		yield return null;
	}
	//--------------------------------------------------------------------
	// ● 有効状態を設定
	//--------------------------------------------------------------------
	void set_active(bool is_active) {
		if (is_active != this.is_active) {
			this.is_active = is_active;

			group.alpha = is_active ? 1 : 0;
			picture_camera.SetActive(is_active);
		}
	}
	//--------------------------------------------------------------------
	// ● 更新
	//--------------------------------------------------------------------
	void Update() {
		if ( Input.GetButtonDown("Submit") )
			set_active(!is_active);

		if (hidden_take_light_second < Time.time) {
			hidden_take_light_second = float.PositiveInfinity;
			take_light.SetActive(false);
		}
	}
	//--------------------------------------------------------------------
	// ● ボタンが押されたコールバック関数
	//--------------------------------------------------------------------
	public void on_click(Button button) {
		switch (button.name) {
			case "Button_Take":
				take_light.SetActive(true);
				hidden_take_light_second = 0.1f + Time.time;
				break;
		}
	}
}