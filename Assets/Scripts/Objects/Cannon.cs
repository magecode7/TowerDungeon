using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletStartSpeed = 10;

    [SerializeField] private Transform firePosition;
    [SerializeField] private Timer fireTimer;
    [SerializeField] private ParticleSystem fireEffect;
    [SerializeField] private ParticleSystem smokeEffect;

    private void FixedUpdate()
    {
        if (fireTimer.IsOut)
        {
            fireTimer.Start();

            GameObject bullet = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation, transform.parent);

            bullet.GetComponent<Bullet>().Fire(firePosition.position, transform.rotation * Vector2.right * bulletStartSpeed);

            if (fireEffect) fireEffect.Play();
            if (smokeEffect) smokeEffect.Play();
        }
    }
}
