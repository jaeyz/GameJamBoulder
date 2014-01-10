using UnityEngine;
using System.Collections;

public class GameStatusManager : MonoBehaviour {

	private static GameStatusManager gameStatusManager;

	public static GameStatusManager Instance {
		get {
			if (gameStatusManager == null)
				gameStatusManager = FindObjectOfType(typeof(GameStatusManager)) as GameStatusManager;
			return gameStatusManager;
		}
	}

	public void GameOver() {
		Debug.Log("Game Over");
		PlatformBehaviour.Instance.isShuttingDown = true;
		AudioManager.Instance.StopAll ();
		Application.LoadLevel ("Score");
	}

}
