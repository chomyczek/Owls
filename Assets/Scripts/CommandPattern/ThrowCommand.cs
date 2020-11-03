using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCommand : Command
{
	private Player player;
	public ThrowCommand(Player player, KeyCode key) : base(key)
	{
		this.player = player;
	}

	public override void GetKeyDown()
	{
		player.Actions.Throw();
	}
}
