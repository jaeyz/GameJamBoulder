using UnityEngine;
using System.Collections;

public class AttachObject : MonoBehaviour {

	public System.Action<GameObject> OnCollided;
		
	private static AttachObject attachObject;

	public static AttachObject Instance {
		get {
			if (attachObject == null)
				attachObject = FindObjectOfType(typeof(AttachObject)) as AttachObject;
			return attachObject;
		}
	}

	void OnTriggerEnter(Collider col) {
		int bonus = 0;

		AudioManager.Instance.PlaySound (GetObstacleSound (tag));

		collider.enabled = false;

		if (col.tag == "Boulder") {
			transform.parent = col.transform;
			bonus = 20;
		}
		else if (col.tag == "Obs" || col.tag == "Fence" || col.tag == "Human" || col.tag == "Radio") {
			bonus = 20;
			transform.parent = col.transform;
		} 

		if (OnCollided != null) {
			OnCollided (gameObject);
		}
		Timer.Instance.AddBonusScore(bonus);
	}

	string GetRandomHumanVoice(int ran) {
		string audioname = "";
		switch (ran) {
		case 0 :
			audioname = AudioManager.HUMAN;
			break;
		case 1 :
			audioname = AudioManager.HUMAN2;
			break;
		case 2: 
			audioname = AudioManager.HUMAN3;
			break;
		case 3: 
			audioname = AudioManager.HUMAN4;
			break;
		case 4: 
			audioname = AudioManager.HUMAN5;
			break;
		case 5: 
			audioname = AudioManager.HUMAN6;
			break;
		case 6: 
			audioname = AudioManager.HUMAN7;
			break;
		}
		return audioname;
	}

	string GetObstacleSound(string t) {
		string aname = "";

		switch (t) {
		case "Fence":
			aname = AudioManager.FENCE;
			break;
		case "Human":
			int r = Random.Range(0,6);
			aname = GetRandomHumanVoice(r);
			break;
		case "Radio":
			aname = AudioManager.RADIO;
			break;
		}
		return aname;
	}
}
