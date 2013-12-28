using UnityEngine;
using System.Collections;

public class PlatformBehaviour : MonoBehaviour {

	void OnBecameInvisible() {
		transform.root.position += new Vector3 (0, 0, 80);
		//Debug.LogError ("asd");
	}
}
