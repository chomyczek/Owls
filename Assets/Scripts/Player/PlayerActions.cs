using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions
{
	private Player player;

	public PlayerActions(Player player)
	{
		this.player = player;
	}

	public void Move(Transform transform)
	{
		if (player.Utilities.IsStickToWall())
		{
			player.Components.RigidBody.velocity = new Vector2(0, player.Components.RigidBody.velocity.y);
		}
		else
		{
			player.Components.RigidBody.velocity = 
				new Vector2(player.Stats.Direction.x * player.Stats.Speed * Time.deltaTime, player.Components.RigidBody.velocity.y);
		}

		if(player.Stats.Direction.x != 0)
		{
			transform.localScale = new Vector3(player.Stats.Direction.x < 0 ? -1 : 1, 1, 1);
		}
	}

	public void Jump()
	{
		if (player.Utilities.IsGrounded())
		{
			player.Stats.JumpsLeft = player.Stats.MaxJumpCount;
		}

		if (player.Stats.JumpsLeft > 0)
		{
			player.Components.RigidBody.velocity = new Vector2(player.Components.RigidBody.velocity.x, 0);
			player.Components.RigidBody.AddForce(new Vector2(0, player.Stats.JumpForce), ForceMode2D.Impulse);
			player.Stats.JumpsLeft--;
		}
	}

	public void Die()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
