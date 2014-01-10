using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformBehaviour : MonoBehaviour {

	private List<Vector3> takenPoints = new List<Vector3>();
	private List<GameObject> cubes = new List<GameObject>();

	public bool isShuttingDown = false;
	
	public static PlatformBehaviour platformBehaviour;

	private List<AttachObject> attachObjects = new List<AttachObject>();
	private List<WayPointHuman> waypoints = new List<WayPointHuman>();

	private System.Random rand = new System.Random();

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
		foreach (WayPointHuman a in waypoints) {
			a.OnCollided -= RemoveObstacleFromList;
		}
	}

	void RemoveObstacleFromList(GameObject g) {
		cubes.Remove (g);
	}
	
	void RepositionObstacles() {
		if (cubes.Count < 1) {
			for(int x = cubes.Count; x < 1; x++) {
				int randomCode = Random.Range(0,2);
				GameObject g = (GameObject) Instantiate(Resources.Load(GetObstacle(randomCode)));
				cubes.Add(g);
				AttachObject a = g.GetComponent<AttachObject>();
				if (a != null) {
					a.OnCollided += RemoveObstacleFromList;
					attachObjects.Add(a);
				}
				WayPointHuman w = g.GetComponent<WayPointHuman>();
				if (w != null) {
					w.OnCollided += RemoveObstacleFromList;
					waypoints.Add(w);
				}
			}
		}
		
		foreach (GameObject g in cubes) {
			float posX = Random.Range(transform.renderer.bounds.min.x + 1, transform.renderer.bounds.max.x - 1);
			float posZ = Random.Range(transform.renderer.bounds.min.z + 1, transform.renderer.bounds.max.z - 1);

			g.transform.position = new Vector3(posX, 1.2f, posZ);
		}

		if (Random.value < 0.4f) {
			float posX = Random.Range(transform.renderer.bounds.min.x + 1, transform.renderer.bounds.max.x - 1);
			float posZ = Random.Range(transform.renderer.bounds.min.z + 1, transform.renderer.bounds.max.z - 1);
		
			GameObject g = (GameObject) Instantiate(Resources.Load("TimerPowerup"));
			g.transform.position = new Vector3(posX, 2f, posZ);
		}

		if (Random.value < 0.25f) {
			float posX = Random.Range(transform.renderer.bounds.min.x + 1, transform.renderer.bounds.max.x - 1);
			float posZ = Random.Range(transform.renderer.bounds.min.z + 1, transform.renderer.bounds.max.z - 1);
			
			GameObject g = (GameObject) Instantiate(Resources.Load("Hazard"));
			g.transform.position = new Vector3(posX, 2f, posZ);
		}
	}
	
	void SpawnObstacles() {
		takenPoints.Clear ();
		for (int x = 0; x < 1; x++) {
			float posX = Random.Range(transform.renderer.bounds.min.x, transform.renderer.bounds.max.x);
			float posY = Random.Range(transform.renderer.bounds.min.z, transform.renderer.bounds.max.z);
			int randomCode =2;
			GameObject g = (GameObject) Instantiate(Resources.Load(GetObstacle(randomCode)));
			AttachObject a = g.GetComponent<AttachObject>();
			if (a != null) {
				a.OnCollided += RemoveObstacleFromList;
				attachObjects.Add(a);
			}
			WayPointHuman w = g.GetComponent<WayPointHuman>();
			if (w != null) {
				w.OnCollided += RemoveObstacleFromList;
				waypoints.Add(w);
			}
			cubes.Add(g);
			g.transform.position = new Vector3(posX,1.2f,posY);
		}
	}
	
	void OnBecameInvisible() {
		transform.root.position += new Vector3 (0, 0, 140);
	}

	void OnBecameVisible() {
		RepositionObstacles ();
	}

	string GetObstacle(int code) {
		string obstacleName = "";
		switch (code) {
		case 0:
			obstacleName = "BlockStripe";
			break;
		case 1:
			obstacleName = "Human";
			break;
		case 2:
			obstacleName = "Radio";
			break;
		}
//		if (code > 0.5f) 
//			obstacleName = "BlockStripe";
//		else
//			obstacleName = "Human";
		return obstacleName;
	}
	
}
