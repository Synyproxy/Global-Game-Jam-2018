using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflector : MonoBehaviour
{
	[SerializeField]
	private GameObject input;

	[SerializeField]
	private GameObject output;

	private bool inputActivated = false;

	private GameObject inputScript;

    // Use this for initialization
    void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		inputActivated = transform.GetComponentInChildren<Input> ().isActive();

		if (inputActivated) {
			transform.GetComponentInChildren<LaserScript> ().enableShooting ();
		} else {
			transform.GetComponentInChildren<LaserScript> ().disableShooting();
		}
	}
}
