using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private bool spawnOnStart = true;
    [SerializeField] private List<Spawnable> spawnables = new List<Spawnable>();

    void Start()
    {
        if (spawnOnStart) Spawn();
    }

    public void Spawn()
    {
        foreach (var spawnable in spawnables)
        {
            spawnable.TryChance(transform);
        }
    }


    private void OnDrawGizmosSelected()
    {
        foreach (var spawnable in spawnables)
        {
            foreach (var rect in spawnable.spawnZones)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(transform.position + (Vector3)rect.center, rect.size);
            }
        }
    }

    [Serializable]
    private class Spawnable
    {
        [SerializeField] private List<GameObject> prefabs = new List<GameObject>();
        [SerializeField] private bool attachToParent = true;
        [SerializeField] private int minCount = 1;
        [SerializeField] private int maxCount = 1;
        [SerializeField] private float chance = 1;
        [SerializeField] public List<Rect> spawnZones = new List<Rect>();

        public void TryChance(Transform transform)
        {
            if (Random.value < chance)
                for (int i = 0; i < Random.Range(minCount, maxCount); i++)
                {
                    GameObject spawnedObject = Instantiate(GetRandomPrefab(), transform.position + (Vector3)GetRandomSpawnPoint(), Quaternion.identity);
                    spawnedObject.SetActive(true);
                    if (attachToParent) spawnedObject.transform.parent = transform;
                }
        }

        private GameObject GetRandomPrefab()
        {
            return prefabs[Random.Range(0, prefabs.Count)];
        }

        private Vector2 GetRandomSpawnPoint()
        {
            if (spawnZones.Count == 0) return Vector2.zero;
            int zoneNumber = Random.Range(0, spawnZones.Count);
            Rect spawnZone = spawnZones[zoneNumber];
            Vector2 spawnPoint = new(Random.Range(spawnZone.xMin, spawnZone.xMax), Random.Range(spawnZone.yMin, spawnZone.yMax));
            return spawnPoint;
        }
    }

    [Serializable]
    private struct Rect
    {
        public float x;
        public float y;
        public float width;
        public float height;

        public float xMin => x - width / 2;
        public float xMax => x + width / 2; 
        public float yMin => y - height / 2;
        public float yMax => y + height / 2;

        public Vector2 center => new Vector2(x, y);
        public Vector2 size => new Vector2(width, height);
    }
}
