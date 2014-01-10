using UnityEngine;
using System.Collections;

public class ButtonStart : MonoBehaviour {

	[SerializeField]
	private GameObject btnStart;
	[SerializeField]
	private GameObject btnHighScore;

	void Start () {
		UIEventListener.Get (btnStart).onClick += SwitchScene;
		UIEventListener.Get (btnHighScore).onClick += GoHighScore;
		if (!AudioManager.Instance.isMusicPlaying (AudioManager.MAIN_MENU))
			AudioManager.Instance.PlayMusic (AudioManager.MAIN_MENU);
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
