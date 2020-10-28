using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerComponents
{
	[SerializeField]
	private Rigidbody2D rigidbody;

	[SerializeField]
	private LayerMask groundLayer;

	[SerializeField]
	private LayerMask playerLayer;

	[SerializeField]
	private LayerMask damageDelayLayer;

	[SerializeField]
	private Collider2D collider;

	[SerializeField]
	private Camera camera;


	public Rigidbody2D RigidBody { get => rigidbody; }
	public LayerMask GroundLayer { get => groundLayer; }
	public LayerMask PlayerLayer { get => playerLayer; }
	public Collider2D Collider { get => collider; }
	public Camera Camera { get => camera; }
	public LayerMask DamageDelayLayer { get => damageDelayLayer; }
}
