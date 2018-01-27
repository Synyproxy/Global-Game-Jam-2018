using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

    public float ExpandSpeed = 0.1f;
    private bool IsTrigger = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Each 0.02 seconds
	void FixedUpdate ()
	{
	    if (IsTrigger)
	    {
	        transform.localScale += new Vector3(ExpandSpeed , 0, 0);                //Each 0.02 seconds scale will be increased
	        transform.position += new Vector3(ExpandSpeed / 2 , 0, 0);                 //And pos is move to scale by one side
        }
	    
	}
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Reflector")
        {
            IsTrigger = false;
            Debug.Log("I HIT A SPHERE");
           
        }

        if (other.gameObject.tag == "Wall")
        {
            IsTrigger = false;
            Debug.Log("WALL");
        }

		//Special Case for Transmitter
        if (other.gameObject.tag == "Transmitter")
        {
            IsTrigger = true;
        }
    }

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Reflector")
		{
			IsTrigger = true;
			ResetTransform ();
		}

		if (other.gameObject.tag == "Wall")
		{
			IsTrigger = true;
		}
	}

	void ResetTransform()
	{
		transform.localScale = new Vector3 (0.1f, 0.4f, 1);
		transform.position = new Vector3 (ExpandSpeed / 2, 0, 0); 
	}

    public void activateTrigger()
    {
        IsTrigger = true;

    }

}
