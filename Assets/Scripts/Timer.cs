using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	
	public int batteryBars = 6;
	public float secondsCounter = 0;

	void Start() {
		TimerPowerup.OnPowerUpCollided += AddTime;
	}

	void OnDestroy() {
		TimerPowerup.OnPowerUpCollided -= AddTime;
	}

	void Update () {
		secondsCounter += Time.deltaTime;

		if (secondsCounter >= 5 && batteryBars > 0) {
			secondsCounter = 0;
			batteryBars--;
		} else if (secondsCounter >= 5 && batteryBars == 0) {
			GameStatusManager.Instance.GameOver();
		}
	}

	void AddTime() {
		batteryBars = Mathf.Clamp (++batteryBars, 0, 6);
	}
}
