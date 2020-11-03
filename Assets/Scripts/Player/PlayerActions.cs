using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerActions
{
	private Player player;

	private Vector2 throwOffset;

	public PlayerActions(Player player)
	{
		this.player = player;
		this.throwOffset = new Vector2(player.Components.Collider.bounds.size.x / 2, 0);
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
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Throw()
	{
		if (player.Stats.CanThrow)
		{
			player.StartCoroutine(player.Utilities.CorutineThrowCooldown());			
			var velocity = new Vector2(8, 0);//move to projectile
			var projectile = 
				GameObject.Instantiate(
					player.References.Shuriken, 
					(Vector2)player.transform.position + throwOffset * player.transform.localScale.x, 
					Quaternion.identity);
			projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * player.transform.localScale.x, velocity.y);
		}
	}
}
