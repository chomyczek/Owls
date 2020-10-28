using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUtilities
{
	private Player player;
	private Tools tools;
	private List<Command> commands = new List<Command>();

	public PlayerUtilities(Player player)
	{
		this.player = player;
		tools = new Tools();

		commands.Add(new JumpCommand(player, KeyCode.Space));
	}

	public void HandleInput()
	{
		player.Stats.Direction = new Vector2(Input.GetAxisRaw("Horizontal"), player.Components.RigidBody.velocity.y);

		foreach(var command in commands)
		{
			if (Input.GetKeyDown(command.Key))
			{
				command.GetKeyDown();
			}

			if (Input.GetKey(command.Key))
			{
				command.GetKey();
			}

			if (Input.GetKeyUp(command.Key))
			{
				command.GetKeyUp();
			}
		}
	}

	public void HandleCamera()
	{
		player.Components.Camera.transform.position = new Vector3(player.Components.RigidBody.position.x, player.Components.RigidBody.position.y, -100);
	}

	public void TakeDamage(int damage)
	{		
		player.Stats.Hp -= damage;
		Debug.Log(string.Format("{0}/{1}", player.Stats.Hp, player.Stats.MaxHp));

		if (player.Stats.Hp > 0)
		{
			DisableDamage();
		}
		else
		{
			player.Actions.Die();
		}
 	}

	public void HandleDamageDisabeDelay()
	{
		if(player.gameObject.layer != tools.LayerMaskToLayer(player.Components.DamageDelayLayer))
		{
			return;
		}

		if(player.Stats.StartDisableDamageTime + player.Stats.DisableDamageDelay <= Time.fixedTime)
		{
			player.gameObject.layer = tools.LayerMaskToLayer(player.Components.PlayerLayer);
		}
	}

	public bool IsGrounded()
	{
		RaycastHit2D hit = Physics2D.BoxCast(
			player.Components.Collider.bounds.center, 
			player.Components.Collider.bounds.size, 
			0, 
			Vector2.down, 
			0.1f, 
			player.Components.GroundLayer);

		return hit.collider != null;
	}

	public bool IsStickToWall()
	{
		var capsuleSize = new Vector2(player.Components.Collider.bounds.size.x, player.Components.Collider.bounds.size.y * 0.85f);
		RaycastHit2D hit = Physics2D.CapsuleCast(
			player.Components.Collider.bounds.center,
			capsuleSize,
			CapsuleDirection2D.Vertical,
			0,
			new Vector2(player.transform.localScale.x, 0),
			0.1f,
			player.Components.GroundLayer);

		return hit.collider != null;
	}

	public void HandleAir()
	{
		if (IsFalling())
		{

		}
	}

	private bool IsFalling()
	{
		if(player.Components.RigidBody.velocity.y < 0 && !IsGrounded())
		{
			return true;
		}

		return false;
	}

	private void DisableDamage()
	{
		player.gameObject.layer = tools.LayerMaskToLayer(player.Components.DamageDelayLayer);
		player.Stats.StartDisableDamageTime = Time.fixedTime;
	}
}
