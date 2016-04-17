using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GenericLevel : MonoBehaviour {

	public int nCollectibles = 1;
	public Pickups p;
	public LevelManager thisLevelManager;

	// Use this for initialization
	void Start () {
		thisLevelManager = GetComponent<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//TODO make this less brutish
	void FixedUpdate(){
		if (p.count >= nCollectibles) {
			//finish the level
			thisLevelManager.Win();
		}
	}
}
