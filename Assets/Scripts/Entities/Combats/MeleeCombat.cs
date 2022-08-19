﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : Combat
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float stunTime = 1;
    [SerializeField] private float knockback = 8;

    protected override IEnumerator AttackRoutine()
    {
        yield return new WaitForSeconds(damageDelay);

        sensor.Flip(transform.localScale.x);
        RaycastHit2D[] hits = sensor.CastAll(transform.position);

        foreach (var hit in hits)
        {
            if (hit.transform.TryGetComponent(out Entity entity))
            {
                Vector2 dir = hit.transform.position - transform.position;

                entity.Damageable.TakeDamage(damage);
                entity.Movement.Knockback(dir.normalized * knockback, stunTime);
            }
        }

        yield break;
    }
}
