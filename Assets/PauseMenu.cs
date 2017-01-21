using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PauseMenu : MonoBehaviour {
	public int playerId = 0; 
	private Player player; 
	bool isPause = true;



	void Start()
	{
		player = ReInput.players.GetPlayer(playerId);
	}


	void Update () 
	{
		GetInput ();
	
	}

	void GetInput ()
	{
		if (player.GetButtonDown ("Pause")) {
			ProcessInput ();
		}
			
	}

	void ProcessInput()
	{
		
		if (isPause == true) {
			isPause = false;
			Time.timeScale = 0.0f;
			Debug.Log("Paused");
		} else {
			Debug.Log ("Unpause");
			isPause = true;
			Time.timeScale = 1.0f;
		}

	}

}
