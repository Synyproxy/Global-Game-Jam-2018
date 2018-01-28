using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0f;

    private Vector3 m_direction = Vector3.zero;

    // Use this for initialization
    void Start()
    {
    }

    void FixedUpdate()
    {
        m_direction.x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        m_direction.z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        Move();
    }

    // Update is called once per frame
    void Update()
    {
        TryInput();
    }

    public void Move()
    {
        transform.Translate(m_direction * speed * Time.deltaTime);
    }

    void TryInput()
    {
        m_direction.x = Input.GetAxisRaw("Horizontal");
        m_direction.y = Input.GetAxisRaw("Vertical");
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            Debug.Log("oui");

            if (Input.GetKeyDown(KeyCode.X))
            {
                other.transform.parent.transform.Rotate(new Vector3(0, 0, -90));
                other.transform.parent.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
        }
    }
}