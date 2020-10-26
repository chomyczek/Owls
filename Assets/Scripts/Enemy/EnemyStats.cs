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

	public EnemyEnums.Move MoveStyle { get => moveStyle; }
	public Vector2 Direction { get; set; }
	public float Speed { get => speed; }

}
