using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyStats stats;
    [SerializeField]
    private EnemyComponents components;
    private EnemyUtilities utilities;
    private EnemyActions actions;

    public EnemyActions Actions { get => actions; }
    public EnemyStats Stats { get => stats; }
    public EnemyUtilities Utilities { get => utilities; }
    public EnemyComponents Components { get => components; }

    private void Awake()
    {
        actions = new EnemyActions(this);
        utilities = new EnemyUtilities(this);
    }

	// Start is called before the first frame update
	private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Utilities.HandlePlayerCollision();
    }

    private void FixedUpdate()
    {
        Utilities.HandleMove();
    }
}
