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
			if (CanSeeMe(other)){
				spotted = true;
				//print ("Spotted");

				MainCam.SetActive (false);
				KillCam.SetActive (true);

				//look at the enemy from me... most consistent way to see them
				KillCam.transform.position = transform.position + .5f*Vector3.up;
				KillCam.transform.LookAt (other.transform.position);

				Time.timeScale = 0.01f;
				//Time.fixedDeltaTime = 0f;
				myLevelManager.Lose ();
			}

		}


	}


	private float eyeLevel = 0.0f;
	private float halfMyHeight = .5f;

	bool CanSeeMe(Collider observer){
		//do a check to see it that person can see me or if something is in the way
		Vector3 from = eyeLevel * Vector3.up + observer.transform.position;
		Vector3 dir = (halfMyHeight * Vector3.up + transform.position) - from;//direction from eyelevel to my center

		Ray r = new Ray (from, dir);

		#if UNITY_EDITOR 
			Debug.DrawRay (from,dir,Color.red,55f);
		#endif

		RaycastHit hit;
		//int mask = (1 << 8) & (1 << 9) ;//need to hit the world or player
		bool anyHit = Physics.Raycast (r, out hit,Mathf.Infinity/*,mask*/ );//ray,hit,distance,mask

		if (!anyHit) {
			//print ("hit nothing????");
			return false;
		}
		if (hit.collider.CompareTag ("Player")) {
			//print ("hit me");
			return true;
		} else {
			//print ("hit something else: ");
			//print (hit.collider);
			return false;
		}


	}
		

}
