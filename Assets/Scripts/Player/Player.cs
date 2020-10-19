using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{	public PlayerComponents Components { get => components; }
	public PlayerStats Stats { get => stats; }
	public PlayerActions Actions { get => actions; }
	public PlayerUtilities Utilities { get => utilities; }

	[SerializeField]
    private PlayerComponents components;
    [SerializeField]
    private PlayerStats stats;
    private PlayerReferences references;
    private PlayerUtilities utilities;
    private PlayerActions actions;

	private void Awake()
	{
        actions = new PlayerActions(this);
        utilities = new PlayerUtilities(this);

        stats.Speed = stats.WalkSpeed;
	}

	// Start is called before the first frame update
	private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Utilities.HandleInput();
        Utilities.HandleAir();
    }

	private void FixedUpdate()
	{
        Actions.Move(transform);
	}
}
