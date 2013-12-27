using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private float speed = 6.0f;
	private float jumpSpeed = 8.0f;
	private float gravity = 20.0f;

	private Vector3 moveDirection = Vector3.zero;

	private CharacterController controller;

	public float Speed {
		get {
			return speed;
		} set {
			speed = value;
		}
	}

	public float JumpSpeed {
		get {
			return jumpSpeed;
		} set {
			jumpSpeed = value;
		}
	}

	void Start () {
		controller = GetComponent<CharacterController> ();
	}

	void Update() {

#if UNITY_STANDALONE || UNITY_EDITOR
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 1);
#elif UNITY_ANDROID || UNITY_IPHONE && !UNITY_EDITOR
		moveDirection = new Vector3(Input.gyro.userAcceleration.x, 0, 1);
#endif
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;

			
		if (Input.GetButton ("Jump")) {
			moveDirection.y = jumpSpeed;
		}

		// Apply gravity
		//moveDirection.y -= gravity * Time.deltaTime;
		
		// Move the controller
		controller.Move (moveDirection * Time.deltaTime);

	}

}
