using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private CircleSensor interactSensor = new CircleSensor();
    //private Timer doubleHandle = new Timer(0.2f);

    private int money;
    public static Player player;

    public DashMovement DashMovement { get; private set; }
    public int Money 
    { 
        get 
        {
            return money;
        }
        set 
        {
            if (value < 0) money = 0;
            else money = value;
        }
    }

    protected override void Awake()
    {
        base.Awake();

        player = this;

        DashMovement = (DashMovement)Movement;

        Damageable.dieEvent.AddListener(() => EventManager.I.CallPlayerDied());
    }

    protected override void FixedUpdate()
    {
        //if (PlayerInput.GetDown(InputType.Left) || PlayerInput.GetDown(InputType.Right))
        //    if (!doubleHandle.IsOut) Dash();
        //    else doubleHandle.Start();
        if (PlayerInput.Get(InputType.Ability)) Dash();
        if (PlayerInput.Get(InputType.Left) && !PlayerInput.Get(InputType.Right)) Move(Vector2.left);
        if (PlayerInput.Get(InputType.Right) && !PlayerInput.Get(InputType.Left)) Move(Vector2.right);

        JumpOff(PlayerInput.Get(InputType.Down));
        if (PlayerInput.GetDown(InputType.Jump)) Jump();
        if (PlayerInput.GetDown(InputType.Attack)) Attack();
        if (PlayerInput.GetDown(InputType.Interact)) Interact();
    }

    public void Interact()
    {
        if (CanDo)
        {
            RaycastHit2D hit = interactSensor.Cast(transform.position);
            if (hit)
            {
                IInteractive interactive = hit.transform.GetComponent<IInteractive>();
                interactive.OnInteract(this);
            }
        }
    }

    public void Dash()
    {
        if (CanDo) DashMovement.Dash();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        interactSensor.DrawGizmos(transform.position);
    }
}
