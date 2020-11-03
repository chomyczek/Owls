using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float selfDestroyTime;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private float speed;

    [SerializeField]
    private int damage;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private LayerMask damageableLayer;

    private Rigidbody2D rigidbody;
    private Collider2D collider;

    // Start is called before the first frame update
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        rigidbody.velocity = new Vector2(speed * rigidbody.velocity.x, rigidbody.velocity.y);
    }

    // Update is called once per frame
    private void Update()
    {
        var direction = Mathf.Sign(rigidbody.velocity.x);
        transform.Rotate(0, 0, Time.deltaTime * rotateSpeed * -direction);
        HandleDamageableCollision();
        HandleWall();
    }

    private void Awake()
    {
        Destroy(gameObject, selfDestroyTime);
    }

    private void HandleWall()
	{
		if (DetectCollider(groundLayer) != null)
		{
            Destroy(gameObject);
		}
	}

    private void HandleDamageableCollision()
	{
        if (DetectCollider(damageableLayer) != null && DetectCollider(damageableLayer).TryGetComponent(out Enemy enemy))
        {
            enemy.Utilities.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public Collider2D DetectCollider(LayerMask colliderLayer)
    {
        var capsuleSize = new Vector2(collider.bounds.size.x, collider.bounds.size.y);
        RaycastHit2D hit = Physics2D.CapsuleCast(
            collider.bounds.center,
            capsuleSize,
            CapsuleDirection2D.Vertical,
            0,
            new Vector2(transform.localScale.x, 0),
            0.1f,
            colliderLayer);

        return hit.collider;

    }

}
