using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour {

	public GameObject Target;
	public bool b_hasTarget;

	//rot stuff


	[SerializeField]public float angle;
	[SerializeField]public float period = 1f;
	[SerializeField]public float _Time = 10;


	[SerializeField] private float m_moveSpeed;
	[SerializeField] private float m_rotSpeed;
	private Quaternion m_destRot;
	private Vector3 m_targetVec;
	private Vector3 m_destVec;

	private float m_magnitude;
	[SerializeField]
	private float m_stopDistance;

	public Transform[] waypoints;
	public int currentWaypoint = 0;


	public GameObject rotator;

	// Use this for initialization
	void Start () {
		this.transform.position = waypoints [waypoints.Length-1].position;
		this.transform.rotation.SetLookRotation (waypoints [0].position, -Vector3.up);
	}
	
	// Update is called once per frame
	void Update () {

		MoveToward ();
		Orient ();
		Detect ();

	}

	private void MoveToward (){
		this.transform.Translate (Vector3.up * (m_moveSpeed * Time.deltaTime));
		if (m_magnitude <= m_stopDistance) {
			currentWaypoint++;
			if(currentWaypoint >= waypoints.Length)
			{
				currentWaypoint = 0;
			}
		}
	}


	private void Orient (){
		m_targetVec = waypoints [currentWaypoint].position;
		m_destVec = m_targetVec - this.transform.position;
		m_destRot = Quaternion.LookRotation (this.transform.forward, m_destVec);
		m_magnitude = m_destVec.magnitude;
		this.transform.rotation = Quaternion.RotateTowards (this.transform.rotation, m_destRot, m_rotSpeed);
	}

	private void Detect()
	{
		_Time =  Time.time;
		float phase = Mathf.Sin (_Time / period);
		rotator.transform.localRotation = Quaternion.Euler (new Vector3 (0, 0, phase * angle));


	}


}
