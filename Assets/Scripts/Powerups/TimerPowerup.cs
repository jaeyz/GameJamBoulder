using UnityEngine;
using System.Collections;

public class TimerPowerup : MonoBehaviour {

	public static System.Action OnPowerUpCollided;

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Boulder") {
			if (OnPowerUpCollided != null)
				OnPowerUpCollided();
			AudioManager.Instance.PlaySound(AudioManager.BATTERY);
			Destroy(gameObject);
		}
	}

	void OnBecameInvisible() {
		Destroy (transform.root.gameObject);
	}

}
