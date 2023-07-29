using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dropper : MonoBehaviour
{
    [SerializeField] private Vector2 dropPosition;
    [SerializeField] private float dropRadius = 1;
    [SerializeField] private List<Drop> drops = new List<Drop>();

    public void RealizeDrop()
    {
        foreach (Drop drop in drops)
        {
            drop.TryChance(transform, dropPosition, dropRadius);
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

        public void TryChance(Transform transform, Vector3 dropPosition, float dropRadius)
        {
            if (Random.value < chance)
                for (int i = 0; i < Random.Range(minCount, maxCount); i++)
                {
                    GameObject droppedItem = Instantiate(item, transform.position + dropPosition, Quaternion.identity, transform.parent);
                    
                    if (droppedItem.TryGetComponent(out Rigidbody2D rb))
                    {
                        rb.velocity = (Vector2.up + Vector2.right * Random.Range(-dropRadius, dropRadius)) * Random.Range(minDropForce, maxDropForce);
                    }
                }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + (Vector3)dropPosition, dropRadius);
    }

}
