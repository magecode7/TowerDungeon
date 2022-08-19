using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : DamageObject
{
    [SerializeField] private GameObject collisionEffect;

    protected Rigidbody2D rb;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected override void OnCollisionStay2D(Collision2D collision)
    {
        base.OnCollisionStay2D(collision);

        if (collisionEffect) Instantiate(collisionEffect, transform.position, Quaternion.identity, transform.parent);

        Destroy(gameObject);
    }

    public void Fire(Vector2 position, Vector2 velocity)
    {
        rb.position = position;
        rb.velocity = velocity;
    }
}
