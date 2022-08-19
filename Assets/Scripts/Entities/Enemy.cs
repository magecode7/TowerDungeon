using UnityEngine;
using System.Collections;

public class Enemy : Entity
{
    [SerializeField] private RectSensor targetSensor = new RectSensor();

    protected override void FixedUpdate()
    {
        RaycastHit2D hit = targetSensor.Cast(transform.position);
        if (hit)
            if (Combat.CanAttack)
            {
                Attack();
            }
            else
            {
                Vector2 direction = hit.transform.position - transform.position;
                if (direction.x > 0.1f) Move(Vector2.right);
                if (direction.x < -0.1f) Move(Vector2.left);

                if (direction.y > 1) Jump();
            }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        targetSensor.DrawGizmos(transform.position);
    }
}
