using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private GameObject build;
    public int
        width = 40,
        height = 20;
    public Elevator elevator;
    [SerializeField] private RectSensor enemiesSensor = new RectSensor();
    [SerializeField] private RectSensor playerSensor = new RectSensor();

    void Awake()
    {
        elevator.Room = this;
    }

    private void FixedUpdate()
    {
        CheckEnemies();
    }

    public void CheckEnemies()
    {
        if (playerSensor.Cast(transform.position))
        {
            bool has = enemiesSensor.Cast(transform.position);

            elevator.SetOpened(!has);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        enemiesSensor.DrawGizmos(transform.position);
        Gizmos.color = Color.green;
        playerSensor.DrawGizmos(transform.position);
    }
}
