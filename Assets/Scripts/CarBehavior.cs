using UnityEngine;
using System.Collections;

public class CarBehavior : MonoBehaviour {	
	public float maxSpeed = 10;
	public float acceleration = 0.5f;


	float speed = 0;

	void Update () {
		Steer ();
		Accelerate ();
	}

	void Steer() {
		if (Input.GetAxis ("Horizontal") > 0.5f) {
			transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
		} else if(Input.GetAxis ("Horizontal") < -0.5f) {
			transform.RotateAround(transform.position, transform.up, Time.deltaTime * -90f);
		}
	}

	void Accelerate() {
		transform.Translate (Vector3.forward * speed * Time.deltaTime);

		if (Input.GetAxis ("Vertical") > 0.5f && speed + 1 <= maxSpeed) {
			Debug.Log ("Accelerating");
			speed += acceleration;
		} else if (Input.GetAxis ("Vertical") < -0.5f && Mathf.Abs (speed - 1) <= maxSpeed) {
			speed -= acceleration;
		} else if (speed > 0) {
			speed -= 0.1f;
		} else if (speed < 0) {
			speed += 0.1f;
		}
	}
}
