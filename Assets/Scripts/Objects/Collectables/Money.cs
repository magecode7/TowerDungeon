using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : Collectable
{
    [SerializeField] private int moneyCount = 1;

    protected override void FixedUpdate()
    {
        if (collectTimer.IsOut)
        {
            RaycastHit2D playerHit = collectTrigger.Cast(transform.position);
            if (playerHit)
            {
                if (playerHit.transform.TryGetComponent(out Player player))
                {
                    player.Money += moneyCount;
                    SoundManager.I.Play(collectSound);

                    Destroy(gameObject);
                }
            }
        }
    }
}
