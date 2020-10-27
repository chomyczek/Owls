﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStats
{
	public Vector2 Direction { get; set; }
	public int JumpsLeft { get; set; }
	public float Speed { get; set; }
	public int Hp { get; set; }

	public float WalkSpeed { get => walkSpeed; }
	public float JumpForce { get => jumpForce; }
	public int MaxJumpCount { get => maxJumpCount; }
	public int MaxHp { get => maxHp; }

	[SerializeField]
	private float walkSpeed;

	[SerializeField]
	private float runSpeed;

	[SerializeField]
	private float jumpForce;

	[SerializeField]
	private int maxJumpCount;

	[SerializeField]
	private int maxHp;
}
