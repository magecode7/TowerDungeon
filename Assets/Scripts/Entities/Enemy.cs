using UnityEngine;
using System.Collections;

public class Enemy : Entity
{
    [SerializeField] private RectSensor targetSensor = new RectSensor();
    [SerializeField] private RaySensor wallSensor = new RaySensor();
    [SerializeField] private RaySensor floorSensor = new RaySensor();
    [SerializeField] private Timer lastPlayerPositionCheckTimer;

    private Vector2 moveDirection = Vector2.right;
    private Vector2 lastPlayerPosition;
    

    protected override void FixedUpdate()
    {
        RaycastHit2D targetHit = targetSensor.Cast(transform.position);
        if (targetHit)
        {
            lastPlayerPosition = targetHit.transform.position;
            lastPlayerPositionCheckTimer.Start();

            if (Combat.CanAttack)
            {
                Attack();
            }
            else
            {
                MoveTo(targetHit.transform.position);
            }
        }
        else
        {
            if (!lastPlayerPositionCheckTimer.IsOut)
            {
                MoveTo(lastPlayerPosition);
            }
            else FreeMove();
        }
    }

    private void MoveTo(Vector2 position)
    {
        if (Movement.IsGrounded)
        {
            Vector2 direction = position - (Vector2)transform.position;
            if (direction.x > 0.5f) moveDirection = Vector2.right;
            else if (direction.x < -0.5f) moveDirection = Vector2.left;

            Move(moveDirection);
            FlipSensors();

            if (direction.y > 1 && direction.sqrMagnitude < 4) Jump();
            else
            {
                RaycastHit2D wallHit = wallSensor.Cast(transform.position);
                if (wallHit) Jump();
            }

            JumpOff(direction.y < 1);
        }
    }

    private void FreeMove()
    {
        RaycastHit2D wallHit = wallSensor.Cast(transform.position);
        RaycastHit2D floorHit = floorSensor.Cast(transform.position);
        if (wallHit || (!floorHit && Movement.IsGrounded))
        {
            moveDirection *= -1;
        }
        Move(moveDirection);
        FlipSensors();
    }

    private void FlipSensors()
    {
        wallSensor.Flip(transform.localScale.x);
        floorSensor.Flip(transform.localScale.x);
        targetSensor.Flip(transform.localScale.x);
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
