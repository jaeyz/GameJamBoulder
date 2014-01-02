using UnityEngine;
using System.Collections;

public class AttachObject : MonoBehaviour {

	public System.Action<GameObject> OnCollided;
		
	private static AttachObject attachObject;

	public static AttachObject Instance {
		get {
			if (attachObject == null)
				attachObject = FindObjectOfType(typeof(AttachObject)) as AttachObject;
			return attachObject;
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Boulder") {
			//transform.parent = col.transform;
			collider.isTrigger = false;
			FixedJoint f = gameObject.AddComponent<FixedJoint>();
			f.connectedBody = col.rigidbody;
			//rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		}
		else if (col.tag == "Obs") {
			transform.parent = col.transform;
			collider.isTrigger = false;
		}
		if (OnCollided != null) {
			Debug.Log(string.Format("[OnCollided] {0}", gameObject));
			OnCollided (gameObject);
		}
	}

}
