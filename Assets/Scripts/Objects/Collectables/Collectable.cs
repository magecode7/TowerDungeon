using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    [SerializeField] protected CircleSensor collectTrigger = new CircleSensor();
    protected abstract void FixedUpdate();

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        collectTrigger.DrawGizmos(transform.position);
    }
}
