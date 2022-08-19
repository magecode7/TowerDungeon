using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : Singleton<GameCamera>
{
    private float shakeAmplitude = 1;
    private Timer shakeTimer = new Timer();
    [SerializeField] private AnimationCurve moveCurve = new AnimationCurve();
    private Vector3 position;

    void Awake()
    {
        position = transform.position;
    }

    void Update()
    {
        //SetPosition(Vector2.Lerp(position, Player.player.transform.position, 0.01f));
        if (!shakeTimer.IsOut)
        {
            transform.position = position + (Vector3)Random.insideUnitCircle * shakeAmplitude;
        }
        else transform.position = position;
    }

    public void Shake(float duration = 0.2f, float amplitude = 1)
    {
        if (shakeTimer.IsOut || amplitude > shakeAmplitude)
        {
            shakeAmplitude = amplitude;
            shakeTimer.Start(duration);
        }
    }

    public void SetPosition(Vector2 pos) => position = pos;

    public void Move(Vector2 to, float time = 1) => StartCoroutine(MoveRoutine(to, time));

    IEnumerator MoveRoutine(Vector2 to, float time)
    {
        Vector2 from = position;
        float startTime = Time.time;
        while (Time.time - startTime <= time)
        {
            position = Vector2.Lerp(from, to, moveCurve.Evaluate((Time.time - startTime) / 2));
            yield return null;
        }
        yield break;
    }
}
