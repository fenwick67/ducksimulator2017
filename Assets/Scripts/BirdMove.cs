using UnityEngine;
using System.Collections;

public class BirdMove : MonoBehaviour {
	//bird movement controller

	private Vector3 movement;

	public float MaxSpeed;
	public float MoveSpeed;
	public float SpinSpeed;
	public Rigidbody rb;
	public Animator BirdAnimator;

	public GameObject Cam;

	// Use this for initialization
	void Start () {
		Cam = GameObject.FindGameObjectWithTag ("MainCamera");
		rb = GetComponent<Rigidbody> ();
		movement = Vector3.zero;
		//keep upright
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
	}
	
	// Update is called once per frame
	void Update () {
		interpolatePosition ();
		updateAnimator ();
		updateRotation ();
	}

	public void Move(Vector3 inputAxes){
		//todo this sucks
		movement = Quaternion.AngleAxis(Cam.transform.eulerAngles.y,Vector3.up)* inputAxes;
		if (movement.magnitude > 1f) {
			movement = movement.normalized;
		}
	}

	void FixedUpdate(){
		rb.velocity = new Vector3(movement.x * MoveSpeed,rb.velocity.y,movement.z*MoveSpeed);
	}

	void updateAnimator(){
		BirdAnimator.SetFloat ("RunSpeed",movement.magnitude);
	}

	void updateRotation(){//called in update
		
		if (movement.magnitude > .01f){
			//update rotation
			transform.rotation = Quaternion.AngleAxis (-180f + Mathf.Rad2Deg * Mathf.Atan2(movement.x,movement.z),Vector3.up);
		}
	}

	void interpolatePosition(){
		//todo I have no idea how to do this
	}
		
}
