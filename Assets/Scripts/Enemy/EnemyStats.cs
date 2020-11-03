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

	[SerializeField]
	private int maxHp;

	public EnemyEnums.Move MoveStyle { get => moveStyle; }
	public Vector2 Direction { get; set; }
	public int Hp { get; set; }
	public float Speed { get => speed; }
	public int Damage { get => damage; }
	public int MaxHp { get => maxHp; }
}
