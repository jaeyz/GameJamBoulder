using UnityEngine;
using System.Collections;

public class AttachObject : MonoBehaviour {

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Boulder")
			transform.parent = col.transform;
	}


}
