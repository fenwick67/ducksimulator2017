using UnityEngine;
using System.Collections;

public class KillFloor : MonoBehaviour {

	//kill the player if they get too low

	public float KillFloorHeight = -100f;

	void Update () {
		if (transform.position.y < KillFloorHeight) {
			GameObject.FindObjectOfType<LevelManager> ().Lose ();
		}
	}
}
