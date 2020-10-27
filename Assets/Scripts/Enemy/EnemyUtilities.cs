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
				enemy.Actions.MoveLeftRight();
				break;
			default:
				break;
		}
	}

	public void HandlePlayerCollision()
	{
		Player player;
		RaycastHit2D hit = Physics2D.BoxCast(
			enemy.Components.Collider.bounds.center,
			enemy.Components.Collider.bounds.size,
			0,
			Vector2.zero,
			0.1f,
			Consts.PlayerLayer);

		if (hit.collider != null && hit.transform.gameObject.TryGetComponent(out player))
		{
			player.Utilities.TakeDamage(enemy.Stats.Damage);
		}
	}

	public bool DetectGap()
	{
		var ahead = enemy.Stats.Direction.x < 0 ? enemy.Components.Collider.bounds.min.x : enemy.Components.Collider.bounds.max.x;
		RaycastHit2D hit = Physics2D.CapsuleCast(
			new Vector2(ahead, enemy.Components.Collider.bounds.center.y),
			enemy.Components.Collider.bounds.size,
			CapsuleDirection2D.Vertical,
			0,
			Vector2.down,
			0.1f,
			enemy.Components.GroundLayer);

		return hit.collider == null;
	}

	public bool DetectWall()
	{
		var capsuleSize = new Vector2(enemy.Components.Collider.bounds.size.x, enemy.Components.Collider.bounds.size.y * 0.85f);
		RaycastHit2D hit = Physics2D.CapsuleCast(
			enemy.Components.Collider.bounds.center,
			capsuleSize,
			CapsuleDirection2D.Vertical,
			0,
			new Vector2(enemy.transform.localScale.x, 0),
			0.1f,
			enemy.Components.GroundLayer);

		return hit.collider != null;

	}

	public void ChangeDirection()
	{
		enemy.Stats.Direction = new Vector2(enemy.Stats.Direction.x > 0 ? -1 : 1, enemy.Stats.Direction.y);
	}

	public bool IsGrounded()
	{
		RaycastHit2D hit = Physics2D.BoxCast(
			enemy.Components.Collider.bounds.center,
			enemy.Components.Collider.bounds.size,
			0,
			Vector2.down,
			0.1f,
			enemy.Components.GroundLayer);

		return hit.collider != null;
	}
}
