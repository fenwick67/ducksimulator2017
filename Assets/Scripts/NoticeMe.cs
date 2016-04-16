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
		if (other.gameObject.CompareTag ("ViewCone") ) {
			if (BoxMan.hidden) {
				print ("safe");
			} else {
				print ("spotted");
			}

		}
	}
}
