using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	private AudioManager audioManager;

	void Awake () {
		audioManager =  AudioManager.Instance;
		audioManager.Initialize();
		Application.LoadLevel("MainMenu");
	}
	

}
