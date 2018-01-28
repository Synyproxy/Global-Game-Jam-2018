using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflector : MonoBehaviour
{
	[SerializeField]
	private GameObject input;

	[SerializeField]
	private GameObject[] output;


    private bool inputActivated = false;

	private GameObject inputScript;

    public GameObject firstLaser;

    private float buffPosX = 0.0f;
    private float buffPosY = 0.0f;

    // Use this for initialization
    void Start()
    {
        buffPosX = transform.position.x;
        buffPosY = transform.position.y;
    }

    // Update is called once per frame
	void Update ()
	{
		inputActivated = transform.GetComponentInChildren<InputReflector>().isActive();

	    if (inputActivated)
	    {
            for(int i = 0; i < output.Length; ++i)
	            output[i].transform.GetComponentInChildren<LaserScript>().enableInput();

        }
	    else
	    {
	        for (int i = 0; i < output.Length; ++i)
                output[i].transform.GetComponentInChildren<LaserScript>().ResetTransform();

        }

	    if (buffPosX != transform.position.x || buffPosY != transform.position.y)
	    {
	        firstLaser.GetComponentInChildren<LaserScript>().ResetTransform();
	        buffPosX = transform.position.x;
	        buffPosY = transform.position.y;
        }
	}
}
