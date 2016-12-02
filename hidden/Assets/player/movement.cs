using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	private Rigidbody rb;
	public float speed = 10;
	Vector3 move;
	int floorMask;
	float camRayLength = 500f;
    public bool grounded = true;


	void Awake ()
	{
		floorMask = LayerMask.GetMask ("Floor");
		rb = gameObject.GetComponent<Rigidbody> ();
	}

	void Start () 
	{
		
	}

	void FixedUpdate () 
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		Move (h, v);
		Turning ();
        Jump ();
		//Animating (h, v);

	}

	void Move (float h, float v)
	{
		// Set the movement vector based on the axis input.
		move.Set (h, 0f, v);

		// Normalise the movement vector and make it proportional to the speed per second.
		move = move.normalized * speed * Time.deltaTime;

		// Move the player to it's current position plus the movement.
		rb.MovePosition (transform.position + move);
	}

    void Jump()
    {
        if (Input.GetButton("Jump") && grounded) {
            rb.AddForce(0, 250, 0);
            grounded = false;
        }
    }

	void Turning ()
	{
		// Create a ray from the mouse cursor on screen in the direction of the camera.
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		// Create a RaycastHit variable to store information about what was hit by the ray.
		RaycastHit floorHit;

		// Perform the raycast and if it hits something on the floor layer...
		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
			// Create a vector from the player to the point on the floor the raycast from the mouse hit.
			Vector3 playerToMouse = floorHit.point - transform.position;

			// Ensure the vector is entirely along the floor plane.
			playerToMouse.y = 0f;

			// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
			Quaternion newRotatation = Quaternion.LookRotation (playerToMouse);

			// Set the player's rotation to this new rotation.
			rb.MoveRotation (newRotatation);
		}
	}
}
