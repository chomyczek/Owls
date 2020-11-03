using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float selfDestroyTime;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private float speed;

    private Rigidbody2D rigidbody;
    
    // Start is called before the first frame update
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(speed * rigidbody.velocity.x, rigidbody.velocity.y);
    }

    // Update is called once per frame
    private void Update()
    {
        var direction = Mathf.Sign(rigidbody.velocity.x);
        transform.Rotate(0, 0, Time.deltaTime * rotateSpeed * -direction);
    }

    private void Awake()
    {
        Destroy(gameObject, selfDestroyTime);
    }

}
