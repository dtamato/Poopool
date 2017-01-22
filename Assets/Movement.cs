using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;


[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour{

    public int playerId = 0; // The Rewired player id of this character

    public float moveSpeed = 3.0f;

    [SerializeField] GameObject smallSplashPrefab;
    [SerializeField] GameObject bigSplashPrefab;
    [SerializeField] float smallSplashTime = 0.2f;
    [SerializeField] float bigSplashTime = 1;
    float timeSplashButtonPressed;
    float timeSplashButtonReleased;

	public Vector3 rotVector;
    
	protected Vector3 normTarget;
	protected float angle;
	protected Quaternion rot;

    private Player player; // The Rewired Player
    private Rigidbody2D rb2d;
    private Vector3 moveVector;
    private bool fire;
	private bool boost;

	public float thrust;
	public bool isBoost;

    Animator animator;

    void Awake() {
	    // Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
	    player = ReInput.players.GetPlayer(playerId);

        rb2d = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponentInChildren<Animator>();
    }

    void Update ()
    {
        HandleSplashInput();
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
		boost = player.GetButton ("Boost");


    }

    private void ProcessInput() {
	    // Process movement
		if (isBoost) {
			rb2d.MovePosition (this.transform.localPosition + moveVector *(moveSpeed *2)  * Time.deltaTime);

		}else{
	    if(moveVector.x != 0.0f || moveVector.y != 0.0f) {
            //cc.Move(moveVector * moveSpeed * Time.deltaTime);
            rb2d.MovePosition(this.transform.position + moveVector * moveSpeed * Time.deltaTime);
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

    void HandleSplashInput ()
    {
        if (player.GetButtonDown("Splash"))
        {
            timeSplashButtonPressed = Time.time;
        }

        if(player.GetButtonTimePressed("Splash") >= 1)
        {
            this.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }

        if (player.GetButtonUp("Splash"))
        {
            timeSplashButtonReleased = Time.time;

            float timePressed = timeSplashButtonReleased - timeSplashButtonPressed;
            //Debug.Log("timePressed: " + timePressed);

            if (timePressed > smallSplashTime && timePressed < bigSplashTime)
            {
                animator.SetTrigger("Splashing");
                Instantiate(smallSplashPrefab, this.transform.position + this.transform.right, Quaternion.Euler(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z));
            }
            else if (timePressed >= bigSplashTime)
            {
                Instantiate(bigSplashPrefab, this.transform.position + this.transform.right, Quaternion.Euler(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z));
                this.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            }
        }

		if (player.GetButton("Boost")) {
		//	nextBoost = Time.time + boostRate;
			isBoost = true;
	
			if (player.GetButtonTimePressed ("Boost") > 0.5f ) {
				isBoost = false;
			}

		} else {

			isBoost = false;
		}
    }
}