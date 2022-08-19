using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab = null;
    [SerializeField] private int count = 1;

    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        Instantiate(prefab, transform.position, Quaternion.identity, transform.root);
    }
}
