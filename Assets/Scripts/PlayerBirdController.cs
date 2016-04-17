using UnityEngine;
using System.Collections;

public class PlayerBirdController : MonoBehaviour {

	public BirdMove myBirdMove;
	public BoxManager boxMan;

	// Use this for initialization
	void Start () {
		myBirdMove = GetComponent<BirdMove> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1")) {//try and hide
			boxMan.tryHide(true);
			myBirdMove.Move (Vector3.zero);
		} else {
			//try unhide
			boxMan.tryHide(false);
			//if hidden, don't move
			if (boxMan.hidden) {
				myBirdMove.Move (Vector3.zero);
			} else {
				
				if (Input.GetButton ("Walk")) {
					myBirdMove.Move (new Vector3 (Input.GetAxis ("Horizontal")*.5f, 0f, Input.GetAxis ("Vertical")*.5f));
				} else {
					myBirdMove.Move (new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical")));
				}
			}

		}

		if (Input.GetButtonDown("Fire2")){
			myBirdMove.Jump();
		}

	}


		
}
