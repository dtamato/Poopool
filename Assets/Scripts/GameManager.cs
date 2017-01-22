using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

	public bool isGameRunning = false;
    public GameObject endScreen;

	protected GameManager() { }

	// Update is called once per frame
	void Update () {
	
        if(endScreen.activeSelf && Input.anyKeyDown)
        {
            SceneManager.LoadScene(0);
        }	
	}

	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}

    public void SetWinner (bool team1Lost)
    {
        isGameRunning = false;

        if(team1Lost)
        {
            endScreen.SetActive(true);
            endScreen.transform.GetChild(0).gameObject.SetActive(true);
            endScreen.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            endScreen.SetActive(true);
            endScreen.transform.GetChild(0).gameObject.SetActive(false);
            endScreen.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
