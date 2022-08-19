using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combat : MonoBehaviour
{
    [SerializeField] protected RectSensor sensor = new RectSensor();
    [SerializeField] protected float damageDelay = 0;
    [SerializeField] protected Timer attackTime = new Timer(1);

    public float AttackTime => attackTime.Time;

    public bool CanAttack
    {
        get
        {
            sensor.Flip(transform.localScale.x);
            return sensor.Cast(transform.position);
        }
    }

    public Animator Animator { get; private set; }

    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        if (attackTime.IsOut)
        {
            attackTime.Start();
            StartCoroutine(AttackRoutine());
            Animator.SetTrigger("Attack");
        }
    }

    protected abstract IEnumerator AttackRoutine();

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        sensor.DrawGizmos(transform.position);
    }
}
