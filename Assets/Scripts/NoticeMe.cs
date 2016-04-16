using UnityEngine;
using System.Collections;

public class NoticeMe : MonoBehaviour {

	public BoxManager BoxMan;

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
				WhenSpotted ();
			}
		}
	}

	void CheckBumped(Collider other){
		if (other.gameObject.CompareTag ("FeelsBumps")) {
			WhenSpotted ();
		}
	}

	void WhenSpotted(){
		//todo do something when spotted
		print("Spotted");
	}


}
