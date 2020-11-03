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

		if (enemy.Stats.Direction.x != 0)
		{
			transform.localScale = new Vector3(enemy.Stats.Direction.x < 0 ? -1 : 1, 1, 1);
		}
	}

	public void MoveLeftRight()
	{
		if (!enemy.Utilities.IsGrounded())
		{
			return;
		}

		if (enemy.Stats.Direction.x == 0)
		{
			enemy.Stats.Direction = new Vector2(1, enemy.Stats.Direction.y);
		}

		if (enemy.Utilities.DetectWall() || enemy.Utilities.DetectGap())
		{
			enemy.Utilities.ChangeDirection();
		}

		enemy.Actions.Move(enemy.transform);
	}

	public void Die()
	{
		Object.Destroy(enemy.gameObject);
	}
}
