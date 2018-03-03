using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody _rigidbody;
	public float _speed = 10.0f;

	void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();		
	}

	void FixedUpdate()
	{
		if(_rigidbody.velocity.y <= 1.0f)
		{
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");

			Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
			_rigidbody.AddForce(movement * _speed);
		}
	}
	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("PickupCube"))
		{
			other.gameObject.SetActive(false);
		}
	}
}
