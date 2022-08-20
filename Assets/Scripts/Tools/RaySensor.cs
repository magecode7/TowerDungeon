using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RaySensor : Sensor
{
    [SerializeField] private Vector2 offset = Vector2.zero;
    [SerializeField] private Vector2 direction = Vector2.zero;
    [SerializeField] private float distance = 0;

    public override RaycastHit2D Cast(Vector2 position)
    {
        return Physics2D.Raycast(position + offset * scale, direction * scale, distance, mask);
    }

    public override RaycastHit2D[] CastAll(Vector2 position)
    {
        return Physics2D.RaycastAll(position + offset * scale, direction * scale, distance, mask);
    }

    public override void DrawGizmos(Vector2 position)
    {
        Gizmos.DrawRay(position + offset * scale, direction.normalized * scale * distance);
    }
}
