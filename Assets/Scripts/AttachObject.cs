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
		int bonus = 0;
		if (col.tag == "Boulder") {
			transform.parent = col.transform;
			collider.isTrigger = false;
			//FixedJoint f = gameObject.AddComponent<FixedJoint>();
			//f.connectedBody = col.rigidbody;
			bonus = 20;
			//rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		}
		else if (col.tag == "Obs") {
			bonus = 20;
			transform.parent = col.transform;
			collider.isTrigger = false;
		}
		if (OnCollided != null) {
			OnCollided (gameObject);
		}
		Timer.Instance.AddBonusScore(bonus);
	}

	void OnCollisionEnter(Collision col) {
		Debug.Log("asdasdasd");
		transform.localScale -= new Vector3 (0.5f, 0.5f, 0.5f);
	}

}
