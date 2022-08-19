using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    [SerializeField] protected LayerMask mask = new LayerMask();
    [SerializeField] protected float damage = 1;
    [SerializeField] protected float knockback = 8;
    [SerializeField] protected float stunTime = 0.5f;

    protected virtual void OnCollisionStay2D(Collision2D collision)
    {
        MakeDamage(collision.gameObject);
    }

    protected void MakeDamage(GameObject target)
    {
        int layer = 1 << target.layer;
        if ((layer & mask) == layer)
        {
            if (target.TryGetComponent(out Entity entity))
            {
                entity.Damageable.TakeDamage(damage);
                entity.Movement.Knockback((target.transform.position - transform.position).normalized * knockback, stunTime);
            }
        }
    }
}
