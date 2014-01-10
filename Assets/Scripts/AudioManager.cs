using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

	public const string MAIN_MENU = "BGMMainMenu";
	public const string GAME_BGM = "BGMInGame";

	public const string GAME_OVER = "BGMGameOver";
	public const string START = "YaMan1Start";
	public const string HUMAN = "ManImpact1";
	public const string HUMAN2 = "ManImpact2";
	public const string HUMAN3 = "ManImpact3";
	public const string HUMAN4 = "ManImpact4";
	public const string HUMAN5 = "ManImpact5";
	public const string HUMAN6 = "ManImpact6";
	public const string HUMAN7 = "ManImpact7";
	public const string BOULDER_ROLL = "RollingBoulder";
	public const string BATTERY = "Battery";
	public const string RADIO = "Radio";
	public const string FENCE = "FenceImpact";
	public const string EXPLOSION = "RockExplosion";
	public const string COUGH_INTRO = "CoughIntro";
	public const string HIGHSCORE = "HighScorePlaceHolder";
	public const string RETRY = "RetryPlaceHolder";
	public const string BACK = "BackPlaceHolder";

	
	private static AudioManager instance = null;
	private AudioSource bgMusicSource = null;
	private AudioSource soundNonLooping = null;
	private AudioSource soundLoopingSource = null;

	public Dictionary<string, AudioClip> audios = new Dictionary<string, AudioClip>();

	public static AudioManager Instance {
		get { 
			if(instance == null) {
				instance = GameObject.FindObjectOfType(typeof(AudioManager)) as AudioManager;
				if(instance == null) {
					GameObject go = new GameObject("AudioManager");
					GameObject.DontDestroyOnLoad(go);
					instance = go.AddComponent<AudioManager>();
				}
			}
			if (instance.bgMusicSource == null) {
				GameObject music = new GameObject("Music");
				music.transform.parent = instance.transform;
				instance.bgMusicSource =  music.AddComponent<AudioSource>();
			}
			if (instance.soundNonLooping == null) {
				GameObject music = new GameObject("Sound");
				music.transform.parent = instance.transform;
				instance.soundNonLooping =  music.AddComponent<AudioSource>();
			}
			if (instance.soundLoopingSource == null) {
				GameObject music = new GameObject("LoopingSound");
				music.transform.parent = instance.transform;
				instance.soundLoopingSource =  music.AddComponent<AudioSource>();
				instance.soundLoopingSource.loop = true;
			}
			return instance;
		}
	}

	public void Initialize() {
		gameObject.AddComponent<AudioListener>();
		InitializeAudios ();
	}

	public void InitializeAudios() {
		//BGM
		audios.Add (MAIN_MENU, (AudioClip) Resources.Load ("SoundAssets/" + MAIN_MENU));
		audios.Add (GAME_BGM, (AudioClip) Resources.Load ("SoundAssets/" + GAME_BGM));
		//SFX
		audios.Add (GAME_OVER, (AudioClip) Resources.Load ("SoundAssets/" + GAME_OVER));
		audios.Add (HUMAN, (AudioClip) Resources.Load ("SoundAssets/" + HUMAN));
		audios.Add (HUMAN2, (AudioClip) Resources.Load ("SoundAssets/" + HUMAN2));
		audios.Add (HUMAN3, (AudioClip) Resources.Load ("SoundAssets/" + HUMAN3));
		audios.Add (HUMAN4, (AudioClip) Resources.Load ("SoundAssets/" + HUMAN4));
		audios.Add (HUMAN5, (AudioClip) Resources.Load ("SoundAssets/" + HUMAN5));
		audios.Add (HUMAN6, (AudioClip) Resources.Load ("SoundAssets/" + HUMAN6));
		audios.Add (START, (AudioClip) Resources.Load ("SoundAssets/" + START));
		audios.Add (BOULDER_ROLL, (AudioClip) Resources.Load ("SoundAssets/" + BOULDER_ROLL));
		audios.Add (BATTERY, (AudioClip) Resources.Load ("SoundAssets/" + BATTERY));
		audios.Add (FENCE, (AudioClip) Resources.Load ("SoundAssets/" + FENCE));
		audios.Add (EXPLOSION, (AudioClip) Resources.Load ("SoundAssets/" + EXPLOSION));
		audios.Add (COUGH_INTRO, (AudioClip) Resources.Load ("SoundAssets/" + COUGH_INTRO));
		audios.Add (RADIO, (AudioClip) Resources.Load ("SoundAssets/" + RADIO));
		audios.Add (HIGHSCORE, (AudioClip) Resources.Load ("SoundAssets/" + HIGHSCORE));
		audios.Add (RETRY, (AudioClip) Resources.Load ("SoundAssets/" + RETRY));
		audios.Add (BACK, (AudioClip) Resources.Load ("SoundAssets/" + BACK));
	}

	public bool isMusicPlaying(string audioName) {
		if (bgMusicSource.isPlaying) {
			if (bgMusicSource.clip.name == audioName) 
				return true;
		}
		return false;	
	}

	public void PlayMusic (string audioName) {
		AudioClip aClip;
		if (audios.TryGetValue (audioName, out aClip)) {
			bgMusicSource.clip = aClip;
			bgMusicSource.Play();
		}
	}

	public IEnumerator PlayMusicAccordingly(params string[] clips) {
		foreach (string c in clips) {
			PlayMusic(c);
			yield return new WaitForSeconds(bgMusicSource.clip.length);
		}
		StopCoroutine("PlayMusicAccordingly");
	}

	public void PlaySound (string audioName) {
		AudioClip aClip;
		if (audios.TryGetValue (audioName, out aClip)) {
			if (aClip != null) {
				Debug.Log("Playing: " + audioName);
				soundNonLooping.PlayOneShot(aClip);
			} else {
				Debug.Log("NULL");
			}
		}
	}

	public void PlayLoopingSound (string audioName) {
		AudioClip aClip;
		if (audios.TryGetValue (audioName, out aClip)) {
			if (aClip != null) {
				soundLoopingSource.clip = aClip;
				soundLoopingSource.Play();
			}
		}
	}

	public void StopAll() {
		bgMusicSource.Stop ();
		soundLoopingSource.Stop ();
		soundNonLooping.Stop ();
	}
 


}
