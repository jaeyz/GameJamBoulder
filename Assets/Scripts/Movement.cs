using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	void Start () {
	
	}

	void Update() {
	
	}

	void FixedUpdate () {
		rigidbody.AddForce (Vector3.up * 2);

		if (Input.GetKey (KeyCode.A))
			rigidbody.AddForce (Vector3.left * 2, ForceMode.Impulse);
		if (Input.GetKey (KeyCode.D))
			rigidbody.AddForce (Vector3.right * 2, ForceMode.Impulse);
	}
}
