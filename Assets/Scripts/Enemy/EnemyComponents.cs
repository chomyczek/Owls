using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyComponents
{
	[SerializeField]
	private Rigidbody2D rigidbody;

	[SerializeField]
	private LayerMask groundLayer;

	[SerializeField]
	private LayerMask playerLayer;

	[SerializeField]
	private Collider2D collider;


	public Rigidbody2D RigidBody { get => rigidbody; }
	public LayerMask GroundLayer { get => groundLayer; }
	public Collider2D Collider { get => collider; }
	public LayerMask PlayerLayer { get => playerLayer; }
}
