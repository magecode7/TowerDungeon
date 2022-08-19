using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : Collectable
{
    [SerializeField] private int moneyCount = 1;

    protected override void FixedUpdate()
    {
        RaycastHit2D playerHit = collectTrigger.Cast(transform.position);
        if (playerHit)
        {
            if (playerHit.transform.TryGetComponent(out Player player))
            {
                player.Money += moneyCount;
                Destroy(gameObject);
            }
        }
    }
}
