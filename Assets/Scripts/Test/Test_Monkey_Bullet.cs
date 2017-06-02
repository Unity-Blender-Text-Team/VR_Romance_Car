using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Monkey_Bullet : MonoBehaviour {

    new Rigidbody rigidbody;

    // Use this for initialization
    void Start() {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * 100, ForceMode.Impulse);

		Destroy(gameObject, 3);
    }
	
	void Update () {
		
	}

	// OnCllisionEnterは、Unityが自動で呼ぶ関数
	void OnCollisionEnter(Collision collision) {
		if (collision.collider.name == "Monkey")
		{
			Debug.Log("ゲームクリア！");
			Destroy(collision.collider.gameObject);
		}
	}
	void OnTriggerEnter(Collider collider)
	{
		if (collider.name == "Monkey")
		{
			Debug.Log("ゲームクリア！");
			Destroy(collider.gameObject);
		}
	}
}
