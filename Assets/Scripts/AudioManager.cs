using UnityEngine;
using System.Collections;

public class AudioManager : MonoSingleton<AudioManager> {

	public AudioClip MAIN_MENU;

	public override void Init () {
		if (MAIN_MENU == null)
			MAIN_MENU = (AudioClip) Resources.Load("SoundsAssets/Summer");
	}

	public void PlayMusic (AudioClip a) {
		if (audio != null) {
			if (a != null) {
				audio.clip = a;
				audio.Play();
			}
		}
	}
 


}
