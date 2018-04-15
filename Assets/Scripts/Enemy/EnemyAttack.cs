using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
	public float timeBetweenAttacks = 1f;
	public int attackDamage = 10;

	Animator anim;
	GameObject player;
	PlayerHealth playerHealth;

	bool isPlayerInRange;
	float timer;

	void Awake() 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		anim = GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject == player) { isPlayerInRange = true; }
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject == player) { isPlayerInRange = false; }
	}

	void Update()
	{
		timer += Time.deltaTime;
		if(timer >= timeBetweenAttacks && isPlayerInRange) { Attack(); }
		if(playerHealth.currentHealth <= 0){ anim.SetTrigger("PlayerDead"); }		
	}

	void Attack()
	{
		timer = 0f;

		if(playerHealth.currentHealth > 0){ playerHealth.TakeDamage(attackDamage); };	
	}
}
