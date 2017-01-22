using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

	public bool isGameRunning = false;
    public Text winnerText;

	protected GameManager() { }

	// Update is called once per frame
	void Update () {
	
        if(winnerText.gameObject.activeSelf && Input.anyKeyDown)
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
        winnerText.transform.parent.gameObject.SetActive(true);
        winnerText.text = (team1Lost) ? "Team Red Wins!" : "Team Blue Wins!";
    }
}
