using UnityEngine;
using System.Collections;

//pick up anything that is "Collectible"
public class Pickups : MonoBehaviour {

	public int count;

	// Use this for initialization
	void Start () {
		count = 0;
	}


	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Collectible")) {
			GameObject.Destroy (other.gameObject);//pick it up
			count ++;
		}
	}
}
