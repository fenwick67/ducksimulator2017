using UnityEngine;
using System.Collections;

public class LimitRotation : MonoBehaviour {

	//limit rotation  for AI people so they don't spin around for 1 frame
	public float maxAngularVelocity;

	private float lastRotation;

	void Start(){
		lastRotation = transform.eulerAngles.y;
	}

	// Update is called once per frame
	void LateUpdate () {
		float newRotation = transform.eulerAngles.y;

		float apparentAngularVelocity = (lastRotation - newRotation )/ Time.deltaTime;



		if ( apparentAngularVelocity > maxAngularVelocity) {//rotation change was negative

			float diff = apparentAngularVelocity - maxAngularVelocity;
			print ("over by "+diff);
			print ("Last frame's y rotation: " + lastRotation);
			print ("Old rotation: " + transform.rotation.eulerAngles);

			//compensate for overrotation by rotating back
			transform.rotation = transform.rotation * Quaternion.Euler(new Vector3( 0, diff*Time.deltaTime,0));


			print ("new rotation: " + transform.rotation.eulerAngles);

		}else if( apparentAngularVelocity < maxAngularVelocity*-1f){//rotation change was positive
			
			float diff = apparentAngularVelocity - maxAngularVelocity;

			transform.rotation = transform.rotation * Quaternion.Euler(new Vector3( 0, 	-1f*diff/Time.deltaTime,0));
		}

		lastRotation = newRotation;
	}
}
