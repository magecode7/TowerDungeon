using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet : MonoBehaviour
{
    [SerializeField] private CircleSensor playerSensor = new CircleSensor();
    [SerializeField] private GameObject text;

    private void FixedUpdate()
    {
        RaycastHit2D hit = playerSensor.Cast(transform.position);
        if (hit) text.SetActive(true);
        else text.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        playerSensor.DrawGizmos(transform.position);
    }
}
