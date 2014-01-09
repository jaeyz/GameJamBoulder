﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WayPointHuman : MonoBehaviour {

	public static WayPointHuman Instance { get; private set; }

	[SerializeField]
	private List<Quaternion> arms;

	private Vector3 respawnPoint;
	private Vector3 destinationPoint;

	private Quaternion respawnRotation;
	private Quaternion destinationRotation;

	private bool isLurking = true;

	private GameObject boulder;

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
		if ((transform.position.z - boulder.transform.position.z) <= 15f) {
			isLurking = false;
		}
	}

	public void SetPosition() {
		respawnPoint = transform.position;
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Boulder") {
		
		}
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
