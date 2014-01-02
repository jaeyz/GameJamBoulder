using UnityEngine;
using System.Collections;

public class ButtonStart : MonoBehaviour {

	[SerializeField]
	private GameObject btnStart;

	// Use this for initialization
	void Start () {
		UIEventListener.Get (btnStart).onClick += SwitchScene;
	}

	void SwitchScene(GameObject g) {
		UIEventListener.Get (btnStart).onClick -= SwitchScene;
		Application.LoadLevel ("Game");
	}
	
}
