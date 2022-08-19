using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpImpulse = 10;
    [SerializeField] private RectSensor groundSensor = new RectSensor();
    private Timer stunTimer = new Timer();

    public bool IsGrounded { get; private set; }
    public bool IsMove { get; private set; }
    public bool IsStunned => !stunTimer.IsOut;

    protected Rigidbody2D RB { get; private set; }
    protected Animator Animator { get; private set; }

    protected virtual void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    protected virtual void LateUpdate()
    {
        Animator.SetBool("IsGrounded", IsGrounded);
        Animator.SetFloat("X", Mathf.Abs(RB.velocity.x));
        Animator.SetFloat("Y", RB.velocity.y);
    }

    protected virtual void FixedUpdate()
    {
        if (IsMove) IsMove = false;
        else Move(Vector2.zero);

        IsGrounded = groundSensor.Cast(transform.position);
    }

    public void Move(Vector2 dir)
    {
        if (!IsStunned)
        {
            IsMove = true;

            dir.Normalize();

            if (dir.x > 0) Flip(true);
            if (dir.x < 0) Flip(false);

            Vector2 velocity = RB.velocity;
            velocity = new Vector2(dir.x * moveSpeed, dir.y * moveSpeed + velocity.y);
            RB.velocity = velocity;
        }
    }

    public void Jump()
    {
        if (IsGrounded && !IsStunned)
        {
            Vector2 velocity = RB.velocity;
            velocity = new Vector2(velocity.x, jumpImpulse);
            RB.velocity = velocity;
        }
    }

    public void Stun(float time) => stunTimer.Start(time);

    public void Knockback(Vector2 velocity, float time)
    {
        Stun(time);
        RB.velocity = velocity;
    }

    private void Flip(bool right)
    {
        Vector3 localScale = transform.localScale;
        localScale.x = right ? 1 : -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = IsGrounded ? Color.green : Color.red;
        groundSensor.DrawGizmos(transform.position);
    }
}
