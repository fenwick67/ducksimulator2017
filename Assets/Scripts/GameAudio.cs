using UnityEngine;
using System.Collections;

public class GameAudio : MonoBehaviour {

	public AudioClip PlayNewAudio = null;

	private static GameAudio instance = null;
	public static GameAudio Instance {
	 	get { return instance; }
 	}

	 void Awake() {

		//TODO before killing myself change the audio if created with a <playnew> property
		if (PlayNewAudio != null){
			PlayNew (PlayNewAudio);
		}

		 if (instance != null && instance != this) {
		     Destroy(this.gameObject);
		     return;
		 } else {
		     instance = this;
		 }

	     DontDestroyOnLoad(this.gameObject);
	 }

	public void PlayNew(AudioClip clip){
		AudioSource src = GetComponent<AudioSource>();
		src.Stop ();
		src.clip = clip;
		src.Play ();
	}


}