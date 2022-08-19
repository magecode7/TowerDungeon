using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour
{
    [SerializeField] private float maxHp = 1;
    [SerializeField] private Timer cooldownTimer = new Timer();
    [SerializeField] private GameObject deathEffect = null;
    [SerializeField] private float shakeAmplitude = 0; 
    [SerializeField] private float shakeDuration = 0; 

    private float hp = 0;

    public bool Alive => hp > 0;
    public float MaxHealth { get => maxHp; set => maxHp = value; }
    public float Health { get => hp; set => hp = Mathf.Clamp(value, 0, MaxHealth); }
    public Animator Animator { get; private set; }
    public Dropper Dropper { get; private set; }

    void Awake()
    {
        Animator = GetComponent<Animator>();
        Dropper = GetComponent<Dropper>();

        Health = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (Alive && cooldownTimer.IsOut)
        {
            cooldownTimer.Start();

            Health -= damage;

            if (!Alive)
            {
                Die();
                Animator.SetTrigger("Die");
            }

            Animator.SetTrigger("TakeDamage");

            GameCamera.I.Shake(shakeDuration, shakeAmplitude);
        }
    }

    public void Cooldown(float time) => cooldownTimer.Start(time);

    public void Die()
    {
        Health = 0;
        gameObject.layer = 0;

        Dropper?.RealizeDrop();
        if (deathEffect) Instantiate(deathEffect, transform.position, Quaternion.identity, transform);
    }
}
