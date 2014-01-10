using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoulderBehaviour : MonoBehaviour {
	
	public float boulderSpeed = 5f;
	private float boulderTurnSpeed = 50f;
	private static BoulderBehaviour boulderBehaviour;

	private bool isBoosting = false;

	public static BoulderBehaviour Instance {
		get {
			if (boulderBehaviour == null)
				boulderBehaviour = FindObjectOfType(typeof(BoulderBehaviour)) as BoulderBehaviour;
			return boulderBehaviour;
		}
	}

	public float Speed {
		get {
			return boulderSpeed;
		} set {
			boulderSpeed = value;
		}
	}

	void Start() {
		AudioManager.Instance.PlayLoopingSound (AudioManager.BOULDER_ROLL);
		AudioManager.Instance.PlayMusic (AudioManager.GAME_BGM);
	}

	public void AddBoulderSize() {
		if (transform.localScale.x < 5f)
			transform.localScale += new Vector3 (0.5f, 0.5f, 0.5f);
		    
		if (!isBoosting) {
			boulderSpeed = Mathf.Clamp(boulderSpeed + 1f,
		                           5f, 15f);
		}
	}

	public void DecreaseBoulderSize() {
		if (transform.localScale.x >= 2.2f)
			transform.localScale -= new Vector3 (0.2f, 0.2f, 0.2f);
	}

	public void ReleaseSomeChildObjects() {
		List<GameObject> lst = new List<GameObject> ();
		if (transform.childCount > 0) {
		//	foreach(GameObject g in transform.gameObject) {
		//		lst.Add(g);
		//	}
		}
		/*for (int x = 0; x < 2; x++) {
			if (lst.Count > 0) {
				GameObject g = lst[lst.Count-1];
				lst.RemoveAt(lst.Count-1);
				Destroy(g);
			}
		}*/
	}

	void Update() {
		if (Input.GetKeyUp (KeyCode.Space)) {
			StartCoroutine(Boost ());
		}
	}

	IEnumerator Boost() {
		float speedHolder = boulderSpeed;
		boulderSpeed = 15f;
		isBoosting = true;
		yield return new WaitForSeconds (2f);
		boulderSpeed = speedHolder;
		isBoosting = false;
		StopCoroutine("Boost");
	}

	void FixedUpdate () {
		rigidbody.AddForce (Vector3.forward * boulderSpeed, ForceMode.Force);
		rigidbody.AddTorque (Vector3.right * boulderSpeed, ForceMode.Force);

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
		if (Input.GetKey(KeyCode.A))
			rigidbody.AddForce (Vector3.left * (boulderTurnSpeed * Time.deltaTime), ForceMode.VelocityChange);
		if (Input.GetKey(KeyCode.D))
			rigidbody.AddForce (Vector3.right * (boulderTurnSpeed * Time.deltaTime), ForceMode.VelocityChange);
#elif UNITY_ANDROID || UNITY_IPHONE && !UNITY_EDITOR
		rigidbody.AddForce (new Vector3(Input.acceleration.x,0,0) * (boulderTurnSpeed * Time.deltaTime), ForceMode.VelocityChange);
#endif
	}
	
}
