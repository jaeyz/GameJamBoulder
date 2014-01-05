using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	
	public float runTime = 0;
	public int batteryBars = 6;
	public float secondsCounter = 0;
	private float currentTime = 30;

	private int currentScore = 0;

	[SerializeField]
	private UILabel txtTimer;

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
		batteryBars = Mathf.Clamp (++batteryBars, 0, 6);
	}

	public void AddBonusScore(int bonus) {
		currentScore += bonus;
	}

}
