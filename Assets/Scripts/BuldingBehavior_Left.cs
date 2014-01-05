using UnityEngine;
using System.Collections;

public class BuldingBehavior_Left : MonoBehaviour {

	void OnBecameInvisible() {
		if (tag == "Red") {
			transform.position += new Vector3(0,0,131f);
		} else if (tag == "Pink") {
			transform.root.localPosition += new Vector3(0,0,131f);
		} else if (tag == "White") {
			transform.root.localPosition += new Vector3(0,0,131f);
		}
	}

	void OnCollisionEnter(Collision col) {

		GameObject explosionPrefab = (GameObject) Resources.Load("Smoke");

		ContactPoint contact = col.contacts[0];
		
		Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
		
		Vector3 pos = contact.point;
		
		Transform effect = Instantiate(explosionPrefab, pos, rot) as Transform;

	}

}
