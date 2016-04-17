using UnityEngine;
using System.Collections;

public class OrbitCam : MonoBehaviour {

	public GameObject Followee = null;	//what to follow
	public float abovePlayer;		    //look at what relative to the player
	public Vector3 CameraPosition;		//how far back should I be.  X = back, Y = up
	public float mouseSensitivity = 100f;


	private float angle;
	private Vector3 LookAtOffset;

	void Start () {
		if (Followee == null) {
			Followee = GameObject.FindGameObjectWithTag ("Player");//don't rely on this
		}
		//set angle = angle from camera to player in scene setup
		Vector3 diff = Followee.transform.position - transform.position;
		angle = 180-Mathf.Rad2Deg * Mathf.Atan2(diff.z,diff.x);//slooppy but works lol

		LookAtOffset = new Vector3(0f,abovePlayer,0f);
	}

	void LateUpdate () {
		angle = (angle + Input.GetAxis ("Mouse X") * Time.deltaTime * mouseSensitivity)%360;
		//set camera position
		// = player position plus distanceAway rotated by angle
		transform.position = Followee.transform.position + (Quaternion.AngleAxis(angle,Vector3.up) * CameraPosition);

		//point at lookAt + gameobject
		transform.LookAt(Followee.transform.position + LookAtOffset);

	}
}
