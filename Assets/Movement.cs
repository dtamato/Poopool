using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;


[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour{

public int playerId = 0; // The Rewired player id of this character

public float moveSpeed = 3.0f;
public float bulletSpeed = 15.0f;
public GameObject bulletPrefab;



	public Vector3 rotVector;


	protected Vector3 normTarget;
	protected float angle;
	protected Quaternion rot;

private Player player; // The Rewired Player
private CharacterController cc;
private Vector3 moveVector;
private bool fire;

void Awake() {
	// Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
	player = ReInput.players.GetPlayer(playerId);

	// Get the character controller
	cc = GetComponent<CharacterController>();
}

void FixedUpdate () {
	GetInput();
	ProcessInput();
}

private void GetInput() {
	// Get the input from the Rewired Player. All controllers that the Player owns will contribute, so it doesn't matter
	// whether the input is coming from a joystick, the keyboard, mouse, or a custom controller.

	moveVector.x = player.GetAxis("MoveHorizontal"); // get input by name or action id
	moveVector.y = player.GetAxis("MoveVertical");
		rotVector.x = player.GetAxis ("TurnRight");
		rotVector.y = player.GetAxis ("TurnLeft");


		fire = player.GetButton("Splash");



	
	
}

private void ProcessInput() {
	// Process movement
	if(moveVector.x != 0.0f || moveVector.y != 0.0f) {
		cc.Move(moveVector * moveSpeed * Time.deltaTime);
	}

	// Process fire
	if(fire) {
			Debug.Log ("SPLISH SPLASH");
			if(player.GetButtonTimePressed("Splash") > 2)
			{
				Debug.Log ("BIG SPLASH");
		//GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position + transform.right, transform.rotation);
		//bullet.rigidbody.AddForce(transform.right * bulletSpeed, ForceMode.VelocityChange);
	}
		}

		if (rotVector.x != 0.0f || rotVector.y != 0.0f) {
			normTarget = (rotVector - this.transform.position).normalized;

			angle = Mathf.Atan2 (rotVector.y, rotVector.x)*Mathf.Rad2Deg;

			rot = new Quaternion();
			rot.eulerAngles = new Vector3(0,0,angle);

			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rot, Time.time);


		}
}
}