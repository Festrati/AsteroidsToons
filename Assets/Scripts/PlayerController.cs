using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// normal velocity, start in 0
	private float speed;
	public float minimumSpeed;
	public float maximumSpeed;

	private float rotatioValue = 100.0f;
	
	bool thrust = false;
	bool startMove = false;

	void Start()
	{
		speed = 0;
	}
	
	void Update()
	{	
		if ((Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow))) {
			thrust = true;
			startMove = true;
			print ("Start move");
		}

		if ((Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp (KeyCode.UpArrow))) {
			thrust = false;
		}

		accelerationController ();

	}

	void FixedUpdate()
	{

		float forward = Input.GetAxis ("Vertical");
		float turn = Input.GetAxis("Horizontal");

		//ship forward
		if (startMove) {
			transform.Translate (Vector2.up * speed * Time.deltaTime);
//			transform.Translate(Vector3.up * forward * Time.deltaTime * speed);
	
		}
		//Rotation ship
		transform.Rotate(0, 0, -turn * Time.deltaTime * rotatioValue);

	}

	// controller aceleration
	void accelerationController()
	{
		if (thrust) {
			if(speed >= maximumSpeed){
				speed = maximumSpeed;
			}
			speed += minimumSpeed;
		} else if ((!thrust) && (speed > minimumSpeed)){
			speed -= minimumSpeed / 2;
		}
	}
}
