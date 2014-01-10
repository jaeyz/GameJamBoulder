using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour {
	
	public float runTime = 0;
	public int batteryBars = 6;
	public float secondsCounter = 0;
	private float currentTime = 30;

	private int currentScore = 0;

	[SerializeField]
	private UILabel txtTimer;
	[SerializeField]
	private List<GameObject> batteryBarsObjects;
	[SerializeField]
	private UILabel healthTxt;

	private int playerHealth = 3;

	private static Timer timer;
	public static Timer Instance {
		get {
			if (timer == null)
				timer = FindObjectOfType(typeof(Timer)) as Timer;
			return timer;
		}
	}


	void Start() {
		TimerPowerup.OnPowerUpCollided += AddTime;
		healthTxt.text = string.Format("Life: {0}x", playerHealth);
	}

	void OnDestroy() {
		TimerPowerup.OnPowerUpCollided -= AddTime;
	}

	void Update () {

		currentScore = Mathf.RoundToInt (runTime * 100);

		runTime += Time.deltaTime;

		secondsCounter += Time.deltaTime;

		currentTime += Time.deltaTime;
		txtTimer.text = string.Format("Score: {0}", currentScore);

		// Game Time
		if (currentTime >= 8) {
			currentTime = 0;
			BoulderBehaviour.Instance.AddBoulderSize ();
		}

		// Battery
		if (secondsCounter >= 5 && batteryBars > 0) {
			secondsCounter = 0;
			batteryBars--;
			UpdateBatteries();
		} else if (secondsCounter >= 5 && batteryBars == 0) {
			int highScore = PlayerPrefs.GetInt("Score");

			PlatformBehaviour.Instance.isShuttingDown = true;
			ScoreHolder.Score = currentScore;

			if (currentScore > highScore)
				PlayerPrefs.SetInt("Score", currentScore);

			PlayerPrefs.Save();

			GameStatusManager.Instance.GameOver();
		}
	}

	void AddTime() {
		secondsCounter = 0;
		batteryBars = Mathf.Clamp (++batteryBars, 0, 6);
		UpdateBatteries ();
	}

	public void AddBonusScore(int bonus) {
		currentScore += bonus;
	}

	public void SubtractBonusScore(int bonus) {
		currentScore -= bonus;
	}

	public void DeductPlayerHealth() {
		if (playerHealth > 1) {
			playerHealth--;
			healthTxt.text = string.Format("Life: {0}x", playerHealth);
		} else {
			int highScore = PlayerPrefs.GetInt("Score");
			
			PlatformBehaviour.Instance.isShuttingDown = true;
			ScoreHolder.Score = currentScore;
			
			if (currentScore > highScore)
				PlayerPrefs.SetInt("Score", currentScore);
			
			PlayerPrefs.Save();

			GameStatusManager.Instance.GameOver();
		}
	}

	public int CurrentScore {
		get {
			return currentScore;
		}
	}

	private void UpdateBatteries() {
		for (int x = 0; x < batteryBarsObjects.Count; x++) {
			if (x < batteryBars) {
				batteryBarsObjects[x].SetActive(true);
			} else {
				batteryBarsObjects[x].SetActive(false);
			}
		}

	}

}
