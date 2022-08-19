using UnityEngine;
using System.Collections;

[System.Serializable]
public class CircleSensor : Sensor
{
    [SerializeField] private Vector2 offset = Vector2.zero;
    [SerializeField] private float radius = 1;
    [SerializeField] private Vector2 direction = Vector2.zero;
    [SerializeField] private float distance = 0;

    public override RaycastHit2D Cast(Vector2 position)
    {
        return Physics2D.CircleCast(position + offset * scale, radius, direction * scale, distance, mask);
    }

    public override RaycastHit2D[] CastAll(Vector2 position)
    {
        return Physics2D.CircleCastAll(position + offset * scale, radius, direction * scale, distance, mask);
    }

    public override void DrawGizmos(Vector2 position)
    {
        Gizmos.DrawRay(position + offset * scale, direction * scale * distance);
        Gizmos.DrawWireSphere(position + offset * scale, radius);
    }
}
