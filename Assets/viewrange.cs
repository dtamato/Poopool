using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewrange : MonoBehaviour {


	[SerializeField]Transform[] sight;

	bool Seen;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		doYouSee ();
		caughtSlippn ();

}

	void doYouSee()
	{
		Debug.DrawLine (sight[0].position, sight[1].position, Color.green);
		Seen = Physics2D.Linecast (sight [0].position, sight [1].position);

		Debug.DrawLine (sight[0].position, sight[2].position, Color.green);
		Seen = Physics2D.Linecast (sight [0].position, sight [2].position);
	}

	void caughtSlippn()
	{
		if(Seen)
			Debug.Log("TIME OUT!!!");

	}
}
