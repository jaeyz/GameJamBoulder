using UnityEngine;
using System.Collections;

public class ParticleFollower : MonoBehaviour {

	[SerializeField]
	private Transform boulder;

	void Update () {
		transform.position = new Vector3(boulder.position.x,boulder.position.y - 1.79f,boulder.position.z);
	}
}
