using UnityEngine;
using System.Collections;

public class HazardPowerup : MonoBehaviour {

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Boulder") {
			int childCount = col.transform.childCount;
			if (childCount > 0) {
				for(int x = 0; x < (childCount /2); x++ ) {
					BoulderBehaviour.Instance.DecreaseBoulderSize();
					Destroy(col.transform.GetChild(x).gameObject);
				}
			}
		}
	}

}
