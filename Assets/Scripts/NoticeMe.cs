using UnityEngine;
using System.Collections;

public class NoticeMe : MonoBehaviour {

	public BoxManager BoxMan;
	public GameObject KillCam;
	public GameObject MainCam;
	public LevelManager myLevelManager;

	private bool spotted = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other){
		CheckBumped (other);
		CheckSeen (other);
	}

	void onTriggerEnter(Collider other){
		CheckBumped (other);
		CheckSeen (other);
	}

	void CheckSeen(Collider other){//trigger enter or stay
		if (other.gameObject.CompareTag ("ViewCone") ) {
			if (BoxMan.hidden) {
				//print ("safe in my box");
			} else {
				WhenSpotted (other);
			}
		}
	}

	void CheckBumped(Collider other){
		if (other.gameObject.CompareTag ("FeelsBumps")) {
			WhenSpotted (other);
		}
	}

	void WhenSpotted(Collider other){
		if (!spotted) {
			spotted = true;
			//todo do something when spotted
			print ("Spotted");

			MainCam.SetActive (false);
			KillCam.SetActive (true);

			//my position + the vector to their position * 1.5
			KillCam.transform.position = transform.position + 2.0f * (other.transform.position + Vector3.up - transform.position);
			KillCam.transform.LookAt (transform.position);

			Time.timeScale = 0.01f;
			Time.fixedDeltaTime = 0f;
			myLevelManager.Lose ();
		}


	}
		

}
