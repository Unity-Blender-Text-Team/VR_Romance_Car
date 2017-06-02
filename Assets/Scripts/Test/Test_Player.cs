using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Player : MonoBehaviour {

    CharacterController controller;
    public GameObject bullet;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();

		Debug.Log("Startが呼ばれた");
    }
	
	// Update is called once per frame
	void Update () {
		Debug.Log("Updateが呼ばれた");

		var move = new Vector3(
            Input.GetAxis("move_x"),
            0,
            Input.GetAxis("move_y")
        );

        controller.SimpleMove(transform.rotation * move * 10);

        transform.Rotate(
            transform.up,
            Input.GetAxis("camera_x") * 180 * Time.deltaTime
        );

        if (Input.GetMouseButtonDown(0)) {
            Instantiate(
				bullet,
				transform.position + transform.forward * 1,
				transform.rotation);
        }
	}
}
