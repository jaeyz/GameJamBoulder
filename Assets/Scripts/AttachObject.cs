using UnityEngine;
using System.Collections;

public class AttachObject : MonoBehaviour {

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Boulder") {
			transform.parent = col.transform;
			collider.isTrigger = false;
			//rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		}
		else if (col.tag == "Obs") {
			transform.parent = col.transform;
			collider.isTrigger = false;
		}
	}


}
