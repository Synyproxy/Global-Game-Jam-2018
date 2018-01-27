using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    
    public float ExpandSpeed = 0.1f;
    private float initialPositionX;
    private float initialPositionY;
    private bool Shooting = false;

    // Use this for initialization
    void Start ()
    {
        initialPositionX = transform.position.x;
        initialPositionY = transform.position.y;    
    }
	
	// Each 0.02 seconds
	void FixedUpdate ()
	{
	    if (Shooting)
	    {
	        transform.localScale += new Vector3(ExpandSpeed , 0, 0);                //Each 0.02 seconds scale will be increased
	        transform.position += new Vector3(ExpandSpeed / 2 , 0, 0);                 //And pos is move to scale by one side
        }
	    
	}
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Reflector")
        {
           // if(!Shooting)
             //   ResetTransform();

            ResetToReflector(other);

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

	void ResetTransform()
	{
		transform.localScale = new Vector3 (0.1f, 0.4f, 0.1f);
		transform.position = new Vector3(initialPositionX, initialPositionY, 0); 
	}

    void ResetToReflector(Collider other)
    {
        float other_pos_x = other.gameObject.transform.position.x;
        float other_pos_y = other.gameObject.transform.position.y;

        float laser_max_x = initialPositionX + GetComponent<BoxCollider>().bounds.size.x;
        float laser_max_y = initialPositionY + GetComponent<BoxCollider>().bounds.size.y;

        float scaling_x = other_pos_x / laser_max_x;
        float scaling_y = other_pos_y / laser_max_y;


        Debug.Log("HEY ITS ME");

        transform.localScale = new Vector3(scaling_x, scaling_y, 0.1f);
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

}
