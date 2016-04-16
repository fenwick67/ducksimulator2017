using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public GameObject Followee;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - Followee.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Followee.transform.position + offset;
	}
}
