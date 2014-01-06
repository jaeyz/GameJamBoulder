using UnityEngine;
using System.Collections;

public class ButtonStart : MonoBehaviour {

	[SerializeField]
	private GameObject btnStart;
	[SerializeField]
	private GameObject btnHighScore;

	// Use this for initialization
	void Start () {
		UIEventListener.Get (btnStart).onClick += SwitchScene;
		UIEventListener.Get (btnHighScore).onClick += GoHighScore;
	}

	void SwitchScene(GameObject g) {
		UIEventListener.Get (btnStart).onClick -= SwitchScene;
		Application.LoadLevel ("Game");
	}

	void GoHighScore(GameObject g) {
		UIEventListener.Get (btnHighScore).onClick -= GoHighScore;
		Application.LoadLevel ("HighScore");
	}
	
}
