using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dropper : MonoBehaviour
{
    [SerializeField] private List<Drop> drops = new List<Drop>();

    public void RealizeDrop()
    {
        foreach (Drop drop in drops)
        {
            drop.TryChance(transform.position);
        }
    }

    [Serializable]
    private class Drop
    {
        [SerializeField] private GameObject item;
        [SerializeField] private int minCount = 1;
        [SerializeField] private int maxCount = 1;
        [SerializeField] private float chance = 1;
        [SerializeField] private float minDropForce = 1;
        [SerializeField] private float maxDropForce = 5;

        public void TryChance(Vector2 position)
        {
            if (Random.value < chance)
                for (int i = 0; i < Random.Range(minCount, maxCount); i++)
                {
                    GameObject droppedItem = Instantiate(item, position, Quaternion.identity);
                    if (droppedItem.TryGetComponent(out Rigidbody2D rb))
                    {
                        rb.velocity = (Vector2.up + Vector2.right * Random.Range(-1f, 1f)) * Random.Range(minDropForce, maxDropForce);
                    }
                }
        }
    }

}
