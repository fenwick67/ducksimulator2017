using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HideBar : MonoBehaviour {
	public Slider TheSlider;

	public BoxManager BoxMan;
	// Use this for initialization
	void Start () {
		TheSlider = GetComponent<Slider> ();
		BoxMan = GameObject.FindObjectOfType<BoxManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		TheSlider.value = BoxMan.hideCounter;
	}
}
