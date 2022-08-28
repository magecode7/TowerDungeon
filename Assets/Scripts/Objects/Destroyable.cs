using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour, IDamagable
{
    [SerializeField] private float maxHp = 1;
    [SerializeField] protected Timer cooldownTimer = new Timer();
    [SerializeField] private GameObject deathEffect = null;
    [SerializeField] protected float shakeAmplitude = 0;
    [SerializeField] protected float shakeDuration = 0;

    private float hp = 0;

    public bool Alive => hp > 0;
    public float MaxHealth { get => maxHp; set => maxHp = value; }
    public float Health { get => hp; set => hp = Mathf.Clamp(value, 0, MaxHealth); }
    public Dropper Dropper { get; private set; }

    void Awake()
    {
        Dropper = GetComponent<Dropper>();

        Health = MaxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        if (Alive && cooldownTimer.IsOut)
        {
            cooldownTimer.Start();

            Health -= damage;

            GameCamera.I.Shake(shakeDuration, shakeAmplitude);

            if (!Alive)
            {
                Die();
            }
        }
    }

    public void Cooldown(float time) => cooldownTimer.Start(time);

    public void Die()
    {
        Health = 0;

        Dropper?.RealizeDrop();
        if (deathEffect) Instantiate(deathEffect, transform.position, Quaternion.identity, transform.parent);
        Destroy(gameObject);
    }

}
