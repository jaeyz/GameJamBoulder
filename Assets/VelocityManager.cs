using UnityEngine;
using System.Collections;

public class VelocityManager : MonoBehaviour {

	private float speed = 0;
	private bool begin = false;

	void OnCollisionEnter(Collision collision) {
		if (!begin)
			begin = true;
	}

	void FixedUpdate()
	{
		speed = rigidbody.velocity.z * 2.237f;
		if (speed <= 0 && begin) {
			ScoreHolder.Score = Timer.Instance.CurrentScore;
			GameStatusManager.Instance.GameOver ();
		}
	}

}
