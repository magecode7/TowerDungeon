using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : Singleton<GameCamera>
{
    private float shakeAmplitude = 1;
    private Timer shakeTimer = new Timer();
    private Timer focusTimer = new Timer();
    private Vector3 position;
    private Vector3 focusPosition;

    void Awake()
    {
        position = transform.position;
    }

    void Update()
    {
        position = !focusTimer.IsOut
            ? Vector2.Lerp(position, focusPosition, 0.01f)
            : Vector2.Lerp(position, Player.player.transform.position, 0.01f);

        transform.position = !shakeTimer.IsOut 
            ? position + (Vector3)Random.insideUnitCircle * shakeAmplitude 
            : position;
    }

    public void Shake(float duration = 0.2f, float amplitude = 1)
    {
        if (shakeTimer.IsOut || amplitude > shakeAmplitude)
        {
            shakeAmplitude = amplitude;
            shakeTimer.Start(duration);
        }
    }

    public void Focus(Vector2 position, float duration)
    {
        focusTimer.Start(duration);
        focusPosition = position;
    }
}
