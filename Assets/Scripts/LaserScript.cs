using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class LaserScript : MonoBehaviour
{
    
    public float ExpandSpeed = 0.1f;
    private float initialPositionX;
    private float initialPositionY;
    public bool Shooting = true;
    public bool inputOn = false;

    // Use this for initialization
    void Start ()
    {
        initialPositionX = transform.position.x;               
        initialPositionY = transform.position.y;    
    }
	
	// Each 0.02 seconds
	void FixedUpdate ()
	{
	    if (Shooting && inputOn)
	    {
	        transform.localScale += new Vector3(ExpandSpeed , 0, 0);                //Each 0.02 seconds scale will be increased
	        transform.localPosition += new Vector3(ExpandSpeed / 2 , 0, 0);                 //And pos is move to scale by one side

            
        }
        else if (!inputOn)
	    {
	        initialPositionX = transform.position.x;                
	        initialPositionY = transform.position.y;
        }
	    
	}
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Reflector")
        {
            if(!Shooting)
                ResetTransform();

            Shooting = false;
            Debug.Log("I HIT A SPHERE");         
        }

        if (other.gameObject.tag == "Wall")
        {
            Shooting = false;
            Debug.Log("WALL");
        }

		//Special Case for Transmitter
        if (other.gameObject.tag == "Transmitter")
        {
            Shooting = true;
            inputOn = true;
        }
    }

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Reflector")
		{
			Shooting = true;
			ResetTransform ();
		}

		if (other.gameObject.tag == "Wall")
		{
			Shooting = true;
		}
	}

	public void ResetTransform()
	{
		transform.localScale = new Vector3 (0.1f, 0.15f, 0.1f);
		transform.position = new Vector3(initialPositionX, initialPositionY, 0); 
	}

    public void enableShooting()
    {
        Shooting = true;
    }
    public void disableShooting()
    {
        Shooting = false;
    }

    public void enableInput()
    {
        inputOn = true;
    }
    public void disableInput()
    {
        inputOn = false;
    }
}
