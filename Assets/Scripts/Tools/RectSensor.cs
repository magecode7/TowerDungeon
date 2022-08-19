using UnityEngine;
using System.Collections;

[System.Serializable]
public class RectSensor : Sensor
{
    [SerializeField] private Vector2 offset = Vector2.zero;
    [SerializeField] private Vector2 size = Vector2.one;
    [SerializeField] private Vector2 direction = Vector2.zero;
    [SerializeField] private float distance = 0;

    public override RaycastHit2D Cast(Vector2 position)
    {
        return Physics2D.BoxCast(position + offset * scale, size, 0, direction * scale, distance, mask);
    }

    public override RaycastHit2D[] CastAll(Vector2 position)
    {
        return Physics2D.BoxCastAll(position + offset * scale, size, 0, direction * scale, distance, mask);
    }

    public override void DrawGizmos(Vector2 position)
    {
        Gizmos.DrawRay(position + offset * scale, direction * scale * distance);
        Gizmos.DrawWireCube(position + offset * scale, size);
    }
}
