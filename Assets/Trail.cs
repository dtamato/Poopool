using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour {

	public GameObject plotPointObject;
	public int numberOfPoints= 50;
	public float animSpeed =1.0f;
	public float scaleInputRange = 2*Mathf.PI; // scale number from [0 to 99] to [0 to 2Pi]
	public float scaleResult = 1.0f;
	public bool animate = true;
	public float t = 0.1f;

	private Vector3 m_centerPos;
	private float m_degrees;
	[SerializeField]
	private float m_speed = 1.0f;
	[SerializeField]
	private float m_period = 1.0f;
	[SerializeField]
	private float m_amplitude;
	GameObject[] plotPoints;

	private Vector3 Waypoints;
	private int i;
	private Vector3 TargetPos;
	private Vector3 StartPos;
	private 

	void Start () {

		//me = this.transform.parent;
		m_centerPos = this.transform.position;
		this.GetComponent<TrailRenderer> ().startWidth = .06f;
		this.GetComponent<TrailRenderer> ().endWidth = .06f;

		//if (plotPointObject == null) //if user did not fill in a game object to use for the plot points
		//	plotPointObject = GameObject.CreatePrimitive(PrimitiveType.Sphere); //create a sphere

		//plotPoints = new GameObject[numberOfPoints]; //creat an array of 100 points.

		//for (int i = 0; i < numberOfPoints; i++)
		//{
		//	plotPoints[i] = (GameObject)GameObject.Instantiate(plotPointObject, new Vector3(i - (numberOfPoints/2), 0, 0), Quaternion.identity); //this specifies what object to create, where to place it and how to orient it
		//}
		//we now have an array of 100 points- your should see them in the hierarchy when you hit play
		//plotPointObject.SetActive(false); //hide the original

	}

	float ComputeFunction(float x)
	{
		return Mathf.Sin(x);
	}

	// Update is called once per frame
	void Update()
	{
		this.transform.rotation = this.transform.parent.rotation;
		float deltaTime = Time.deltaTime;

		//m_centerPos.x += deltaTime * m_speed;

		float degreesPerSecond = 360.0f / m_period;
		m_degrees = Mathf.Repeat (m_degrees + (deltaTime * degreesPerSecond), 360.0f);
		float radians = m_degrees * Mathf.Deg2Rad;

		Vector3 offset = new Vector3 (0.0f, m_amplitude * -Mathf.Sin (radians),0.0f);
		this.transform.position =  this.transform.position + offset;
		//this.transform.Translate (offset);
		//this.transform.Rotate (offset);
		//this.transform.position += (vSin + vLin) * Time.deltaTime;
		//Vector3 target = this.GetComponentInParent<Patroller> ().waypoints [this.GetComponentInParent<Patroller> ().currentWaypoint].position;
		//float y = Mathf.Sin (Vector3.Distance (transform.position, target) * m_speed) * m_amplitude;
		//float y = Mathf.Sin((Mathf.Sqrt((target.x - this.transform.position.x) *
		//	(target.x - this.transform.position.x) + (target.z - this.transform.position.z)*(target.z -this.transform.position.z)))*m_speed)* m_amplitude;
		//this.transform.position = new Vector3 (this.transform.position.x, y, this.transform.position.z) + offset;
		//this.transform.position = new Vector3 (this.transform.position.x,  Mathf.Sin(this.transform.position.y), 0);
	}
	
	/*// Update is called once per frame
	void Update () {
		
	}*/
}
