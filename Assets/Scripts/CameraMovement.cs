using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
	[SerializeField]
	private Transform target;
	private float smooth = 5f;

	void Update () {
		transform.position = new Vector3 (target.position.x,(target.position.y + 8),
		           (target.position.z - 7));
	}
}
