using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeHeart : Collectable
{
    [SerializeField] private float healthCount = 1;

    protected override void FixedUpdate()
    {
        RaycastHit2D playerHit = collectTrigger.Cast(transform.position);
        if (playerHit)
        {
            if (playerHit.transform.TryGetComponent(out Player player))
            {
                Damageable damageable = player.GetComponent<Damageable>();
                damageable.Health += healthCount;
                SoundManager.I.Play(collectSound);

                Destroy(gameObject);
            }
        }
    }
}
