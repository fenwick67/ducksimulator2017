using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour{

	public GameObject LoseUI;
	public GameObject PauseUI;
	public string NextLevelName;

	private bool lost = false;
	private float originalFixedDeltaTime;
	private bool paused;

	void Start(){
		originalFixedDeltaTime = Time.fixedDeltaTime;		
	}

	public void Win(){
		if (!lost) {//timescale might just be slowed down, so JIC, don't win if laready lost		
			//show splash screen to load next level
			Time.timeScale =1;
			Time.fixedDeltaTime = originalFixedDeltaTime;
			SceneManager.LoadScene (NextLevelName);
		}
	}

	public void Lose(){
		if (!lost) {
			lost = true;
			//show lose screen to load this level again
			LoseUI.SetActive (true);
		}
	}

	void Update(){
		if (lost && Input.anyKeyDown) {//listen for the Any key after we lose to reload the level
			Time.timeScale =1;
			Time.fixedDeltaTime = Time.unscaledDeltaTime;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	public void Pause(){
		paused = true;
		PauseUI.SetActive (true);
		Time.timeScale = 0f;
	}

	public void UnPause(){
		paused = false;
		PauseUI.SetActive (false);
		Time.timeScale = 1f;
	}

	public void togglePause(){
		if (paused) {
			UnPause ();
		} else {
			Pause ();
		}
	}


}

