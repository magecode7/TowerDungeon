using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    [SerializeField] protected CircleSensor collectTrigger = new CircleSensor();
    [SerializeField] protected Timer collectTimer = new Timer(0.5f);
    [SerializeField] protected AudioClip collectSound;

    protected void Awake()
    {
        collectTimer.Start();
    }

    protected abstract void FixedUpdate();

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        collectTrigger.DrawGizmos(transform.position);
    }
}
