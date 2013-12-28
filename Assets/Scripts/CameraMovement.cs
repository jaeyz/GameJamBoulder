using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
	[SerializeField]
	private Transform target;
	private float smooth = 5f;

	void Update () {
		transform.position = new Vector3 (0,(target.position.y + 5),
		           (target.position.z - 5));
	}
}
