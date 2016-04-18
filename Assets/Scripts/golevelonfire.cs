using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class golevelonfire : MonoBehaviour {

	public string LevelName;


	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire2")){
			SceneManager.LoadScene(LevelName);
		}
	}
}
