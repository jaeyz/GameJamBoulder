﻿using UnityEngine;
using System.Collections;

public class TimerPowerup : MonoBehaviour {

	public static System.Action OnPowerUpCollided;

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Boulder") {
			if (OnPowerUpCollided != null)
				OnPowerUpCollided();
			Destroy(gameObject);
		}
	}

}
