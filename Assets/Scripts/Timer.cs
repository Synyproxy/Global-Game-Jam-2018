using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text timerText;

    [SerializeField]
    private int timer = 0;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(TimerDecrement());
    }
	

   public IEnumerator TimerDecrement()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timer--;
            timerText.text = "" + timer;
        }
        if (timer == 0)
        {
            
            Debug.Log("PERDU");
        }
        
    }
}
