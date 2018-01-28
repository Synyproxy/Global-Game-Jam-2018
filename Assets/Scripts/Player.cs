﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  
    private string inputAxisH = "Horizontal";
    private string inputAxisV = "Vertical";

    [SerializeField]
    private float speed = 0.1f;

    void OnTriggerStay(Collider other)
     {
         if (other.gameObject.tag == "Interactable")
         { 
             if (Input.GetKeyDown(KeyCode.X))
             {
                 other.transform.parent.transform.Rotate(new Vector3(0, 0, -90));
                 other.transform.parent.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
             }
         }
     }
   
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw(inputAxisH);
        float y = Input.GetAxisRaw(inputAxisV);
        Vector2 direction = new Vector2(x * speed, y * speed);
        transform.Translate(direction);
    }
}