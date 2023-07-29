using UnityEngine;
using System.Collections;

public class Enemy : Entity
{
    [SerializeField] private RectSensor targetSensor = new RectSensor();
    [SerializeField] private RaySensor wallSensor = new RaySensor();
    [SerializeField] private RaySensor floorSensor = new RaySensor();

    private Vector2 moveDirection = Vector2.right;

    protected override void FixedUpdate()
    {
        RaycastHit2D targetHit = targetSensor.Cast(transform.position);
        if (targetHit)
            if (Combat.CanAttack)
            {
                Attack();
            }
            else
            {
                Vector2 direction = targetHit.transform.position - transform.position;
                if (direction.x > 0.1f) Move(Vector2.right);
                if (direction.x < -0.1f) Move(Vector2.left);

                if (direction.y > 1 && direction.sqrMagnitude < 9) Jump();
                else
                {
                    RaycastHit2D wallHit = wallSensor.Cast(transform.position);
                    if (wallHit) Jump();
                }
            }
        else
        {
            RaycastHit2D wallHit = wallSensor.Cast(transform.position);
            RaycastHit2D floorHit = floorSensor.Cast(transform.position);
            if (wallHit || !floorHit)
            {
                moveDirection *= -1;
                wallSensor.Flip(moveDirection.x);
                floorSensor.Flip(moveDirection.x);
            }
            Move(moveDirection);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        targetSensor.DrawGizmos(transform.position);
        Gizmos.color = Color.cyan;
        wallSensor.DrawGizmos(transform.position);
        floorSensor.DrawGizmos(transform.position);
    }
}
