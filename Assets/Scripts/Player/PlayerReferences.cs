using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerReferences
{
	[SerializeField]
	GameObject shuriken;

	public GameObject Shuriken { get => shuriken; }
}
