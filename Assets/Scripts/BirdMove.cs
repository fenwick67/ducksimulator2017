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
	public float JumpSpeed = 1f;
	public float groundCheckDistance = .15f;

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
		movement = Quaternion.AngleAxis(Cam.transform.eulerAngles.y,Vector3.up)* inputAxes;
		if (movement.magnitude > 1f) {
			movement = movement.normalized;
		}
	}

	public void AIMove(Vector3 direction){
		movement = direction;
		if (movement.magnitude > 1f) {
			movement = movement.normalized;
		}
	}

	public void Jump(){
		if (checkGround ()) {
			ActuallyJump ();
		}
	}

	private void ActuallyJump(){
		rb.velocity = new Vector3(rb.velocity.x,JumpSpeed,rb.velocity.z);
	}

	//say whether we are grounded or not
	private bool checkGround(){
		Debug.DrawRay (transform.position + Vector3.up * .1f, Vector3.down * groundCheckDistance, Color.blue, 55);

		if (Physics.Raycast (transform.position+Vector3.up*.1f, Vector3.down,groundCheckDistance)) {
			return true;
		}else{
			return false;
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
		//TODO I have no idea how to do this
	}
		
}
