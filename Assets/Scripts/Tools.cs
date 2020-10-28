using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools
{
	public int LayerMaskToLayer(LayerMask layermask)
	{
		return (int)Mathf.Log(layermask.value, 2);
	}
}
