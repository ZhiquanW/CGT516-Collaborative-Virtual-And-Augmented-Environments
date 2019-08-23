using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {
	[SerializeField] private float moveSpeed;

	[SerializeField] private Vector3 moveDir;

	[SerializeField] private float maxHeight;

	private Rigidbody playerRigidbody;

	// Use this for initialization
	void Start () {
		playerRigidbody = this.GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update () {
		moveDir = new Vector3(Input.GetAxis("Horizontal"), -0.1f, Input.GetAxis("Vertical"));
		playerRigidbody.velocity = moveDir * moveSpeed;
		
	}

	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag("Cheese")) {
			GameManager.instance.isWin = true;
			GameManager.instance.isGameEnd = true;
		}else if (other.gameObject.CompareTag("Cat")) {
			GameManager.instance.isWin = false;
			GameManager.instance.isGameEnd = true;
		}
	}
}
