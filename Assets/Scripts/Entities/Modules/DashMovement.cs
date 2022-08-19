using UnityEngine;
using System.Collections;

public class DashMovement : Movement
{
    [SerializeField] private Timer dash = new Timer();
    [SerializeField] private float dashSpeed = 10;
    [SerializeField] private Timer dashCooldown = new Timer();

    private int dashTimes = 0;
    [SerializeField] private int maxDashTimes = 1;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (IsGrounded) dashTimes = 0;

        if (!dash.IsOut)
        {
            RB.velocity = new Vector2(transform.localScale.x * dashSpeed, 0);
        }
    }

    public void Dash()
    {
        if (dash.IsOut && dashCooldown.IsOut && dashTimes < maxDashTimes)
        {
            dashTimes++;
            Stun(dash.Time);
            dash.Start();
            dashCooldown.Start();

            Animator.SetTrigger("Dash");
        }
    }
}
