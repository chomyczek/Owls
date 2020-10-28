using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyStats
{
	[SerializeField]
	private EnemyEnums.Move moveStyle;

	[SerializeField]
	private float speed;

	[SerializeField]
	private int damage;

	public EnemyEnums.Move MoveStyle { get => moveStyle; }
	public Vector2 Direction { get; set; }
	public float Speed { get => speed; }
	public int Damage { get => damage; }
}
