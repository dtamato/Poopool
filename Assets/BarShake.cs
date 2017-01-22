using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarShake : MonoBehaviour {

	[SerializeField]public float angle;
	[SerializeField]public float period = 1f;
	 private float _Time = 1;

	public GameObject bar1;
	public GameObject barFill1;
	public GameObject bar2;
	public GameObject barFill2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Team 2 Area").GetComponent<TeamArea> ().isFilling == true) {

			Debug.Log("AYAAASAAS");
			_Time = Time.time;
			float phase = Mathf.Sin (_Time / period);
			bar2.transform.localRotation = Quaternion.Euler (new Vector3 (0, 0, phase * angle));
			barFill2.transform.localRotation = Quaternion.Euler (new Vector3 (0, 0, phase * angle));
		} else {
			bar2.transform.rotation = Quaternion.identity;
			barFill2.transform.rotation = Quaternion.identity;
		}

		if (GameObject.Find ("Team 1 Area").GetComponent<TeamArea> ().isFilling == true) {

			Debug.Log("12");
			_Time = Time.time;
			float phase = Mathf.Sin (_Time / period);
			bar1.transform.localRotation = Quaternion.Euler (new Vector3 (0, 0, phase * angle));
			barFill1.transform.localRotation = Quaternion.Euler (new Vector3 (0, 0, phase * angle));
		} else {
			bar1.transform.rotation = Quaternion.identity;
			barFill1.transform.rotation = Quaternion.identity;
		}
		
	}
	/// GROSS BAR VIBRATION

}
