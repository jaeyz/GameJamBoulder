using UnityEngine;
using System.Collections;

public class ButtonStart : MonoBehaviour {

	[SerializeField]
	private GameObject btnStart;
	[SerializeField]
	private GameObject btnHighScore;

	bool isLooping = true;

	void Start () {
		UIEventListener.Get (btnStart).onClick += SwitchScene;
		UIEventListener.Get (btnHighScore).onClick += GoHighScore;
		StartCoroutine(AudioManager.Instance.PlayMusicAccordingly (AudioManager.COUGH_INTRO, AudioManager.MAIN_MENU));
	}

	void SwitchScene(GameObject g) {
		isLooping = false;
		UIEventListener.Get (btnStart).onClick -= SwitchScene;
		AudioManager.Instance.PlaySound (AudioManager.START);
		Application.LoadLevel ("Game");
	}

	void GoHighScore(GameObject g) {
		isLooping = false;
		UIEventListener.Get (btnHighScore).onClick -= GoHighScore;
		AudioManager.Instance.PlaySound (AudioManager.HIGHSCORE);
		Application.LoadLevel ("HighScore");
	}
	
}
