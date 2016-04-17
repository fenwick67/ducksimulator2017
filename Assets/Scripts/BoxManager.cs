using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoxManager : MonoBehaviour {

	public List<GameObject> Boxes;
	public float DeployTime;
	public GameObject BoxTarget;
	public float hideCounter = 0;
	public bool hidden = false;

	private int BoxIndex;
	private GameObject Box = null;

	// Use this for initialization
	void Start () {
		BoxIndex = 0;
	}

	//if player holds down ctrl for Ns, deploy box and disable movement	

	void LateUpdate () {
		// update the box's location
		if(Box!= null){
			Box.transform.position = BoxTarget.transform.position;
			Box.transform.rotation = BoxTarget.transform.rotation;
		}
	}

	public void tryHide(bool doHide){
		//increment counter
		if (doHide) {
			hideCounter = hideCounter + Time.deltaTime/DeployTime;
			if (hideCounter > 1f) {
				Hide ();
			}
		} else {
			hideCounter = hideCounter - Time.deltaTime/DeployTime	;
			if (hideCounter < 0f) {
				Unhide ();
			}
		}

	}


	void Hide(){
		if (Box == null) {
			Box = (GameObject) Instantiate(Boxes[BoxIndex],BoxTarget.transform.position, BoxTarget.transform.rotation);
			hidden = true;
		}
		hideCounter = 1;//max out counter
	}

	void Unhide(){
		if (Box != null) {
			Destroy (Box);
			Box = null;
			hidden = false;
		}
		hideCounter = 0;//min out counter
	}
}
