using UnityEngine;
using System.Collections;

public class PlayerBirdController : MonoBehaviour {

	public BirdMove bm;
	public BoxManager boxMan;

	// Use this for initialization
	void Start () {
		bm = GetComponent<BirdMove> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1")) {//try and hide
			boxMan.tryHide(true);
			bm.Move (Vector3.zero);
		} else {
			//try unhide
			boxMan.tryHide(false);
			//if hidden, don't move
			if (boxMan.hidden) {
				bm.Move (Vector3.zero);
			} else {
				bm.Move (new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical")));
			}

		}
	}
		
}
