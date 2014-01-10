using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WayPointHuman : MonoBehaviour {

	public System.Action<GameObject> OnCollided;

	public static WayPointHuman Instance { get; private set; }

	[SerializeField]
	private List<Quaternion> arms;

	private Vector3 respawnPoint;
	private Vector3 destinationPoint;

	private Quaternion respawnRotation;
	private Quaternion destinationRotation;

	public bool isLurking = true;

	private bool isCollided = false;

	private GameObject boulder;

	private Vector3 lockLocalPos;

	IEnumerator Start () {
		boulder = GameObject.FindGameObjectWithTag ("Boulder");
		Instance = this;
		respawnPoint = transform.position;
		respawnRotation.eulerAngles = transform.localRotation.eulerAngles;
		destinationPoint = respawnPoint + new Vector3 (2, 0, 0);
		destinationRotation.eulerAngles = new Vector3(0,270, 0);

		while (isLurking) {
			yield return StartCoroutine(Move (transform, respawnPoint, destinationPoint, 1.5f));
			yield return StartCoroutine(TurnAround(respawnRotation, destinationRotation, 0.5f));
			yield return StartCoroutine(Move (transform, destinationPoint, respawnPoint, 1.5f));
			yield return StartCoroutine(TurnAround(destinationRotation, respawnRotation, 0.5f));
		}
	}

	void Update() {
		if ((transform.position.z - boulder.transform.position.z) <= 15f && isLurking) {
			isLurking = false;
		} else if (!isLurking && isCollided) {
			transform.localPosition = lockLocalPos;
		}
	}

	public void SetPosition() {
		respawnPoint = transform.position;
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Boulder" || col.tag == "Human" || col.tag == "Fence" || col.tag == "Radio" ) {
			collider.enabled = false;
			isCollided = true;
			int r = Random.Range(0,6);
			AudioManager.Instance.PlaySound(GetRandomHumanVoice(r));
			transform.parent = boulder.transform;
			lockLocalPos = transform.localPosition;
			if (OnCollided != null) {
				OnCollided(gameObject);
			}
		}
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


	IEnumerator TurnAround(Quaternion defaultRotation, Quaternion newRotation, float time) {
		float i = 0.0f;
		float rate = 1.0f/time;
		while (i < 1.0) {
			i += Time.deltaTime * rate;
			transform.eulerAngles = Vector3.Lerp (defaultRotation.eulerAngles, newRotation.eulerAngles, i);
			yield return null; 
		}
	}

	IEnumerator RaiseHands(Quaternion defaultRotation, Quaternion newRotation, float time) {
		float i = 0.0f;
		float rate = 1.0f/time;
		Quaternion a = arms [0];
		Quaternion b = arms [1];
		while (i < 1.0) {
			i += Time.deltaTime * rate;
			a.eulerAngles = Vector3.Lerp (defaultRotation.eulerAngles, newRotation.eulerAngles, i);
			b.eulerAngles = Vector3.Lerp (defaultRotation.eulerAngles, newRotation.eulerAngles, i);
			yield return null; 
		}
	}

	IEnumerator Move(Transform t, Vector3 startPos, Vector3 endPos, float time) {
		float i = 0.0f;
		float rate = 1.0f/time;
		while (i < 1.0) {
			i += Time.deltaTime * rate;
			t.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}


}
