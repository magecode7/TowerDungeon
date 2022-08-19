using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : DamageObject
{
    [SerializeField] private float rotSpeed = 360;

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + rotSpeed * Time.deltaTime);
    }
}
