using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obstacle : MonoBehaviour {

	public Transform platform;
	private List<Vector3> takenPoints = new List<Vector3>();
	private List<GameObject> cubes = new List<GameObject>();

	// Use this for initialization
	void Start () {
		SpawnObstacles ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.A))
			RepositionObstacles ();
	}

	void RepositionObstacles() {
		foreach (GameObject g in cubes) {
			float posX = Random.Range(platform.renderer.bounds.min.x + 1, platform.renderer.bounds.max.x - 1);
			float posY = Random.Range(platform.renderer.bounds.min.y + 1, platform.renderer.bounds.max.y - 1);

			g.transform.position = new Vector3(posX, posY, 0);
		}
	}

	void SpawnObstacles() {
		takenPoints.Clear ();
		for (int x = 0; x < 5; x++) {
			float posX = Random.Range(platform.renderer.bounds.min.x, platform.renderer.bounds.max.x);
			float posY = Random.Range(platform.renderer.bounds.min.y, platform.renderer.bounds.max.y);
			GameObject g = (GameObject) Instantiate(Resources.Load("Cube"));
			cubes.Add(g);
			g.transform.position = new Vector3(posX,posY,0);
		}
	}
}
