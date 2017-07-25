//------------------------------------------------------------------------
// ● 使用ライブラリの宣言
//------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
//========================================================================
// ■ Player
//------------------------------------------------------------------------
//	プレイヤー操作のクラス。
//========================================================================

public class Player : MonoBehaviour {
	//--------------------------------------------------------------------
	// ● メンバ変数
	//--------------------------------------------------------------------
	public float move_speed = 2;
	CharacterController controller;
	new Transform camera;
	//--------------------------------------------------------------------
	// ● 初期化
	//--------------------------------------------------------------------
	void Start() {
		// VRが接続されている場合、非活動状態
		if (OVRManager.isHmdPresent)	gameObject.SetActive(false);

		controller = GetComponent<CharacterController>();
		camera = Camera.main.transform;
	}
	//--------------------------------------------------------------------
	// ● 更新（遅）
	//--------------------------------------------------------------------
	void LateUpdate() {
		var input_vector = new Vector3( Input.GetAxis("move_x"), 0, Input.GetAxis("move_y") );
		var velocity = camera.rotation * input_vector * move_speed;
		velocity.y = 0;
		controller.SimpleMove(velocity);
	}
}