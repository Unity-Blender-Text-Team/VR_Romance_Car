//------------------------------------------------------------------------
// ● 使用ライブラリの宣言
//------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
//========================================================================
// ■ Main_Camera
//------------------------------------------------------------------------
//	メインカメラ操作のクラス。
//========================================================================

public class Main_Camera : MonoBehaviour {
	//--------------------------------------------------------------------
	// ● メンバ変数
	//--------------------------------------------------------------------
	public float rotate_speed = 100;
	Vector3 eulerAngles;
	//--------------------------------------------------------------------
	// ● 初期化
	//--------------------------------------------------------------------
	void Start() {
		eulerAngles = transform.eulerAngles;
	}
	//--------------------------------------------------------------------
	// ● 更新
	//--------------------------------------------------------------------
	void Update() {
		if ( !Input.GetMouseButton(0) ) {
			var input_vector = new Vector3(-Input.GetAxis("camera_y"), Input.GetAxis("camera_x"), 0);
			eulerAngles += input_vector * rotate_speed * Time.deltaTime;
			eulerAngles.x = Mathf.Clamp(eulerAngles.x, -90, 90);
			eulerAngles.y = Mathf.Repeat(eulerAngles.y, 360);
			eulerAngles.z = 0;
			transform.eulerAngles = eulerAngles;
		}
	}
}