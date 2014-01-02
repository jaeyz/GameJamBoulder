using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformBehaviour : MonoBehaviour {

	private List<Vector3> takenPoints = new List<Vector3>();
	private List<GameObject> cubes = new List<GameObject>();

	public bool isShuttingDown = false;
	
	public static PlatformBehaviour platformBehaviour;

	private List<AttachObject> attachObjects = new List<AttachObject>();

	public static PlatformBehaviour Instance {
		get {
			if (platformBehaviour == null)
				platformBehaviour = FindObjectOfType(typeof(PlatformBehaviour)) as PlatformBehaviour;
			return platformBehaviour;
		}
	}

	void Start () {
		if (!isShuttingDown)
			SpawnObstacles ();
	}

	void OnDestroy () {
		RemoveListeners ();
	}
	
	public void RemoveListeners() {
		foreach (AttachObject a in attachObjects) {
			a.OnCollided -= RemoveObstacleFromList;
		}
	}

	void RemoveObstacleFromList(GameObject g) {
		cubes.Remove (g);
	}
	
	void RepositionObstacles() {
		if (cubes.Count < 2) {
			for(int x = cubes.Count; x < 2; x++) {
				GameObject g = (GameObject) Instantiate(Resources.Load("Mushrooms"));
				cubes.Add(g);
				AttachObject a = g.GetComponent<AttachObject>();
				a.OnCollided += RemoveObstacleFromList;
				attachObjects.Add(a);
			}
		}
		
		foreach (GameObject g in cubes) {
			float posX = Random.Range(transform.renderer.bounds.min.x + 1, transform.renderer.bounds.max.x - 1);
			float posZ = Random.Range(transform.renderer.bounds.min.z + 1, transform.renderer.bounds.max.z - 1);

			g.transform.position = new Vector3(posX, 1.2f, posZ);
		}
	}
	
	void SpawnObstacles() {
		takenPoints.Clear ();
		for (int x = 0; x < 2; x++) {
			float posX = Random.Range(transform.renderer.bounds.min.x, transform.renderer.bounds.max.x);
			float posY = Random.Range(transform.renderer.bounds.min.z, transform.renderer.bounds.max.z);
			GameObject g = (GameObject) Instantiate(Resources.Load("Mushrooms"));
			AttachObject a = g.GetComponent<AttachObject>();
			a.OnCollided += RemoveObstacleFromList;
			attachObjects.Add(a);
			cubes.Add(g);
			g.transform.position = new Vector3(posX,1.2f,posY);
		}
	}
	
	void OnBecameInvisible() {
		transform.root.position += new Vector3 (0, 0, 80);
	}

	void OnBecameVisible() {
		RepositionObstacles ();
	}
	
}
