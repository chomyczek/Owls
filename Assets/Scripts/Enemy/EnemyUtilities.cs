using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUtilities
{
	private Enemy enemy;

	public EnemyUtilities(Enemy enemy)
	{
		this.enemy = enemy;
	}
	public void HandleMove()
	{
		switch (enemy.Stats.MoveStyle)
		{
			case EnemyEnums.Move.None:
				break;
			case EnemyEnums.Move.LeftRight:
				this.MoveLeftRight();
				break;
			default:
				break;
		}
	}

	private void MoveLeftRight()
	{
		if(enemy.Stats.Direction.x == 0)
		{
			enemy.Stats.Direction = new Vector2(1, enemy.Stats.Direction.y);
		}
		if (enemy.Utilities.DetectWall() || enemy.Utilities.DetectGap())
		{
			enemy.Utilities.ChangeDirection();
		}
		enemy.Actions.Move(enemy.transform);
	}

	private bool DetectGap()
	{
		RaycastHit2D hit = Physics2D.BoxCast(
			enemy.Components.Collider.bounds.center,
			enemy.Components.Collider.bounds.size,
			//CapsuleDirection2D.Vertical,
			0,
			Vector2.down,
			0.1f,
			enemy.Components.GroundLayer);

		return hit.collider == null;
	}

	private bool DetectWall()
	{
		return false;
		throw new NotImplementedException();

	}

	private void ChangeDirection()
	{
		enemy.Stats.Direction = new Vector2(enemy.Stats.Direction.x > 0 ? -1 : 1, enemy.Stats.Direction.y);
	}
}
