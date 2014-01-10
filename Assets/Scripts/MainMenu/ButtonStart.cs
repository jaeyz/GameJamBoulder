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
		StartCoroutine(AudioManager.Instance.PlayMusicAccordingly (AudioManager.COUGH_INTRO, AudioManager.MAIN_MENU));
	}

	void SwitchScene(GameObject g) {
		UIEventListener.Get (btnStart).onClick -= SwitchScene;
		AudioManager.Instance.PlaySound (AudioManager.START);
		Application.LoadLevel ("Game");
	}

	void GoHighScore(GameObject g) {
		UIEventListener.Get (btnHighScore).onClick -= GoHighScore;
		AudioManager.Instance.PlaySound (AudioManager.HIGHSCORE);
		Application.LoadLevel ("HighScore");
	}
	
}
