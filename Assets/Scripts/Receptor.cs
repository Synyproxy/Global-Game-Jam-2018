using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptor : MonoBehaviour
{
    [SerializeField]
    private GameObject blackTexture;

    [SerializeField]
    private float speedFade = 0.025f;

    [SerializeField]
    private float TimeBeforFade = 1;

    [SerializeField]
    private Sprite Glow;

    private bool win;
    private float i = 0.0f;
    private float j = 0.0f;
	
	void FixedUpdate ()
	{

    if (win )
        {
            if (j > TimeBeforFade * 50.0f)
            {
                blackTexture.SetActive(true);
                blackTexture.gameObject.GetComponent<SpriteRenderer>().color = new Color(
                                                                                         blackTexture.gameObject.GetComponent<SpriteRenderer>().color.r,
                                                                                         blackTexture.gameObject.GetComponent<SpriteRenderer>().color.g,
                                                                                         blackTexture.gameObject.GetComponent<SpriteRenderer>().color.b,
                                                                                         i
                                                                                         );
                i += speedFade;
            }
            j++;
        }     
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Laser")      
        {
            win = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = Glow;
        }
    } 
}
