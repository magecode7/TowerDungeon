using UnityEngine;
using System.Collections;

public class DashMovement : Movement
{
    [SerializeField] private Timer dash = new Timer();
    [SerializeField] private float dashSpeed = 10;
    [SerializeField] private float maxDashEnergy = 1;
    [SerializeField] private float dashEnergyConsume = 1;
    [SerializeField] private float dashEnergyRecoverSpeed = 1;

    private float dashEnergy = 0;

    public float DashCooldown => DashEnergy / maxDashEnergy;
    public float DashEnergy { get => dashEnergy; set => dashEnergy = Mathf.Clamp(value, 0, maxDashEnergy); }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (!dash.IsOut)
        {
            RB.velocity = new Vector2(transform.localScale.x * dashSpeed, 0);
        }
    }

    private void Update()
    {
        DashEnergy += dashEnergyRecoverSpeed * Time.deltaTime;
    }

    public void Dash()
    {
        if (dash.IsOut && DashEnergy >= dashEnergyConsume)
        {
            DashEnergy -= dashEnergyConsume;
            Stun(dash.Time);
            dash.Start();

            Animator.SetTrigger("Dash");
        }
    }
}
