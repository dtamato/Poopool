using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChange : MonoBehaviour {


	[SerializeField] string lvl;
	// Use this for initialization
	public void LoadToLvl()
	{
		SceneManager.LoadScene (lvl);
	}
}
