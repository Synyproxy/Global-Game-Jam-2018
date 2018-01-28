using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMain : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Invoke ("LoadNewScene", 3);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void LoadNewScene()
	{
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	}
}
