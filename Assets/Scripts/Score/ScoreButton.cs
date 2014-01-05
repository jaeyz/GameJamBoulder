using UnityEngine;
using System.Collections;

public class ScoreButton : MonoBehaviour {

	[SerializeField]
	private GameObject buttonMainMenu;

	[SerializeField]
	private UILabel scoreLabel;

	// Use this for initialization
	void Start () {
		scoreLabel.text = PlayerPrefs.GetInt("Score").ToString();
		UIEventListener.Get (buttonMainMenu).onClick += ReturnToMainMenu;
	}

	void ReturnToMainMenu(GameObject g) {
		UIEventListener.Get (buttonMainMenu).onClick -= ReturnToMainMenu;
		Application.LoadLevel("MainMenu");
	}
}
