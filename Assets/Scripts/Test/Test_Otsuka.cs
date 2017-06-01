using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Otsuka : MonoBehaviour {

    CharacterController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        var move = new Vector3(
            Input.GetAxis("move_x"),
            0,
            Input.GetAxis("move_y")
        );

        controller.SimpleMove(move * 10);
	}
}
