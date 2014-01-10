using UnityEngine;
using System.Collections;

public class ScoreButton : MonoBehaviour {

	[SerializeField]
	private GameObject buttonMainMenu;

	[SerializeField]
	private GameObject retryButton;

	[SerializeField]
	private UILabel scoreLabel;

	// Use this for initialization
	void Start () {
		AudioManager.Instance.PlayMusic (AudioManager.GAME_OVER);
		scoreLabel.text = "You Scored:\n" + ScoreHolder.Score.ToString();
		UIEventListener.Get (buttonMainMenu).onClick += ReturnToMainMenu;
		UIEventListener.Get (retryButton).onClick += Retry;
	}

	void ReturnToMainMenu(GameObject g) {
		UIEventListener.Get (buttonMainMenu).onClick -= ReturnToMainMenu;
		ScoreHolder.Score = 0;
		AudioManager.Instance.PlaySound (AudioManager.BACK);
		Application.LoadLevel("MainMenu");
	}

	void Retry(GameObject g) {
		UIEventListener.Get (retryButton.gameObject).onClick -= Retry;
		ScoreHolder.Score = 0;
		AudioManager.Instance.PlaySound (AudioManager.RETRY);
		Application.LoadLevel("Game");
	}
}
