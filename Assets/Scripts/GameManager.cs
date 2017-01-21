using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : Singleton<GameManager> {

	public bool isGameRunning = false;


	protected GameManager() { }

	// Update is called once per frame
	void Update () {
		
	}

	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}

}
