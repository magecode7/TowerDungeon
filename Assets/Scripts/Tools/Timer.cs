using UnityEngine;
using System.Collections;

[System.Serializable]
public class Timer
{
    [SerializeField] private float time = 1;

    private float endTime = 0;

    public bool IsOut { get => endTime <= UnityEngine.Time.time; }
    public float Time { get => time; set => time = value; }

    public Timer() { }

    public Timer(float time) => this.Time = time;

    public void Start(float time) => endTime = UnityEngine.Time.fixedTime + time;

    public void Start() => Start(Time);

    public void Stop() => endTime = UnityEngine.Time.fixedTime;
}
