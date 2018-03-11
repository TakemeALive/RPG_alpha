using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody rigidbody;
	public float speed = 10.0f;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();		
	}

	void FixedUpdate()
	{
		if(rigidbody.velocity.y <= 1.0f)
		{
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");

			// Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
			// movement *= Camera.main.transform.forward;
			Vector3 movement = Camera.main.transform.TransformDirection(moveHorizontal, 0.0f, moveVertical);
			rigidbody.AddForce(movement * speed);
		}
	}
	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("PickupCube"))
		{
			other.gameObject.SetActive(false);
		}
	}
}
