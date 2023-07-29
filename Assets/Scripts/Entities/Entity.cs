using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Entity : MonoBehaviour
{
    public Movement Movement { get; private set; }
    public Damageable Damageable { get; private set; }
    public Combat Combat { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public bool CanDo => Damageable.Alive && !Movement.IsStunned;


    protected virtual void Awake()
    {
        Movement = GetComponent<Movement>();
        Damageable = GetComponent<Damageable>();
        Combat = GetComponent<Combat>();
        RB = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate() { }

    public void Move(Vector2 dir)
    {
        if (CanDo) Movement.Move(dir);
    }

    public void Jump()
    {
        if (CanDo) Movement.Jump();
    }

    public void Attack()
    {
        if (CanDo) Combat.Attack();
    }
}
