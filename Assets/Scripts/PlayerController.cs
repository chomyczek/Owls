using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerController : MonoBehaviour
{
	// Move player in 2D space
	[Range(0, 20)]
	public float maxSpeed = 5f;
	[Range(0, 20)]
	public float jumpHeight = 9f;
	[Range(0, 5)]
	public float gravityScale = 1.5f;
	[Range(0.5f, 1)]
	public float stopDelay = 0.85f;

	public Camera mainCamera;

	private KeyCode moveLeftKey = KeyCode.A;
	private KeyCode moveRightKey = KeyCode.D;
	private KeyCode jumpKey = KeyCode.W;

	private bool facingRight = true;
	private float moveDirection = 0;
	private bool isGrounded = false;

	private Vector3 cameraPos;
	private Rigidbody2D r2d;
	private Collider2D mainCollider;
	// Check every collider except Player and Ignore Raycast
	private LayerMask layerMask = ~(1 << 2 | 1 << 8);
	private Transform t;
	private bool isMoveKeyPressed { get { return Input.GetKey(moveLeftKey) || Input.GetKey(moveRightKey); } }


	// Use this for initialization
	void Start()
	{
		t = transform;
		r2d = GetComponent<Rigidbody2D>();
		mainCollider = GetComponent<Collider2D>();
		r2d.freezeRotation = true;
		r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
		r2d.gravityScale = gravityScale;
		facingRight = t.localScale.x > 0;
		gameObject.layer = 8;

		if (mainCamera)
		{
			cameraPos = mainCamera.transform.position;
		}
	}

	// Update is called once per frame
	void Update()
	{
		// Movement controls
		if (isMoveKeyPressed)
		{
			moveDirection = Input.GetKey(moveLeftKey) ? -1 : 1;
		}
		else
		{
			if (isGrounded || r2d.velocity.magnitude < 0.01f)
			{
				moveDirection = 0;
			}
		}

		// Change facing direction
		if (moveDirection != 0)
		{
			if (moveDirection > 0 && !facingRight)
			{
				facingRight = true;
				t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
			}
			if (moveDirection < 0 && facingRight)
			{
				facingRight = false;
				t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
			}
		}

		// Jumping
		if (Input.GetKeyDown(jumpKey) && isGrounded)
		{
			Jump();
		}

		// Camera follow
		if (mainCamera)
		{
			mainCamera.transform.position = new Vector3(t.position.x, t.position.y, cameraPos.z);
		}
	}

	void FixedUpdate()
	{
		var isCollisionDetected = CollisionCheck();

		if (isCollisionDetected || !isMoveKeyPressed)
		{
			Stop();
		}
		else
		{
			Move();
		}
	}

	private void Move()
	{
		// Apply movement velocity
		r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);
	}
	private void Stop()
	{
		r2d.velocity = new Vector2(r2d.velocity.x * stopDelay, r2d.velocity.y);

	}
	private void Jump()
	{
		r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
	}

	private bool CollisionCheck()
	{
		// Get the velocity		
		var velocityX = r2d.velocity.x * Time.fixedDeltaTime;

		// Predict velocity if player is already blocked
		if(velocityX == 0 && isMoveKeyPressed)
		{
			var directionMultiplier = Input.GetKey(moveLeftKey) ? -1 : 1;
			velocityX = 0.1f * directionMultiplier;
		}

		Vector2 velocity = new Vector2(velocityX, 0.2f);

		// Get bounds of Collider
		Bounds colliderBounds = mainCollider.bounds;
		var bottomRight = new Vector2(colliderBounds.max.x, colliderBounds.max.y);
		var topLeft = new Vector2(colliderBounds.min.x, colliderBounds.min.y);

		// Move collider in direction that we are moving
		bottomRight += velocity;
		topLeft += velocity;

		Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, 0.1f, 0);
		// Check if player is grounded
		isGrounded = Physics2D.OverlapCircle(groundCheckPos, 0.23f, layerMask);

		// Check if the body's current velocity will result in a collision
		return Physics2D.OverlapArea(topLeft, bottomRight, layerMask);
	}

}
