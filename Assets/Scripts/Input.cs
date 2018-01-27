using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour {

	private bool activated = false;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Laser") {
			activated = true;
			//Debug.Log ("Laser Enter");
		}

	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "Laser") {
			activated = false;
			//Debug.Log ("Laser Exit");
		}

	}

	public bool isActive(){
		return activated;
	}
}
