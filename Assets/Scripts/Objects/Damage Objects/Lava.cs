using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : DamageObject
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        MakeDamage(collision.gameObject);
    }
}
