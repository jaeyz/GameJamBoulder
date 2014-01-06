using UnityEngine;
using System.Collections;

public class HighScoreReturn : MonoBehaviour {

	[SerializeField]
	private UILabel highScoreLabel;
	[SerializeField]
	private GameObject btnOk;

	// Use this for initialization
	void Start () {
		highScoreLabel.text = PlayerPrefs.GetInt("Score").ToString();
		UIEventListener.Get (btnOk).onClick += ReturnMe;
	}

	void ReturnMe(GameObject g) {
		UIEventListener.Get (btnOk).onClick -= ReturnMe;
		Application.LoadLevel("MainMenu");
	}

}
