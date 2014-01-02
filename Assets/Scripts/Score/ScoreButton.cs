using UnityEngine;
using System.Collections;

public class ScoreButton : MonoBehaviour {

	[SerializeField]
	private GameObject buttonMainMenu;

	// Use this for initialization
	void Start () {
		UIEventListener.Get (buttonMainMenu).onClick += ReturnToMainMenu;
	}

	void ReturnToMainMenu(GameObject g) {
		UIEventListener.Get (buttonMainMenu).onClick -= ReturnToMainMenu;
		Application.LoadLevel("MainMenu");
	}
}
