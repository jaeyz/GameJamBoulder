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


}
