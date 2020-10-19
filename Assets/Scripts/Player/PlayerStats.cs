using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStats
{
	public Vector2 Direction { get; set; }

	public float Speed { get; set; }
	public float WalkSpeed { get => walkSpeed; }
	public float JumpForce { get => jumpForce; }

	[SerializeField]
	private float walkSpeed;

	[SerializeField]
	private float runSpeed;

	[SerializeField]
	private float jumpForce;

}
