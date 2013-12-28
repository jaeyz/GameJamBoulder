using UnityEngine;
using System.Collections;

public class BoulderBehaviour : MonoBehaviour {
	
	private float boulderSpeed = 5f;
	private float boulderTurnSpeed = 20f;

	public float Speed {
		get {
			return boulderSpeed;
		} set {
			boulderSpeed = value;
		}
	}
	
	void FixedUpdate () {
		rigidbody.AddForce (Vector3.forward * boulderSpeed, ForceMode.Force);
	
		if (Input.GetKey(KeyCode.A))
			rigidbody.AddForce (Vector3.left * (boulderTurnSpeed * Time.deltaTime), ForceMode.VelocityChange);
		if (Input.GetKey(KeyCode.D))
			rigidbody.AddForce (Vector3.right * (boulderTurnSpeed * Time.deltaTime), ForceMode.VelocityChange);
	}
}
