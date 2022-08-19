using UnityEngine;
using System.Collections.Generic;

public abstract class Sensor
{
    [SerializeField] protected LayerMask mask;

    protected Vector2 scale = Vector2.one;

    public abstract RaycastHit2D Cast(Vector2 position);

    public abstract RaycastHit2D[] CastAll(Vector2 position);

    public void Flip(bool right) => scale.x = right ? 1 : -1;

    public void Flip(float value) => scale.x = value;

    public abstract void DrawGizmos(Vector2 position);
}
