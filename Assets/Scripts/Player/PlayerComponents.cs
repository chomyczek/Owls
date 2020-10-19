using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerComponents
{
	[SerializeField]
	private Rigidbody2D rigidbody;

	public Rigidbody2D RigidBody { get => rigidbody; }
}
