using UnityEngine;
using System.Collections;

public class GameAudio : MonoBehaviour {

	private static GameAudio instance = null;
	public static GameAudio Instance {
	 	get { return instance; }
 	}

	 void Awake() {
		 if (instance != null && instance != this) {
		     Destroy(this.gameObject);
		     return;
		 } else {
		     instance = this;
		 }

	     DontDestroyOnLoad(this.gameObject);
	 }


}