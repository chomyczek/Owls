using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions
{
	private Enemy enemy;

	public EnemyActions(Enemy enemy)
	{
		this.enemy = enemy;
	}

	public void Move(Transform transform)
	{
		enemy.Components.RigidBody.velocity =
				new Vector2(enemy.Stats.Direction.x * enemy.Stats.Speed * Time.deltaTime, enemy.Components.RigidBody.velocity.y);
	}
}
