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

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		movement = Vector3.zero;
		//keep upright
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
	}
	
	// Update is called once per frame
	void Update () {
		updateAnimator ();
	}

	public void Move(Vector3 direction){
		movement = direction;
		if (movement.magnitude > 1f) {
			movement = movement.normalized;
		}

		if (movement.magnitude > .01f){
			//update rotation
			transform.rotation = Quaternion.AngleAxis (-180f + Mathf.Rad2Deg * Mathf.Atan2(movement.x,movement.z),Vector3.up);
		}

	}

	void FixedUpdate(){
		rb.velocity = movement * MoveSpeed;
	}

	void updateAnimator(){
		BirdAnimator.SetFloat ("RunSpeed",movement.magnitude);
	}
		
}
