using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour {

	void OnTriggerEnter(Collider col) {
		BoulderBehaviour boulderBehaviour = BoulderBehaviour.Instance;
		if (col.tag == "Boulder") {
			boulderBehaviour.DecreaseBoulderSize();
			boulderBehaviour.ReleaseSomeChildObjects();
		}
	}
}
