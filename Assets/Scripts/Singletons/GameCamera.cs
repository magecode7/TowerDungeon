using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    [SerializeField] private float cameraSpeed = 2;

    private float shakeAmplitude = 1;
    private Timer shakeTimer = new Timer();
    private Timer focusTimer = new Timer();
    private Vector3 position;
    private Vector3 focusPosition;
    private bool teleport = true;

    public static GameCamera I;

    void Awake()
    {
        I = this;

        position = transform.position;
    }

    void Update()
    {
        if (teleport)
        {
            position = Player.player.transform.position;
            teleport = false;
        }
        position = !focusTimer.IsOut
            ? Vector2.Lerp(position, focusPosition, cameraSpeed * Time.deltaTime)
            : Vector2.Lerp(position, Player.player.transform.position, cameraSpeed * Time.deltaTime);

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
