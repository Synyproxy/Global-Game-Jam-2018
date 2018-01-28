using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadNewScene()
    {
        SceneManager.LoadScene("Tuto", LoadSceneMode.Single);
    }

    public void QuitGame()
    {        
        Application.Quit();
    }

    public void LoadCreditScene()
    {
        SceneManager.LoadScene("Crédits", LoadSceneMode.Single);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
